using Dapper;
using SivBiblioteca.Modelos;
using SivBiblioteca.Procesadores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace SivBiblioteca.AccesoDatos
{
    // todo - incluir procesadores para lotes, ventas?

    /// Nota - las fechas se guardan en tiempo unix UTC y se extraen como strings yyyy-mm-dd hh:mm:ss en tiempo local.
    /// Nota - Los precios se guardan en la base de datos como enteros.
    ///          Esto se realiza para guardar los precios con una precision fija.
    ///     
    /// Nota - Se utiliza 'case' en algunas condiciones de algunos queries
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
        readonly string stringConexion = ConfigGlobal.ConseguirStringConexion(id: "SqliteBd");

        /// <summary>
        /// Busca un producto o categoria o cliente por nombre.
        /// </summary>
        /// <typeparam name="T">El tipo de modelo a buscar.</typeparam>
        /// <param name="nombre">El nombre del modelo.</param>
        /// <param name="limite">Limite de filas a retonar.</param>
        /// <returns>Una lista de modelos cuyo nombre contiene <paramref name="nombre"/>.</returns>
        public List<T> BuscarModelo_PorNombre<T>(string nombre, int? limite = 10)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre a buscar esta vacio o fue null.");
            }

            nombre = nombre.Trim();

            string q;

            var modeloTipo = typeof(T);

            if (modeloTipo == typeof(ProductoModelo))
            {
                q = "select * from Productos where Nombre like @Nombre limit @limiteFilas";
            }
            else if (modeloTipo == typeof(CategoriaModelo))
            {
                q = "select * from Categorias where Nombre like @Nombre limit @limiteFilas";
            }
            else if (modeloTipo == typeof(ClienteModelo))
            {
                q = "select * from Clientes where (Nombre || ' ' || coalesce(Apellido, '')) like @Nombre limit @limiteFilas";
            }
            else return null;

            var parametros = new { Nombre = '%' + nombre + '%', limiteFilas = limite };

            using IDbConnection conexion = new SQLiteConnection(stringConexion);
            return conexion.Query<T>(q, parametros).ToList();
        }

        /// <summary>
        /// Revisa una categoria existe en la base de datos.
        /// </summary>
        /// <param name="nombreCategoria">Nombre de la categoria a buscar.</param>
        /// <returns><see langword="true"/> si existe, <see langword="false"/> si no.</returns>
        public bool CategoriaExiste(string nombreCategoria)
        {
            if (string.IsNullOrWhiteSpace(nombreCategoria))
            {
                throw new ArgumentException("El nombre de la categoria esta vacio o fue null.");
            }

            nombreCategoria = nombreCategoria.Trim();

            using IDbConnection conexion = new SQLiteConnection(stringConexion);

            var q = "select exists (select 1 from Categorias where Nombre = @Nombre)";

            return conexion.ExecuteScalar<bool>(q, new { Nombre = nombreCategoria });
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

            using IDbConnection conexion = new SQLiteConnection(stringConexion);

            var q = "insert into Categorias (Nombre) values (@Nombre)";

            foreach (var categoria in categorias)
            {
                conexion.Execute(q, categoria);
                categoria.Id = conexion.ExecuteScalar<int>("select max(id) from Categorias");
            }
        }

        /// <summary>
        /// Elimina de la base de datos una lista de categorias.
        /// </summary>
        /// <param name="categorias">Lista de categorias a eliminar.</param>
        public void EliminarCategorias(List<CategoriaModelo> categorias)
        {
            categorias.ValidarCategorias();

            using IDbConnection conexion = new SQLiteConnection(stringConexion);

            var q = "delete from Categorias where Id = @Id";
            conexion.Execute(q, categorias);
        }

        /// <summary>
        /// Guarda un producto en la base de datos.
        /// </summary>
        /// <param name="producto">Producto a guardar.</param>
        public void GuardarProducto(ProductoModelo producto)
        {
            producto.ValidarProducto(verificarQueNoExista: true);

            using IDbConnection conexion = new SQLiteConnection(stringConexion);

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

        /// <summary>
        /// Carga y retorna un lote de la base de datos a partir de su id.
        /// </summary>
        /// <param name="id">Id del lote.</param>
        /// <returns>El lote encontrado. Si no se encontro se retorna <see langword="null"/>.</returns>
        public LoteModelo CargarLote_PorId(int id)
        {
            using IDbConnection conexion = new SQLiteConnection(stringConexion);

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

            LoteModelo f(LoteModelo l, ProductoModelo p) { l.Producto = p; return l; }

            var lote = conexion.Query<LoteModelo, ProductoModelo, LoteModelo>(q, f, new { loteId = id }).FirstOrDefault();

            if (lote == null) return null;

            lote.Inversion = SqliteMoneda.ConvertirAOriginal(lote.Inversion);
            lote.PrecioVentaUnidad = SqliteMoneda.ConvertirAOriginal(lote.PrecioVentaUnidad);

            return lote;
        }

        /// <summary>
        /// Guarda una lista de ventas a la base de datos.
        /// </summary>
        /// <param name="ventas">Lista de ventas a guardar.</param>
        public void GuardarVentas(List<VentaModelo> ventas)
        {
            ventas.ValidarVentas();

            using IDbConnection conexion = new SQLiteConnection(stringConexion);
            conexion.Open();

            using var transaccion = conexion.BeginTransaction();

            try
            {
                var q = @"insert into ventas (LoteId, Unidades, PrecioVentaUnidad, ClienteId, Fecha)
                            values (@LoteId, @Unidades, @PrecioVentaUnidad, @ClienteId, strftime('%s', 'now'))";

                foreach (var venta in ventas)
                {
                    var parametros = new
                    {
                        LoteId = venta.Lote.Id,
                        Unidades = venta.Unidades,
                        PrecioVentaUnidad = SqliteMoneda.ConvertirAInterna(venta.PrecioVentaUnidad),
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

        /// <summary>
        /// Retorna las unidades disponibles de un lote.
        /// </summary>
        /// <param name="loteId">Id del lote.</param>
        /// <returns>Unidades restantes del lote. Si el lote no existe se retorna <see langword="null"/>.</returns>
        public int? UnidadesDisponiblesLote(int loteId)
        {
            using IDbConnection conexion = new SQLiteConnection(stringConexion);
            var q = "select UnidadesDisponibles from Lotes where Id = @Id";

            return conexion.ExecuteScalar<int?>(q, new { Id = loteId });
        }

        /// <summary>
        /// Guarda un cliente en la base de datos.
        /// </summary>
        /// <param name="cliente">El cliente a guardar.</param>
        public void GuardarCliente(ClienteModelo cliente)
        {
            cliente.ValidarCliente();

            using IDbConnection conexion = new SQLiteConnection(stringConexion);

            var q = "insert into Clientes (Nombre, Apellido, NumeroContacto) values (@Nombre, @Apellido, @NumeroContacto)";
            conexion.Execute(q, cliente);

            cliente.Id = conexion.ExecuteScalar<int>("select max(Id) from clientes;");
        }

        /// <summary>
        /// Carga y retorna el id del ultimo lote agregado a la base de datos.
        /// </summary>
        /// <returns>El id del ultimo lote agregado a la base de datos.</returns>
        public int CargarUltimoLoteId()
        {
            using IDbConnection conexion = new SQLiteConnection(stringConexion);
            return conexion.ExecuteScalar<int>("select max(Id) from Lotes");
        }

        /// <summary>
        /// Guarda un lote en la base de datos.
        /// </summary>
        /// <param name="lote">El lote a guardar.</param>
        public void GuardarLote(LoteModelo lote)
        {
            lote.ValidarLote();

            using IDbConnection conexion = new SQLiteConnection(stringConexion);

            var q = @"insert into Lotes (ProductoId, UnidadesCompradas, UnidadesDisponibles, Inversion, PrecioVentaUnidad, FechaCreacion)
                            values (@ProductoId, @UnidadesCompradas, @UnidadesDisponibles, @Inversion, @PrecioVentaUnidad, strftime('%s', 'now'))";

            lote.UnidadesDisponibles = lote.UnidadesCompradas;

            var parametros = new
            {
                ProductoId = lote.Producto.Id,
                UnidadesCompradas = lote.UnidadesCompradas,
                UnidadesDisponibles = lote.UnidadesDisponibles,
                Inversion = SqliteMoneda.ConvertirAInterna(lote.Inversion),
                PrecioVentaUnidad = SqliteMoneda.ConvertirAInterna(lote.PrecioVentaUnidad)
            };

            conexion.Execute(q, parametros);

            q = "select max(Id) from Lotes";
            lote.Id = conexion.ExecuteScalar<int>(q);
        }

        /// <summary>
        /// Revisa si un producto existe en la base de datos a partir del nombre proporcionado.
        /// </summary>
        /// <param name="nombre">El nombre del producto a buscar.</param>
        /// <returns><see langword="true"/> si el producto existe, <see langword="false"/> si no.</returns>
        public bool ProductoExiste(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre a buscar esta vacio o fue null.");
            }

            nombre = nombre.Trim();

            using IDbConnection conexion = new SQLiteConnection(stringConexion);
            var q = "select exists (select 1 from Productos where Nombre = @Nombre collate nocase)";

            return conexion.ExecuteScalar<bool>(q, new { Nombre = nombre });
        }

        /// <summary>
        /// Edita un producto en la base de datos.
        /// </summary>
        /// <param name="producto">
        ///     El producto a editar. Las propiedades de este producto se usaran
        ///     para sobreescribir las columnas correspondientes
        ///     de la fila correspondiente en la base de datos dada por la propiedad producto.Id.
        /// </param>
        public void EditarProducto(ProductoModelo producto)
        {
            producto.ValidarProducto();

            using IDbConnection conexion = new SQLiteConnection(stringConexion);
            var q = @"update Productos set Nombre = @Nombre, Descripcion = @Descripcion where Id = @Id";

            var parametros = new { Nombre = producto.Nombre, Descripcion = producto.Descripcion, Id = producto.Id };

            conexion.Execute(q, parametros);

            if (producto.Categorias == null) return;

            producto.Categorias.ValidarCategorias();

            conexion.Open();
            using var transaccion = conexion.BeginTransaction();

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

        /// <summary>
        /// Carga y retorna las categorias de un producto cuyo id es <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Id del producto.</param>
        /// <returns>Las categorias del producto.</returns>
        /// <remarks>
        /// Util cuando se carga un producto desde el metodo BuscarModelo_PorNombre
        /// ya que es ineficiente cargar todas las categorias de todos los posibles
        /// productos retornados por dicho metodo.
        /// </remarks>
        public List<CategoriaModelo> CargarCategorias_PorProductoId(int id)
        {
            using IDbConnection conexion = new SQLiteConnection(stringConexion);
            var q = @"select categorias.nombre, categorias.id from Categorias 
                        join ProductoCategoria on ProductoCategoria.CategoriaId = categorias.Id
                        where ProductoCategoria.ProductoId = @Id";

            return conexion.Query<CategoriaModelo>(q, new { Id = id }).ToList();
        }

        /// <summary>
        /// Edita un lote de la base de datos.
        /// </summary>
        /// <param name="lote"> 
        /// El lote a editar.
        /// </param>
        /// <remarks>
        /// Los valores lote.UnidadesDisponibles y lote.PrecioVentaUnidad
        /// se usan para sobreescribir las respectivas columnas en la tabla lotes 
        /// de la base de datos, en la respectiva fila identificada por lote.Id.
        /// No se permite agregar mas unidades al lote, 
        /// por lo que lote.UnidadesDisponibles debe ser menor o igual
        /// al valor actual almacenado en la base de datos.
        /// </remarks>
        public void EditarLote(LoteModelo lote)
        {
            lote.ValidarLote();

            using IDbConnection conexion = new SQLiteConnection(stringConexion);

            var q = @"update lotes set UnidadesDisponibles = @UnidadesDisponibles, 
                        PrecioVentaUnidad = @PrecioVentaUnidad where Id = @Id";

            var parametros = new
            {
                UnidadesDisponibles = lote.UnidadesDisponibles,
                PrecioVentaUnidad = SqliteMoneda.ConvertirAInterna(lote.PrecioVentaUnidad),
                Id = lote.Id
            };

            conexion.Execute(q, parametros);
        }

        /// <summary>
        /// Edita un cliente de la base de datos.
        /// </summary>
        /// <param name="cliente"> 
        ///     El cliente a editar.
        /// </param>
        /// <remarks>
        /// Las propiedades en el objeto cliente proporcionado
        /// se utilizan para sobreescribir las columnas respectivas
        /// en la tabla clientes de la base de datos en la fila respectiva
        /// identificada por el valor cliente.Id.
        /// </remarks>
        public void EditarCliente(ClienteModelo cliente)
        {
            cliente.ValidarCliente();

            using IDbConnection conexion = new SQLiteConnection(stringConexion);

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

        // todo - eliminar
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

        public List<T> CargarReporte<T>(ReporteFiltroModelo filtro = null, int? limiteFilas = null, int? comienzo = null)
        {
            var parametros = new DynamicParameters();

            var q = ConstruirQueryReporte<T>
            (
                filtro: filtro,
                parametros: parametros,
                comienzo: comienzo,
                limiteFilas: limiteFilas
            );

            List<T> reportes;

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                reportes = conexion.Query<T>(q, parametros).ToList();
            }

            IReporteProcesador procesador = null;

            if (reportes is List<ReporteLoteModelo> reportesLote)
            {
                procesador = new ReporteLoteProcesador(reportesLote);
            }

            if (reportes is List<ReporteVentaModelo> reportesVenta)
            {
                procesador = new ReporteVentaProcesador(reportesVenta);
            }

            if (reportes is List<ReporteInventarioModelo> reportesInventario)
            {
                procesador = new ReporteInventarioProcesador(reportesInventario);
            }

            procesador.Procesar();

            return reportes;
        }

        /// <summary>
        /// Construye las condiciones necesarias de un query
        /// para generar el reporte de tipo <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">Tipo de reporte.</typeparam>
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
        /// que representa las condiciones necesarias para generar un reporte de tipo <typeparamref name="T"/>.
        /// Si el filtro es null o no tiene condiciones, se retorna String.Empty.
        /// </returns>
        public string ConstruirCondicionesReporte<T>(ReporteFiltroModelo filtro, DynamicParameters parametros, int? comienzo)
        {
            if (filtro == null) return string.Empty;

            var reporteTipo = typeof(T);

            var condiciones = new List<string>();

            // Si se filtra por categorias del producto.
            if (filtro.Categorias != null && filtro.Categorias.Count > 0)
            {
                condiciones.Add(CondicionFiltroCategorias(parametros, filtro.Categorias));
            }


            // Si se filtra por fecha de creacion.

            var filtrarPorFechas = filtro.FiltroPorFechas &&
                                    reporteTipo != typeof(ReporteInventarioModelo);

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

            // Si solo se incluyen lotes con unidades disponibles en un reporte de lotes.

            var incluirLotesSinUnidades = filtro.IncluirLotesSinUnidades == false &&
                                            reporteTipo == typeof(ReporteLoteModelo);

            if (incluirLotesSinUnidades)
            {
                condiciones.Add("Lotes.UnidadesDisponibles > 0");
            }

            // Si solo se incluyen productos con unidades disponibles en un reporte de inventario.

            var incluirProductosSinUnidades = filtro.IncluirProductosSinUnidades == false &&
                                                reporteTipo == typeof(ReporteInventarioModelo);

            if (incluirProductosSinUnidades)
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
        /// <typeparam name="T">Tipo de reporte.</typeparam>
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
        public string ConstruirQueryReporte<T>(ReporteFiltroModelo filtro, DynamicParameters parametros, int? comienzo, int? limiteFilas)
        {
            string select = "";
            string ordenacion = "";
            string agrupacion = "";
            string limite = "limit -1";

            var reporteTipo = typeof(T);

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

            string condiciones = ConstruirCondicionesReporte<T>
            (
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
        /// Genera la condicion necesaria para encontrar los productos asociados
        /// con todas las categorias proveidas.
        /// </summary>
        /// <remarks>
        /// Util cuando se generan reportes de ventas, lotes o inventario
        /// ya que todos estos reportes poseen un producto.
        /// Se tiene la intencion que la condicion generada se utilice como parte de otro query.
        /// </remarks>
        /// <param name="parametros"> 
        /// Ya que se asume que la condcion generada es parte de otro query
        /// este objeto representa los parametros de tal query, el query principal por asi decir.
        /// Por lo tanto el objeto se pasa por referencia para agregar los parametros generados aqui.
        /// </param>
        /// <param name="categorias">Lista de categorias por las cuales se desea filtrar.</param>
        /// <returns> 
        /// Una string sql que representa la condicion necesaria 
        /// para encontrar los productos asociados con todas las categorias proveidas.
        /// </returns>
        string CondicionFiltroCategorias(DynamicParameters parametros, List<CategoriaModelo> categorias)
        {
            // Esta seccion construye un commando sql
            // del tipo 'select 1 as CategoriaId union select 2 union select 3...'
            // para crear la lista de ids de las categorias por las que se deben filtrar los productos
            // pero se utilizan parametros en vez de insertar los ids directamente en la string.
            // Nota: El nombre de los parametros es extraño solo para evitar
            // coliciones con algun otro parametro ya existente.

            var partes = new List<string>
            {
                "select @FPCCATID0 as CategoriaId"
            };

            parametros.Add("@FPCCATID0", categorias[0].Id);

            for (int i = 1; i < categorias.Count; i++)
            {
                var parametro = $"@FPCCATID{ i }";
                partes.Add($"union select { parametro }");
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
                                    { string.Join(" ", partes) }
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
        /// <param name="id">El id de la venta.</param>
        /// <returns>La venta si existe, <see langword="null"/> si no. </returns>
        public VentaModelo CargarVenta_PorId(int ventaId)
        {
            using IDbConnection conexion = new SQLiteConnection(stringConexion);

            var q = @"select v.Id,
                            v.Unidades,
                            v.PrecioVentaUnidad,
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

            VentaModelo map(VentaModelo v, LoteModelo l, ProductoModelo p, ClienteModelo c) { l.Producto = p; v.Lote = l; v.Cliente = c; return v; }

            var parametros = new { ventaId = ventaId };

            var resultados = conexion.Query<VentaModelo, LoteModelo, ProductoModelo, ClienteModelo, VentaModelo>(q, map, parametros);

            var venta = resultados.FirstOrDefault();

            if (venta == null) return null;

            venta.PrecioVentaUnidad = SqliteMoneda.ConvertirAOriginal(venta.PrecioVentaUnidad);
            venta.Lote.Inversion = SqliteMoneda.ConvertirAOriginal(venta.Lote.Inversion);
            venta.Lote.PrecioVentaUnidad = SqliteMoneda.ConvertirAOriginal(venta.Lote.PrecioVentaUnidad);

            return venta;
        }

        /// <summary>
        /// Elimina una venta cuyo id es <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Id de la venta a eliminar.</param>
        public void EliminarVenta(int id)
        {
            using IDbConnection conexion = new SQLiteConnection(stringConexion);

            conexion.Open();
            using var transaccion = conexion.BeginTransaction();

            try
            {
                var q = "select Unidades, LoteId from ventas where id = @id";

                var resultados = conexion.Query(q, new { id = id }).ToList();

                if (resultados.Count < 1) return;

                var info = (IDictionary<string, object>)resultados[0];

                var unidadesVendidas = info["Unidades"];
                var loteId = info["LoteId"];

                q = @"update lotes 
                            set UnidadesDisponibles = UnidadesDisponibles + @UnidadesVendidas
                            where id = @Id";

                conexion.Execute(q, new { UnidadesVendidas = unidadesVendidas, Id = loteId });

                q = "delete from ventas where id = @Id";

                conexion.Execute(q, new { Id = id });

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
