using Dapper;
using SivBiblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace SivBiblioteca.AccesoDatos
{
    /// Nota - las fechas se guardan en tiempo unix UTC y se extraen como strings yyyy-mm-dd hh:mm:ss en tiempo local.
    /// Nota - Los precios se guardan en la base de datos como enteros.
    ///          Esto se realiza para guardar los precios con una precision fija.
    ///     
    /// Nota - Se utiliza 'case' en algunas condiciones de algunos query
    /// usualmente para obtener un 'mejor' query plan.
    /// 
    /// ej. Cuando se genera un reporte de venta, si se filtra por fecha de venta 
    /// y se tiene la condicion productos.id = @ProductoId
    /// el query plan es buscar aquellos lotes asociados con el producto indicado,
    /// luego obtener las ventas a partir de estos lotes y filtrarlas por fecha.
    /// El indice en la columna 'fecha' de la tabla ventas no se utiliza de primero.
    /// (es mas el query plan aparentemente ni lo usa).
    /// 
    /// Sin embargo, esto es ineficiente si hay muchos lotes asociados con el producto especificado.
    /// 
    /// Asumiendo que se proporciona un rango de fechas =>
    /// 
    /// query plan sin case:
    /// SEARCH TABLE productos USING INTEGER PRIMARY KEY(rowid =?)
    /// SEARCH TABLE lotes USING INDEX idx_Lotes_ProductoId(ProductoId=?)
    /// SEARCH TABLE ventas USING INDEX idx_Ventas_LoteId(LoteId=?)
    /// 
    /// query plan con case:
    /// SEARCH TABLE ventas USING INDEX idx_Ventas_Fecha (Fecha>? AND Fecha<?)
    /// SEARCH TABLE lotes USING INTEGER PRIMARY KEY(rowid=?)
    /// SEARCH TABLE productos USING INTEGER PRIMARY KEY(rowid =?)
    /// 
    /// Lo mismo sucede en otros casos como el de generar reportes de lotes.

    ///  https://stackoverflow.com/a/49861947

    ///  Ni idea si el plan del query sin case se debe a una estructura del query pobre, 
    ///  o un diseno pobre de las tablas lol
    ///  ¯\_(ツ)_/¯
    public class SqliteConexion : IConexionDatos
    {
        string stringConexion = ConfigGlobal.ConseguirStringConexion(id: "SqliteBd");

        // Describe cuantos digitos se consideran despues del punto decimal
        // en todos los precios que se guardan en la base de datos.
        // Si la precision es 2, todos los precios se deberan guardar en
        // centavos.
        // Ej. 5.55 cordobas se convierte a 555 centavos.
        // En este caso se conservan 4 digitos despues del decimal, por lo que
        // se trabaja con 'diezmilesimas' es decir 5.55 -> 55500, 6.7899 -> 67899.
        // Los digitos restantes seran truncados.

        // En general si se trabaja con una precision p y
        // un precio x se representara en la base de datos como
        // x * (10^p)
        // una vez extraido de la base de datos se divide por (10^p) para obtener la representacion
        // original x
        const double MonedaPrecision = 4;

        // Factor de conversion para convertir los precios.
        int factorConversion = Convert.ToInt32(Math.Pow(10, MonedaPrecision));

        // Valor maximo de la moneda que se puede representar.
        decimal monedaMaximo = Int64.MaxValue / Convert.ToInt32(Math.Pow(10, MonedaPrecision));

        public decimal MonedaMaximo { get { return monedaMaximo; } }

        /// <summary>
        /// Revisa si la categoria existe en la base de datos.
        /// </summary>
        /// <param name="nombreCategoria"> Nombre de la categoria a buscar. </param>
        /// <returns> true si existe, false si no. </returns>
        public bool CategoriaExiste(string nombreCategoria)
        {
            if (string.IsNullOrWhiteSpace(nombreCategoria))
            {
                throw new ArgumentException("El nombre de la categoria esta vacio o fue null.");
            }

            nombreCategoria = nombreCategoria.Trim();

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "select exists (select 1 from Categorias where Nombre = @Nombre)";
                return conexion.ExecuteScalar<bool>(q, new { Nombre = nombreCategoria });
            }
        }

        /// <summary>
        /// Guarda una lista de categorias en la base de datos.
        /// </summary>
        /// <param name="categorias">
        ///     Lista de categorias a guardar.
        /// </param>
        public void GuardarCategorias(List<CategoriaModelo> categorias)
        {
            categorias.ValidarCategorias(verificarQueNoExistan: true);

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "insert into Categorias (Nombre) values (@Nombre)";

                foreach (var categoria in categorias)
                {
                    conexion.Execute(q, categoria);
                    categoria.Id = conexion.ExecuteScalar<int>("select max(id) from Categorias");
                }
            }
        }

        /// <summary>
        ///     Elimina de la base de datos una lista de categorias.
        /// </summary>
        /// <param name="categorias"> Lista de categorias a eliminar. </param>
        public void EliminarCategorias(List<CategoriaModelo> categorias)
        {
            categorias.ValidarCategorias();

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "delete from Categorias where Id = @Id";
                conexion.Execute(q, categorias);
            }
        }

        /// <summary>
        ///     Guarda un producto en la base de datos.
        /// </summary>
        /// <param name="producto"> Producto a guardar. </param>
        public void GuardarProducto(ProductoModelo producto)
        {
            producto.ValidarProducto(verificarQueNoExista: true);

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = @"insert into productos (Nombre, FechaCreacion, Descripcion)
                            values (@Nombre, strftime('%s', 'now'), @Descripcion)";

                var parametros = new { Nombre = producto.Nombre, Descripcion = producto.Descripcion };

                conexion.Execute(q, parametros);

                producto.Id = conexion.ExecuteScalar<int>("select max(Id) from Productos");

                if (producto.Categorias == null) return;

                producto.Categorias.ValidarCategorias();

                q = "insert into ProductoCategoria (ProductoId, CategoriaId) values (@ProductoId, @CategoriaId)";

                foreach (var categoria in producto.Categorias)
                {
                    conexion.Execute(q, new { ProductoId = producto.Id, CategoriaId = categoria.Id });
                }
            }
        }

        /// <summary>
        ///     x se multiplica por el factor de conversion para obtener 
        ///     la representacion de la moneda que se utilizara en la base de datos.
        ///     los decimales restantes se truncan. 
        ///     Si x * FactorConversion > decimal.MaxValue o x * FactorConversion > Int64.MaxValue se producira una excepcion.
        /// </summary>
        /// <param name="x"> El valor de la moneda en su representacion actual. </param>
        /// <returns> El valor de la moneda en la representacion utilizada en la base de datos. </returns>
        private long ConvertirMonedaARepresentacionInterna(decimal x)
        {
            return Convert.ToInt64(decimal.Truncate(x * factorConversion));
        }

        /// <summary>
        ///     Carga y retorna un lote de la base de datos a partir de su id.
        /// </summary>
        /// <param name="id"> Id del lote. </param>
        /// <returns> El lote. Si no se encontro se retorna null. </returns>
        public LoteModelo CargarLote_PorId(int id)
        {
            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = $@"select lotes.Id,
                            lotes.UnidadesCompradas,
                            lotes.UnidadesDisponibles,
                            lotes.Inversion,
                            lotes.PrecioVentaUnidad,
                            datetime(lotes.FechaCreacion, 'unixepoch', 'localtime') as 'FechaCreacion',
                            p.*
                            from Lotes
                            join productos p on p.id = lotes.ProductoId
                            where lotes.id = @loteId";

                Func<LoteModelo, ProductoModelo, LoteModelo> f = (l, p) => { l.Producto = p; return l; };
                var lote = conexion.Query<LoteModelo, ProductoModelo, LoteModelo>(q, f, new { loteId = id }).FirstOrDefault();

                if (lote == null) return null;

                lote.Inversion = lote.Inversion / factorConversion;
                lote.PrecioVentaUnidad = lote.PrecioVentaUnidad / factorConversion;

                return lote;
            }
        }

        /// <summary>
        /// Guarda una lista de ventas a la base de datos.
        /// </summary>
        /// <param name="ventas"> Lista de ventas a guardar. </param>
        public void GuardarVentas(List<VentaModelo> ventas)
        {
            ventas.ValidarVentas();

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                conexion.Open();
                using (var transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        var q = @"insert into ventas (LoteId, Unidades, PrecioVentaUnidad, Comentario, ClienteId, Fecha)
                            values (@LoteId, @Unidades, @PrecioVentaUnidad, @Comentario, @ClienteId, strftime('%s', 'now'))";

                        foreach (var venta in ventas)
                        {

                            var parametros = new
                            {
                                LoteId = venta.Lote.Id,
                                Unidades = venta.Unidades,
                                PrecioVentaUnidad = ConvertirMonedaARepresentacionInterna(venta.PrecioVentaUnidad),
                                Comentario = venta.Comentario?.Trim(),
                                ClienteId = venta.Cliente?.Id
                            };

                            conexion.Execute(q, parametros);

                            conexion.Execute("update Lotes set UnidadesDisponibles = UnidadesDisponibles - @UnidadesVendidas where Id = @Id",
                                new { UnidadesVendidas = venta.Unidades, Id = venta.Lote.Id }
                            );
                        }
                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        ///     Retorna las unidades disponibles de un lote.
        /// </summary>
        /// <param name="loteId"> Id del lote. </param>
        /// <returns> Unidades restantes del lote. Si el lote no existe se retorna null. </returns>
        public int? UnidadesDisponiblesLote(int loteId)
        {
            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "select UnidadesDisponibles from Lotes where Id = @Id";
                return conexion.ExecuteScalar<int?>(q, new { Id = loteId });
            }
        }

        /// <summary>
        ///     Guarda un cliente en la base de datos.
        /// </summary>
        /// <param name="cliente"> El cliente a guardar. </param>
        public void GuardarCliente(ClienteModelo cliente)
        {
            cliente.ValidarCliente();

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "insert into Clientes (Nombre, Apellido, NumeroContacto) values (@Nombre, @Apellido, @NumeroContacto)";
                conexion.Execute(q, cliente);
                cliente.Id = conexion.ExecuteScalar<int>("select max(Id) from clientes;");
            }
        }

        /// <summary>
        ///     Carga y retorna una lista de clientes cuyo nombre completo contiene el parametro 'nombre'.
        /// </summary>
        /// <param name="nombre"> El nombre del cliente a buscar. </param>
        /// <param name="limiteFilas"> Limite de filas a retonar. </param>
        /// <returns> Lista de clientes encontrados. </returns>
        public List<ClienteModelo> BuscarCliente_PorNombre(string nombre, int limiteFilas = 10)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre a buscar no puede estar vacio.");
            }

            nombre = nombre.Trim();

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "select * from Clientes where (Nombre || ' ' || coalesce(Apellido, '')) like @Nombre limit @limiteFilas";
                var parametros = new { Nombre = '%' + nombre + '%', limiteFilas = limiteFilas };
                return conexion.Query<ClienteModelo>(q, parametros).ToList();
            }
        }

        /// <summary>
        ///     Genera y retorna una lista de cada venta realizada con informacion pertinente.
        /// </summary>
        /// <param name="filtro"> 
        ///     Objeto que contiene condiciones que las ventas deben cumplir.
        ///     ej. Tipo de producto, fecha de venta, etc.
        /// </param>
        /// <param name="limiteFilas"> 
        ///     Limite de filas a retornar. Util si la informacion se presentara al usuario
        ///     o para paginar los resultados.
        /// </param>
        /// <param name="comienzo">
        ///     Impone la condicion (ventas.id < comienzo.)
        ///     Util para paginar los resultados.
        /// </param>
        /// <returns> Lista de reportes. </returns>
        /// <example>
        /// <code>
        /// // Ejemplo para paginacion de resultados.
        /// var reportes1 = CargarReporteVentas(limiteFilas: 1, comienzo: null); // Carga la ultima venta.
        /// var reportes2 = CargarReporteVentas(limiteFilas: 1, comienzo: reportes1.LastOrDefault()?.Id); // Carga la penultima venta.
        /// var reportes3 = CargarReporteVentas(limiteFilas: 1, comienzo: reportes2.LastOrDefault()?.Id); // Carga la antepenultima venta.
        /// ...
        /// </code>
        /// </example>
        public List<ReporteVentaModelo> CargarReporteVentas(ReporteFiltroModelo filtro = null, int? limiteFilas = null, int? comienzo = null)
        {
            var parametros = new DynamicParameters();

            var q = ConstruirQueryReporte
            (
                reporteTipo: typeof(ReporteVentaModelo),
                filtro: filtro,
                parametros: parametros,
                comienzo: comienzo,
                limiteFilas: limiteFilas
            );

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var reportes = conexion.Query<ReporteVentaModelo>(q, parametros).ToList();

                // Convertir representacion interna de la moneda a la representacion original.
                foreach (var reporte in reportes)
                {
                    reporte.InversionLote /= factorConversion;
                    reporte.PrecioVentaUnidad /= factorConversion;
                }
                return reportes;
            }
        }

        /// <summary>
        /// Carga y retorna el id del ultimo lote agregado a la base de datos.
        /// </summary>
        /// <returns> El id del ultimo lote agregado a la base de datos. </returns>
        public int CargarUltimoLoteId()
        {
            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                return conexion.ExecuteScalar<int>("select max(Id) from Lotes");
            }
        }

        /// <summary>
        ///     Guarda un lote en la base de datos.
        /// </summary>
        /// <param name="lote"> Lote a guardar. </param>
        public void GuardarLote(LoteModelo lote)
        {
            lote.ValidarLote();

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = @"insert into Lotes (ProductoId, UnidadesCompradas, UnidadesDisponibles, Inversion, PrecioVentaUnidad, FechaCreacion)
                            values (@ProductoId, @UnidadesCompradas, @UnidadesDisponibles, @Inversion, @PrecioVentaUnidad, strftime('%s', 'now'))";

                lote.UnidadesDisponibles = lote.UnidadesCompradas;

                var parametros = new
                {
                    ProductoId = lote.Producto.Id,
                    UnidadesCompradas = lote.UnidadesCompradas,
                    UnidadesDisponibles = lote.UnidadesDisponibles,
                    Inversion = ConvertirMonedaARepresentacionInterna(lote.Inversion),
                    PrecioVentaUnidad = ConvertirMonedaARepresentacionInterna(lote.PrecioVentaUnidad)
                };

                conexion.Execute(q, parametros);

                q = "select max(Id) from Lotes";
                lote.Id = conexion.ExecuteScalar<int>(q);
            }
        }

        /// <summary>
        ///     Revisa si un producto existe en la base de datos a partir del nombre proporcionado.
        /// </summary>
        /// <param name="nombre"> El nombre del producto a buscar. </param>
        /// <returns> true si el producto existe, false si no. </returns>
        public bool ProductoExiste(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre a buscar esta vacio o fue null.");
            }

            nombre = nombre.Trim();

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "select exists (select 1 from Productos where Nombre = @Nombre collate nocase)";
                return conexion.ExecuteScalar<bool>(q, new { Nombre = nombre });
            }
        }

        /// <summary>
        ///     Carga y retorna una lista de categorias de la base de datos
        ///     cuyos nombres contienen el parametro 'nombre'.
        /// </summary>
        /// <param name="nombre"> Nombre a buscar. </param>
        /// <param name="limiteFilas"> Limite de filas a retornar. </param>
        /// <returns> Lista de categorias encontradas. </returns>
        public List<CategoriaModelo> BuscarCategoria_PorNombre(string nombre, int limiteFilas = 10)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre de la categoria a buscar esta vacio o fue null.");
            }

            nombre = nombre.Trim();

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "select * from Categorias where Nombre like @Nombre limit @limiteFilas";

                var parametros = new { Nombre = '%' + nombre + '%', limiteFilas = limiteFilas };

                return conexion.Query<CategoriaModelo>(q, parametros).ToList();
            }
        }

        /// <summary>
        ///     Genera y retorna una lista de reportes de lotes.
        ///     Cada reporte contiene informacion como el id del lote adquerido, cuando se adquirio,
        ///     el producto del lote, inversion total, etc.
        /// </summary>
        /// <param name="filtro"> 
        ///     Objeto que contiene condiciones para generar los reportes. 
        /// </param>
        /// <param name="limiteFilas"> 
        ///     Limite de filas a retonar.
        ///     Util si los resultados se presentan al usuario.
        ///     Util si los para paginar los resultados.
        /// </param>
        /// <param name="comienzo">
        ///  Impone la condicion (Lotes.Id > comienzo) en el query.
        ///  Util para paginar los resultados.
        /// </param>
        /// <example>
        /// <code>
        /// var reportes1 = CargarReporteLotes(limiteFilas: 2, comienzo: null); // Carga los primeros dos lotes.
        /// var reportes1 = CargarReporteLotes(limiteFilas: 2, comienzo: reportes1.LastOrDefault()?.Id); // Carga los siguientes dos lotes.
        /// ...
        /// </code>
        /// </example>
        /// <returns> Una lista de reportes de lotes. </returns>
        public List<ReporteLoteModelo> CargarReporteLotes(ReporteFiltroModelo filtro = null, int? limiteFilas = null, int? comienzo = null)
        {
            var parametros = new DynamicParameters();

            var q = ConstruirQueryReporte
            (
                reporteTipo: typeof(ReporteLoteModelo),
                filtro: filtro,
                parametros: parametros,
                comienzo: comienzo,
                limiteFilas: limiteFilas
            );

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var reportes = conexion.Query<ReporteLoteModelo>(q, parametros).ToList();

                // Convertir representacion interna de la moneda a la representacion original.
                foreach (var reporte in reportes)
                {
                    reporte.InversionLote /= factorConversion;
                    reporte.PrecioVentaUnidad /= factorConversion;
                }

                return reportes;
            }
        }

        /// <summary>
        /// Carga y retorna una lista de productos cuyo nombre contiene el parametro 'nombre'.
        /// </summary>
        /// <param name="nombre"> Nombre del producto a buscar. </param>
        /// <param name="limiteFilas"> Limite de filas a retornar. </param>
        /// <returns> Los productos encontrados. </returns>
        public List<ProductoModelo> BuscarProducto_PorNombre(string nombre, int limiteFilas = 10)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre del producto a buscar no puede estar vacio.");
            }

            nombre = nombre.Trim();

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "select * from Productos where Nombre like @Nombre limit @limiteFilas";
                var parametros = new { Nombre = '%' + nombre + '%', limiteFilas = limiteFilas };
                return conexion.Query<ProductoModelo>(q, parametros).ToList();
            }
        }

        /// <summary>
        ///     Edita un producto en la base de datos.
        /// </summary>
        /// <param name="producto">
        ///     El producto a editar. Las propiedades de este producto se usaran
        ///     para sobreescribir las columnas correspondientes
        ///     de la fila correspondiente en la base de datos dada por la propiedad producto.Id.
        /// </param>
        public void EditarProducto(ProductoModelo producto)
        {
            producto.ValidarProducto();

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = @"update Productos set Nombre = @Nombre, Descripcion = @Descripcion where Id = @Id";
                var parametros = new { Nombre = producto.Nombre, Descripcion = producto.Descripcion, Id = producto.Id };

                conexion.Execute(q, parametros);

                if (producto.Categorias == null) return;

                producto.Categorias.ValidarCategorias();

                conexion.Open();
                using (var transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        q = "delete from ProductoCategoria where ProductoId = @ProductoId";
                        conexion.Execute(q, new { ProductoId = producto.Id });

                        q = @"insert into ProductoCategoria (productoId, CategoriaId)
                                        values (@ProductoId, @CategoriaId)";

                        foreach (var categoria in producto.Categorias)
                        {
                            conexion.Execute(q, new { ProductoId = producto.Id, CategoriaId = categoria.Id });
                        }

                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        ///     Carga y retorna las categorias de un producto especificando el id del producto.
        ///     Util cuando se carga un producto desde el metodo BuscarProducto_PorNombre
        ///     ya que es ineficiente cargar todas las categorias de todos los posibles
        ///     productos retornados por dicho metodo.
        /// </summary>
        /// <param name="id"> Id del producto. </param>
        /// <returns> Las categorias del producto cuyo id fue proporcionado. </returns>
        public List<CategoriaModelo> CargarCategorias_PorProductoId(int id)
        {
            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = @"select categorias.nombre, categorias.id from Categorias 
                        join ProductoCategoria on ProductoCategoria.CategoriaId = categorias.Id
                        where ProductoCategoria.ProductoId = @Id";
                return conexion.Query<CategoriaModelo>(q, new { Id = id }).ToList();
            }
        }

        /// <summary>
        /// Edita un lote de la base de datos.
        /// </summary>
        /// <param name="lote"> 
        ///     El lote a editar. Los valores lote.UnidadesDisponibles y lote.PrecioVentaUnidad
        ///     se usan para sobreescribir las respectivas columnas en la tabla lotes 
        ///     de la base de datos, en la respectiva fila identificada por lote.Id.
        ///     No se permite agregar mas unidades al lote, 
        ///     por lo que lote.UnidadesDisponibles debe ser menor o igual
        ///     al valor actual almacenado en la base de datos.
        /// </param>
        public void EditarLote(LoteModelo lote)
        {
            lote.ValidarLote();

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = @"update lotes set UnidadesDisponibles = @UnidadesDisponibles, 
                        PrecioVentaUnidad = @PrecioVentaUnidad where Id = @Id";

                var parametros = new
                {
                    UnidadesDisponibles = lote.UnidadesDisponibles,
                    PrecioVentaUnidad = ConvertirMonedaARepresentacionInterna(lote.PrecioVentaUnidad),
                    Id = lote.Id
                };

                conexion.Execute(q, parametros);
            }
        }

        /// <summary>
        /// Edita un cliente de la base de datos.
        /// </summary>
        /// <param name="cliente"> 
        ///     El cliente a editar.
        ///     Las propiedades en el objeto cliente proporcionado
        ///     se utilizan para sobreescribir las columnas respectivas
        ///     en la tabla clientes de la base de datos en la fila respectiva
        ///     identificada por el valor cliente.Id.
        /// </param>
        public void EditarCliente(ClienteModelo cliente)
        {
            cliente.ValidarCliente();

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = @"update clientes 
                          set Nombre = @Nombre, 
                              Apellido = @Apellido, 
                              NumeroContacto = @NumeroContacto
                          where Id = @Id";

                var parametros = new
                {
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    NumeroContacto = cliente.NumeroContacto,
                    Id = cliente.Id
                };

                conexion.Execute(q, parametros);
            }
        }

        public void populate()
        {
            SQLiteConnection con = new SQLiteConnection(stringConexion);

            SQLiteCommand cmd1 = new SQLiteCommand(@"insert into lotes(productoId, UnidadesDisponibles, UnidadesCompradas, FechaCreacion, inversion) 
                                                    values(1, 1, 1, 1, 13339)", con);

            con.Open();
            var trans = con.BeginTransaction();

            for (int i = 0; i < 10000; i++)
            {

                SQLiteCommand cmd2 = new SQLiteCommand($@"insert into productos (nombre, fechaCreacion) values ('producto{i}', 1) ", con);
                cmd2.ExecuteNonQuery();

                cmd1.ExecuteNonQuery();
                //SQLiteCommand cmd3 = new SQLiteCommand($@"insert into categorias (nombre) values ('categoria{i}') ", con);
                //cmd3.ExecuteNonQuery();

                SQLiteCommand cmd4 = new SQLiteCommand($@"insert into ventas (loteId, unidades, precioVentaUnidad, fecha) values (1, 1, 1, 1)", con);
                cmd4.ExecuteNonQuery();
            }

            trans.Commit();
            con.Close();
        }

        /// <summary>
        ///     Retorna un resumen de productos con informacion como Nombre, unidades disponibles, 
        ///     y el valor de estas unidades disponibles.
        /// </summary>
        /// <param name="filtro"> 
        ///     Objeto que contiene condiciones para generar los resumenes.
        ///     Condiciones como tipo de producto y/o categoria(s) de/los producto(s).
        /// </param>
        /// <param name="limiteFilas"> 
        ///     Limite de filas a retornar. Util para cuando se presenta la info al usuario o para paginar los resultados
        /// </param>
        /// <param name="comienzo"> 
        ///     Impone la condicion en la columna Productos.Id > comienzo.
        ///     Util para paginar los resultados.
        /// </param>
        /// <returns> La lista de los reportes generados. </returns>
        public List<ReporteInventarioModelo> CargarReporteInventario(ReporteFiltroModelo filtro, int? limiteFilas = null, int? comienzo = null)
        { 
            var parametros = new DynamicParameters();

            var q = ConstruirQueryReporte
            (
                reporteTipo: typeof(ReporteInventarioModelo),
                filtro: filtro,
                parametros: parametros,
                comienzo: comienzo,
                limiteFilas: limiteFilas
            );

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var reportes = conexion.Query<ReporteInventarioModelo>(q, parametros).ToList();

                // Convertir representacion interna de la moneda a la representacion original.
                foreach (var reporte in reportes)
                {
                    reporte.InversionUnidadesProducto /= factorConversion;
                }

                return reportes;
            }
        }

        /// <summary>
        /// Construye las condiciones necesarias de un query
        /// para generar el reporte de tipo <paramref name="reporteTipo"/>.
        /// </summary>
        /// <param name="reporteTipo"> Tipo de reporte. (ReporteVentaModelo, ReporteLoteModelo, ...)</param>
        /// <param name="filtro">
        /// Objeto principal de donde se generan las condiciones.
        /// Contiene condiciones para generar el query.
        /// </param>
        /// <param name="parametros">
        /// Objeto de la biblioteca Dapper que contiene los parametros del query.
        /// </param>
        /// <param name="comienzo">
        /// Util para paginar los resultados.
        /// </param>
        /// <returns> 
        /// Una string con el formato "where [condicion1] and [condicion2] and..."
        /// que representa las condiciones necesarias para generar un reporte de tipo <paramref name="reporteTipo"/>
        /// Si el filtro es null o no tiene condiciones, se retorna String.Empty.
        /// </returns>
        public string ConstruirCondicionesReporte(Type reporteTipo, ReporteFiltroModelo filtro, DynamicParameters parametros, int? comienzo)
        {
            var condiciones = new List<string>();

            if (filtro == null) return string.Empty;

            // Si se filtra por categorias del producto.
            if (filtro.Categorias != null && filtro.Categorias.Count > 0)
            {
                condiciones.Add(CondicionFiltroCategorias(parametros, filtro.Categorias));
            }

            var filtrarPorFechas = filtro.FechaInicial != null &&
                                    filtro.FechaFinal != null &&
                                    filtro.FiltroPorFechas &&
                                    reporteTipo != typeof(ReporteInventarioModelo);

            // Si se filtra por fecha de creacion.
            if (filtrarPorFechas)
            {
                if (reporteTipo == typeof(ReporteLoteModelo))
                {
                    condiciones.Add("Lotes.FechaCreacion BETWEEN @F1 AND @F2");
                }
                else if (reporteTipo == typeof(ReporteVentaModelo))
                {
                    condiciones.Add("Ventas.Fecha BETWEEN @F1 AND @F2");
                }
                parametros.Add("@F1", ((DateTimeOffset)filtro.FechaInicial).ToUnixTimeSeconds());
                parametros.Add("@F2", ((DateTimeOffset)filtro.FechaFinal).ToUnixTimeSeconds());
            }

            // Si se filtra por el tipo de producto.
            if (filtro.FiltroPorProducto && filtro.Producto != null)
            {
                if (filtrarPorFechas)
                {
                    condiciones.Add("(case when Productos.Id = @ProductoId then 1 end) = 1");
                }
                else
                {
                    condiciones.Add("Productos.Id = @ProductoId");
                }
                parametros.Add("@ProductoId", filtro.Producto.Id);
            }

            // Si solo se incluyen lotes con unidades disponibles.
            if (filtro.IncluirLotesSinUnidades == false && reporteTipo == typeof(ReporteLoteModelo))
            {
                condiciones.Add("Lotes.UnidadesDisponibles > 0");
            }

            // Si se filtra por las compras de cierto cliente.
            var filtrarPorCliente = filtro.FiltroPorCliente &&
                                    filtro.Cliente != null &&
                                    reporteTipo == typeof(ReporteVentaModelo);

            if (filtrarPorCliente)
            {
                condiciones.Add("Clientes.Id = @ClienteId");
                parametros.Add("@ClienteId", filtro.Cliente.Id);
            }

            // Util para paginar los resultados.
            if (comienzo != null)
            {
                if (reporteTipo == typeof(ReporteVentaModelo))
                {
                    // En el caso de reportes de ventas, se paginan los resultados
                    // en forma ascendente (ordenado por ventas.id).
                    // Util para presentar las ultimas ventas al usuario,
                    // en caso de que el usuario se haya equivocado en la venta.
                    // De esta manera el usuario obtiene facilmente el id de la ultima venta por ejemplo.
                    condiciones.Add("Ventas.Id < @Comienzo");
                }
                else if (reporteTipo == typeof(ReporteLoteModelo))
                {
                    condiciones.Add("Lotes.Id > @Comienzo");
                }
                else if (reporteTipo == typeof(ReporteInventarioModelo))
                {
                    condiciones.Add("Productos.Id > @Comienzo");
                }
                parametros.Add("@Comienzo", comienzo);
            }

            if (condiciones.Count < 1) return string.Empty;

            return " where " + string.Join(" and ", condiciones);
        }

        /// <summary>
        /// Construye el query final para generar un reporte de ventas,
        /// lotes o inventario.
        /// </summary>
        /// <param name="reporteTipo"> 
        /// Tipo de reporte. (ReporteVentaModelo, ReporteLoteModelo, ...) 
        /// </param>
        /// <param name="filtro"> 
        /// Objeto principal de donde se generan las condiciones.
        /// Contiene condiciones para generar el query.
        /// </param>
        /// <param name="parametros"> 
        /// Objeto de la biblioteca Dapper que contiene los parametros del query.
        /// </param>
        /// <param name="comienzo">
        /// Util para paginar los resultados.
        /// </param>
        /// <param name="limiteFilas">
        /// Limite de filas a retornar. 
        /// Util si los resultados se presentan al usuario.
        /// Util si se paginan los resultados.
        /// </param>
        /// <returns>
        /// El query final para generar el repote de tipo <paramref name="reporteTipo"/>
        /// </returns>
        public string ConstruirQueryReporte(Type reporteTipo, ReporteFiltroModelo filtro, DynamicParameters parametros, int? comienzo, int? limiteFilas)
        {
            string select = "";
            string ordenacion = "";
            string agrupacion = "";
            string limite = "-1";
            string condiciones = "";

            if (reporteTipo == typeof(ReporteLoteModelo))
            {
                select = @"select productos.Nombre as 'NombreProducto',
                                productos.Descripcion as 'DescripcionProducto',
                                lotes.PrecioVentaUnidad as 'PrecioVentaUnidad',
                                lotes.id as 'LoteId',
                                lotes.UnidadesCompradas as 'UnidadesCompradasLote',
                                lotes.UnidadesDisponibles as 'UnidadesDisponiblesLote',
                                lotes.Inversion as 'InversionLote',
                                datetime(lotes.FechaCreacion, 'unixepoch', 'localtime') as 'FechaAgregado'
                                from Productos
                                join lotes on lotes.ProductoId = productos.Id";

                ordenacion = "order by Lotes.Id asc";
            }
            else if (reporteTipo == typeof(ReporteVentaModelo))
            {
                select = @"select ventas.id as 'VentaId',
                            lotes.id as 'LoteId',
                            productos.nombre as 'NombreProducto',
                            ventas.Unidades as 'UnidadesVendidas',
                            lotes.Inversion 'InversionLote',
                            lotes.UnidadesCompradas as 'UnidadesCompradasLote',
                            ventas.PrecioVentaUnidad as 'PrecioVentaUnidad',
                            datetime(ventas.fecha, 'unixepoch', 'localtime') as 'FechaVenta',
                            clientes.Nombre || ' ' || coalesce(clientes.apellido, '') as 'NombreCliente'
                            from ventas
                            join lotes on lotes.id = ventas.LoteId
                            join productos on productos.id = lotes.ProductoId
                            left join Clientes on clientes.id = ventas.ClienteId";

                ordenacion = "order by Ventas.Id desc";
            }
            else if (reporteTipo == typeof(ReporteInventarioModelo))
            {
                select = @"select productos.id as 'ProductoId',
                        productos.nombre as 'NombreProducto',
                        productos.Descripcion as 'DescripcionProducto',
                        total(lotes.inversion / lotes.UnidadesCompradas * lotes.UnidadesDisponibles) as 'InversionUnidadesProducto',
                        sum(lotes.UnidadesDisponibles) as 'UnidadesProducto'
                        from Productos
                        left join lotes on lotes.ProductoId = productos.Id";

                agrupacion = "group by Productos.Id";
                ordenacion = "order by Productos.Id asc";
            }

            condiciones = ConstruirCondicionesReporte
            (
                reporteTipo: reporteTipo,
                filtro: filtro,
                parametros: parametros,
                comienzo: comienzo
            );

            if (limiteFilas != null)
            {
                limite = "limit @limiteFilas";
                parametros.Add("@limiteFilas", limiteFilas);
            }

            return $@"
                    { select }
                    { condiciones }
                    { agrupacion }
                    { ordenacion }
                    { limite }";
        }

        /// <summary>
        ///     Genera la condicion necesaria para encontrar los productos asociados
        ///     con todas las categorias proveidas.
        ///     Util cuando se generan reportes de ventas, lotes o inventario
        ///     ya que todos estos reportes poseen un producto.
        ///     Se tiene la intencion que la condicion generada se utilice como parte de otro query.
        /// </summary>
        /// <param name="parametros"> 
        ///     Ya que se asume que la condcion generada es parte de otro query
        ///     este objeto representa los parametros de tal query, el query principal por asi decir.
        ///     Por lo tanto el objeto se pasa por referencia para agregar los parametros generados aqui.
        /// </param>
        /// <param name="categorias"> Lista de categorias por las cuales se desea filtrar. </param>
        /// <returns> 
        ///     Una string sql que representa la condicion necesaria 
        ///     para encontrar los productos asociados con todas las categorias proveidas.
        /// </returns>
        string CondicionFiltroCategorias(DynamicParameters parametros, List<CategoriaModelo> categorias)
        {
            // Esta seccion construye un commando sql
            // del tipo 'select 1 as CategoriaId union select 2 union select 3...'
            // para crear la lista de ids de las categorias por las que se deben filtrar los productos
            // pero se utilizan parametros en vez de insertar los ids directamente en la string.
            // Nota: El nombre de los parametros es extraño solo para evitar
            // coliciones con algun otro parametro ya existente.

            var partes = new List<string>();
            partes.Add("select @FPCCATID0 as CategoriaId");
            parametros.Add("@FPCCATID0", categorias[0].Id);

            for (int i = 1; i < categorias.Count; i++)
            {
                var parametro = $"@FPCCATID{i}";
                partes.Add($"union select {parametro}");
                parametros.Add(parametro, categorias[i].Id);
            }

            ///     Magia negra para seleccionar solo productos
            ///     asociados con todas las categorias solicitadas.
            ///     https://stackoverflow.com/a/1330271
            return $@"(case when productos.id in 
                        (SELECT  *
                        FROM (
                                SELECT  DISTINCT ProductoCategoria.ProductoId
                                FROM    ProductoCategoria
                             ) mo
                        WHERE NOT EXISTS
                            (
                            SELECT  NULL
                            FROM (
                                    {string.Join(" ", partes)}
                                    ) filtro
                            WHERE   NOT EXISTS
                                    (
                                    SELECT  NULL
                                    FROM    ProductoCategoria
                                    WHERE   ProductoCategoria.ProductoId = mo.ProductoId
                                            AND ProductoCategoria.CategoriaId = filtro.CategoriaId
                                    )
                            )
                        ) then 1 end) = 1";
        }

        /// <summary>
        /// Carga y retorna una venta a partir del id especificado.
        /// </summary>
        /// <param name="id"> El id de la venta. </param>
        /// <returns> La venta si existe, null si no. </returns>
        public VentaModelo CargarVenta_PorId(int ventaId)
        {
            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = @"select v.Id,
                            v.Unidades,
                            v.PrecioVentaUnidad,
                            v.Comentario,
                            v.LoteId,
                            datetime(v.Fecha, 'unixepoch', 'localtime') as 'Fecha',
                            l.*,
                            p.*,
                            c.*
                            from ventas v
                            join lotes l on l.id = v.LoteId
                            join productos p on p.id = l.ProductoId
                            left join clientes c on c.id = v.ClienteId
                            where v.id = @ventaId";

                Func<VentaModelo, LoteModelo, ProductoModelo, ClienteModelo, VentaModelo> map =
                    (v, l, p, c) => { l.Producto = p; v.Lote = l; v.Cliente = c;  return v; };

                var parametros = new { ventaId = ventaId };

                var resultados = conexion.Query<VentaModelo, LoteModelo, ProductoModelo, ClienteModelo, VentaModelo>(q, map, parametros);

                var venta = resultados.FirstOrDefault();
                if (venta == null) return null;

                // Convertir moneda interna a representacion original.
                venta.PrecioVentaUnidad /= factorConversion;
                venta.Lote.Inversion /= factorConversion;
                venta.Lote.PrecioVentaUnidad /= factorConversion;

                return venta;
            }
        }

        /// <summary>
        /// Elimina una venta a partir del id proporcionado.
        /// </summary>
        /// <param name="id"> Id de la venta a eliminar. </param>
        public void EliminarVenta(int ventaId)
        {
            if (ventaId < 1)
            {
                throw new ArgumentException($"Id de la venta invalido: { ventaId }, el id no puede ser menor a 1.");
            }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                conexion.Open();
                using (var transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        var q = "select Unidades, LoteId from ventas where id = @id";
                        var resultados = conexion.Query(q, new { id = ventaId }).ToList();

                        if (resultados.Count < 1) return;

                        var info = (IDictionary<string, object>)resultados[0];

                        var unidadesVendidas = info["Unidades"];
                        var loteId = info["LoteId"];

                        q = @"update lotes 
                            set UnidadesDisponibles = UnidadesDisponibles + @UnidadesVendidas
                            where id = @Id";

                        conexion.Execute(q, new { UnidadesVendidas = unidadesVendidas, Id = loteId });

                        q = "delete from ventas where id = @Id";
                        conexion.Execute(q, new { Id = ventaId });
                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
