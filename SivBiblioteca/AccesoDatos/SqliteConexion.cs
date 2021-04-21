using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SivBiblioteca.Modelos;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace SivBiblioteca.AccesoDatos
{
    // TODO - preparar pruebas?

    /// Nota - las fechas se guardan en tiempo unix UTC y se extraen como strings yyyy-mm-dd hh:mm:ss en tiempo local.
    /// Nota - Los precios se guardan en la base de datos como enteros.
    ///          Esto se realiza para guardar los precios con una precision fija.
    ///     
    /// Nota - Se utiliza 'case' en algunas condiciones de algunos query
    /// usualmente para obtener un 'mejor' query plan.
    /// 
    /// ej. En el metodo CargarReporteVentas, si se filtra por fecha de venta 
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
    /// Lo mismo sucede en el metodo CargarReporteLotes.

    ///  https://stackoverflow.com/a/49861947

    ///  Ni idea si el plan del query sin case se debe a una estructura del query pobre, o un diseno pobre de las tablas lol
    ///  ¯\_(ツ)_/¯
    public class SqliteConexion : IConexionDatos
    {
        string stringConexion = ConfigGlobal.ConseguirStringConexion("SqliteBd");

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
        static int FactorConversion = Convert.ToInt32(Math.Pow(10, MonedaPrecision));

        // El precio o valor maximo que se puede representar en la base de datos.
        static decimal MonedaMaximo = Int64.MaxValue / FactorConversion;

        /// <summary>
        /// Revisa si la categoria existe en la base de datos.
        /// </summary>
        /// <param name="nombreCategoria"> Nombre de la categoria a buscar. </param>
        /// <returns> true si existe, false si no. </returns>
        public bool CategoriaExiste(string nombreCategoria)
        {
            nombreCategoria = nombreCategoria.Trim();
            if (string.IsNullOrEmpty(nombreCategoria)) { return false; }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {               
                var q = "select exists (select 1 from Categorias where Nombre = @Nombre collate nocase)";
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
            if (categorias == null)
            {
                throw new ArgumentException("Lista de categorias es nula.");
            }

            foreach (var categoria in categorias)
            {
                if (categoria == null)
                {
                    throw new ArgumentException("Al menos una categoria en la lista fue null.");
                }

                categoria.Nombre = categoria.Nombre.Trim();

                if (string.IsNullOrEmpty(categoria.Nombre))
                {
                    throw new ArgumentException("Al menos una categoria sin nombre.");
                }
            }

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
            if (categorias == null)
            {
                throw new ArgumentException("Lista de categorias es nula.");
            }

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
            if (producto == null)
            {
                throw new ArgumentException("El producto fue null.");
            }

            producto.Nombre = producto.Nombre.Trim();

            if (string.IsNullOrEmpty(producto.Nombre))
            {
                throw new ArgumentException("El nombre del producto no puede estar vacio.");
            }

            if (ProductoExiste(producto.Nombre))
            {
                throw new ArgumentException("El nombre del producto ya existe en la base de datos.");
            }
                     
            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = @"insert into productos (Nombre, FechaCreacion, Descripcion)
                            values (@Nombre, strftime('%s', 'now'), @Descripcion)";

                conexion.Execute(q, 
                    new
                    {
                        Nombre = producto.Nombre,
                        Descripcion = producto.Descripcion
                    }
                );

                producto.Id = conexion.ExecuteScalar<int>("select max(Id) from Productos");

                if (producto.Categorias != null)
                {
                    q = "insert into ProductoCategoria (ProductoId, CategoriaId) values (@ProductoId, @CategoriaId)";
                    foreach (var categoria in producto.Categorias)
                    {
                        conexion.Execute(q, new { ProductoId = producto.Id, CategoriaId = categoria.Id });
                    }
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
            return Convert.ToInt64(decimal.Truncate(x * FactorConversion));
        }

        /// <summary>
        ///     Carga y retorna un lote de la base de datos a partir de su id.
        /// </summary>
        /// <param name="id"> Id del lote. </param>
        /// <returns> El lote. Si no se encontro se retorna un lote null. </returns>
        public LoteModelo CargarLote_PorId(int id)
        {
            LoteModelo lote = null;

            if (id < 1)
            {
                throw new ArgumentException($"Id del lote invalido. Id: { id }, el id no debe ser menor a 1");
            }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = $@"select Id, ProductoId, UnidadesCompradas, UnidadesDisponibles, 
                            Inversion, PrecioVentaUnidad,
                            datetime(FechaCreacion, 'unixepoch', 'localtime') as 'FechaCreacion'
                            from lotes where id = @Id";

                lote = conexion.QuerySingleOrDefault<LoteModelo>(q, new { Id = id });
                if (lote != null)
                {
                    lote.Producto = conexion.QuerySingle<ProductoModelo>("select * from productos where id = @ID", new { ID = lote.ProductoId });
                    lote.Inversion = lote.Inversion / FactorConversion;
                    lote.PrecioVentaUnidad = lote.PrecioVentaUnidad / FactorConversion;
                }       
            }
            return lote;
        }

        /// <summary>
        ///     Guarda una lista de ventas a la base de datos.
        /// </summary>
        /// <param name="ventas"> Lisa de ventas a guardar. </param>
        public void GuardarVentas(List<VentaModelo> ventas)
        {
            if (ventas == null)
            {
                throw new ArgumentException("La lista de ventas fue null.");
            }

            // Validar campos de la venta
            foreach (var venta in ventas)
            {
                if (venta == null)
                {
                    throw new ArgumentException("Al menos una venta en la lista fue null.");
                }
                if (venta.Unidades < 1)
                {
                    throw new Exception($"Unidades solicitadas invalidas: {venta.Unidades}, el valor debe ser positivo.");
                }
                if (venta.Total < 0)
                {
                    throw new Exception($"Total de la venta invalido: {venta.Total}, solo valores no negativos.");
                }
                if (venta.Lote == null)
                {
                    throw new ArgumentException("El lote de la venta fue null.");
                }
                if (venta.Unidades > UnidadesDisponiblesLote(venta.Lote.Id))
                {
                    throw new Exception($"El numero de unidades solicitadas (unidades a vender) sobrepasa las disponibles en el lote.");
                }
            }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = @"insert into ventas (LoteId, Unidades, PrecioVentaUnidad, Comentario, ClienteId, Fecha)
                            values (@LoteId, @Unidades, @PrecioVentaUnidad, @Comentario, @ClienteId, strftime('%s', 'now'))";

                conexion.Open();
                using (var transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        foreach (var venta in ventas)
                        {
                            conexion.Execute(q,
                                new
                                {
                                    LoteId = venta.Lote.Id,
                                    Unidades = venta.Unidades,
                                    PrecioVentaUnidad = ConvertirMonedaARepresentacionInterna(venta.PrecioVentaUnidad),
                                    Comentario = venta.Comentario,
                                    ClienteId = venta.ClienteId
                                }
                            );
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
        /// <returns> Unidades restantes del lote. </returns>
        public int UnidadesDisponiblesLote(int loteId)
        {
            if (loteId < 1)
            {
                throw new ArgumentException($"Id del lote invalido: { loteId }, el id no debe ser menor a 1.");
            }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "select UnidadesDisponibles from Lotes where Id = @Id";
                return conexion.ExecuteScalar<int>(q, new { Id = loteId });
            }
        }

        /// <summary>
        ///     Guarda un cliente en la base de datos.
        /// </summary>
        /// <param name="cliente"> El cliente. </param>
        public void GuardarCliente(ClienteModelo cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentException("El cliente fue null.");
            }

            cliente.Nombre = cliente.Nombre.Trim();

            if (string.IsNullOrEmpty(cliente.Nombre))
            {
                throw new ArgumentException("Nombre del cliente vacio.");
            }
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
        /// <param name="nombre"> El nombre a buscar. </param>
        /// <returns> Lista de clientes encontrados. </returns>
        public List<ClienteModelo> BuscarCliente_PorNombre(string nombre)
        {
            nombre = nombre.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentException("El nombre a buscar no puede estar vacio.");
            }
            
            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "select * from Clientes where (Nombre || ' ' || coalesce(Apellido, '')) like @Nombre";
                return conexion.Query<ClienteModelo>(q, new { Nombre = '%' + nombre + '%'}).ToList();
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
        ///     o para paginar las ventas.
        /// </param>
        /// <param name="comienzo">
        ///     Impone la condicion ventas.id > comienzo.
        ///     Util para cuando se paginan las ventas.
        ///     Con este parametro y el parametro 'limiteFilas',
        ///     se puede implementar paginacion de las ventas.
        ///     ej. CargarReporteVentas(limiteFilas: 1000, comienzo: 0),
        ///     carga las primeras 1000 ventas.
        ///     Luego CargarReporteVentas(limiteFilas: 1000, comienzo: [id de la ultima venta])
        ///     carga las siguientes 1000 ventas.
        /// </param>
        /// <returns> Lista de reportes. </returns>
        public List<ReporteVentaModelo> CargarReporteVentas(ReporteFiltroModelo filtro = null, int? limiteFilas = null, int? comienzo = null)
        {
            var parametros = new DynamicParameters();

            var q = @"select lotes.id as 'LoteId', productos.nombre as 'NombreProducto', 
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

            // Contendran los joins y condiciones necesarios
            // para cumplir con las condiciones del filtro.
            var joins = new List<string>();
            var condiciones = new List<string>();

            if (filtro != null)
            {
                var filtrarPorFechas = filtro.FechaInicial != null && filtro.FechaFinal != null && filtro.FiltroPorFechas;

                // Si se filtra por fecha de venta.
                if (filtrarPorFechas)
                {                  
                    condiciones.Add("ventas.fecha BETWEEN @F1 AND @F2");
                    parametros.Add("@F1", ((DateTimeOffset)filtro.FechaInicial).ToUnixTimeSeconds());
                    parametros.Add("@F2", ((DateTimeOffset)filtro.FechaFinal).ToUnixTimeSeconds());
                }

                // Si se filtra por tipo de producto.
                if (filtro.FiltroPorProducto && filtro.Producto != null)
                { 
                    if (filtrarPorFechas)
                    {
                        condiciones.Add("(case when productos.id = @ProductoId then 1 end) = 1");
                    }
                    else
                    {
                        condiciones.Add("productos.id = @ProductoId");
                    }
                    parametros.Add("@ProductoId", filtro.Producto.Id);
                }

                // Si se filtra por categorias del producto.
                if (filtro.Categorias != null && filtro.Categorias.Count > 0)
                {
                    condiciones.Add(CondicionFiltroCategorias(parametros, filtro.Categorias));
                }

                // Si se filtra por las compras de cierto cliente.
                if (filtro.FiltroPorCliente && filtro.Cliente != null)
                {
                    condiciones.Add("clientes.id = @ClienteId");
                    parametros.Add("@ClienteId", filtro.Cliente.Id);
                }
            }

            // Agregar los diferentes joins al query.
            if (joins.Count > 0)
            {
                q += " " + string.Join(" ", joins);
            }

            if (comienzo != null)
            {
                condiciones.Add("ventas.id > @Comienzo");
                parametros.Add("@Comienzo", comienzo);
            }

            // Agregar las condiciones al query.
            if (condiciones.Count > 0)
            {
                q += " where ";
                q += string.Join(" and ", condiciones);
            }

            q += " order by ventas.Fecha";

            // Agregar el limite de filas a retornar.
            if (limiteFilas != null && limiteFilas > -1)
            {
                q += $" limit @Limite";
                parametros.Add("@Limite", limiteFilas);
            }

            // Generar reporte.
            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {                
                var reportes = conexion.Query<ReporteVentaModelo>(q, parametros).ToList();

                // Convertir representacion interna de la moneda a la representacion original.
                foreach (var reporte in reportes)
                {
                    reporte.InversionLote /= FactorConversion;
                    reporte.PrecioVentaUnidad /= FactorConversion;
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
            // Validar lote

            if (lote == null)
            {
                throw new ArgumentException("El lote fue null.");
            }

            if (lote.Producto == null)
            {
                throw new ArgumentException("El producto del lote fue null.");
            }

            if (lote.Producto.Id < 1)
            {
                throw new ArgumentException($"Id de producto invalido: {lote.Producto.Id}, el id deber ser mayor a 0.");
            }

            if (lote.UnidadesCompradas < 1)
            {
                throw new ArgumentException($"Unidades invalidas: {lote.UnidadesCompradas}, las unidades deben ser positivas.");
            }

            if (lote.Inversion < 0)
            {
                throw new ArgumentException($"Inversion invalida: {lote.Inversion}, la inversion no debe ser negativa.");
            }

            if (lote.PrecioVentaUnidad < 0)
            {
                throw new ArgumentException($"Precio de venta invalido: {lote.PrecioVentaUnidad}, el precio de venta por unidad no debe ser negativo.");
            }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = @"insert into Lotes (ProductoId, UnidadesCompradas, UnidadesDisponibles, Inversion, PrecioVentaUnidad, FechaCreacion)
                            values (@ProductoId, @UnidadesCompradas, @UnidadesDisponibles, @Inversion, @PrecioVentaUnidad, strftime('%s', 'now'))";

                long inversion;
                long precioVenta;

                // Validar que la inversion del lote no sea demasiado grande.
                try
                {
                    inversion = ConvertirMonedaARepresentacionInterna(lote.Inversion);
                }
                catch (OverflowException)
                {
                    throw new Exception($"El valor de la inversión es demasiado grande. Valor máximo: { MonedaMaximo }");
                }

                // Validar que el precio de venta de las unidades no se demasiado grande.
                try
                {
                    precioVenta = ConvertirMonedaARepresentacionInterna(lote.PrecioVentaUnidad);
                }
                catch (OverflowException)
                {
                    throw new Exception($"El precio de venta de la unidad es demasiado grande. Precio máximo: { MonedaMaximo }");
                }

                lote.UnidadesDisponibles = lote.UnidadesCompradas;

                // Guardar lote.
                conexion.Execute(q, new
                {
                    ProductoId = lote.Producto.Id,
                    UnidadesCompradas = lote.UnidadesCompradas,
                    UnidadesDisponibles = lote.UnidadesDisponibles,
                    Inversion = inversion,
                    PrecioVentaUnidad = precioVenta
                });

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
            nombre = nombre.Trim();
            if (string.IsNullOrEmpty(nombre)) { return false; }

            bool resultado = false;

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "select exists (select 1 from Productos where Nombre = @Nombre collate nocase)";
                resultado = conexion.ExecuteScalar<bool>(q, new { Nombre = nombre });
            }
            return resultado;
        }

        /// <summary>
        ///     Carga y retorna una lista de categorias de la base de datos
        ///     cuyos nombres contienen el parametro 'nombre'.
        /// </summary>
        /// <param name="nombre"> Nombre a buscar. </param>
        /// <returns> Lista de categorias encontradas. </returns>
        public List<CategoriaModelo> BuscarCategoria_PorNombre(string nombre)
        {
            nombre = nombre.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentException("El nombre de la categoria a buscar no puede estar vacio.");
            }
            
            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "select * from Categorias where Nombre like @Nombre";
                return conexion.Query<CategoriaModelo>(q, new { Nombre = '%' + nombre + '%' }).ToList();
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
        /// </param>
        /// <returns> Una lista de reportes. </returns>
        public List<ReporteLoteModelo> CargarReporteLotes(ReporteFiltroModelo filtro = null, int? limiteFilas = null, int? comienzo = null)
        {
            var parametros = new DynamicParameters();

            var q = @"select productos.Nombre as 'NombreProducto',
                    productos.Descripcion as 'DescripcionProducto',
                    lotes.PrecioVentaUnidad as 'PrecioVentaUnidad',
                    lotes.id as 'LoteId',
                    lotes.UnidadesCompradas as 'UnidadesCompradasLote',
                    lotes.UnidadesDisponibles as 'UnidadesDisponiblesLote',
                    lotes.Inversion as 'InversionLote',
                    datetime(lotes.FechaCreacion, 'unixepoch', 'localtime') as 'FechaAgregado'
                    from Productos
                    join lotes on lotes.ProductoId = productos.Id";

            // Contendran los joins y condiciones necesarios
            // para cumplir con las condiciones del filtro y generar el query apropiado.
            var joins = new List<string>();
            var condiciones = new List<string>();

            if (filtro != null)
            {
                // Si se filtra por las categorias de los productos asociados con los lotes.
                if (filtro.Categorias != null && filtro.Categorias.Count > 0)
                {                    
                    condiciones.Add(CondicionFiltroCategorias(parametros, filtro.Categorias));
                }

                var filtrarPorFechas = filtro.FechaInicial != null && filtro.FechaFinal != null && filtro.FiltroPorFechas;

                // Si se filtra por fecha de agregado al inventario.
                if (filtrarPorFechas)
                {
                    condiciones.Add("lotes.FechaCreacion BETWEEN @F1 AND @F2");
                    parametros.Add("@F1", ((DateTimeOffset)filtro.FechaInicial).ToUnixTimeSeconds());
                    parametros.Add("@F2", ((DateTimeOffset)filtro.FechaFinal).ToUnixTimeSeconds());
                }

                // Si se filtra por el tipo de producto.
                if (filtro.FiltroPorProducto && filtro.Producto != null)
                {
                    if (filtrarPorFechas)
                    {
                        condiciones.Add("(case when productos.id = @ProductoId then 1 end) = 1");
                    }
                    else
                    {
                        condiciones.Add("productos.id = @ProductoId");
                    }                    
                    parametros.Add("@ProductoId", filtro.Producto.Id);
                }

                if (filtro.IncluirLotesSinUnidades == false)
                {
                    condiciones.Add("lotes.UnidadesDisponibles > 0");
                }
            }

            // Agregar joins necesarios al query.
            if (joins.Count > 0)
            {
                q += " " + string.Join(" ", joins);
            }

            if (comienzo != null)
            {
                condiciones.Add("lotes.id > @Comienzo");
                parametros.Add("@Comienzo", comienzo);
            }

            // Agregar condiciones necesarias al query.
            if (condiciones.Count > 0)
            {
                q += " where ";
                q += string.Join(" and ", condiciones);
            }

            q += " order by lotes.FechaCreacion";

            // Agregar el limte de filas a retornar.
            if (limiteFilas != null)
            {
                q += $" limit @Limite";
                parametros.Add("@Limite", limiteFilas);
            }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var reportes = conexion.Query<ReporteLoteModelo>(q, parametros).ToList();

                foreach (var reporte in reportes)
                {
                    reporte.InversionLote = reporte.InversionLote / FactorConversion;
                    reporte.PrecioVentaUnidad = reporte.PrecioVentaUnidad / FactorConversion;
                }

                return reportes;
            }
        }

        /// <summary>
        /// Carga y retorna una lista de productos cuyo nombre contiene el parametro 'nombre'.
        /// </summary>
        /// <param name="nombre"> Nombre del producto a buscar. </param>
        /// <returns> Los productos encontrados. </returns>
        public List<ProductoModelo> BuscarProducto_PorNombre(string nombre)
        {
            nombre = nombre.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentException("El nombre del producto a buscar no puede estar vacio.");
            }
            
            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "select * from Productos where Nombre like @Nombre";
                return conexion.Query<ProductoModelo>(q, new { Nombre = '%' + nombre + '%' }).ToList();
            }
        }

        /// <summary>
        ///     Edita un producto en la base de datos.
        /// </summary>
        /// <param name="producto">
        ///     El producto a editar. Las propiedades de este producto se usaran
        ///     para sobreescribir las columnas correspondientes en la base de datos
        ///     de la fila correspondiente dada por la propiedad producto.Id.
        /// </param>
        public void EditarProducto(ProductoModelo producto)
        {
            if (producto == null)
            {
                throw new ArgumentException($"El producto fue null.");
            }

            if (producto.Id < 1)
            {
                throw new ArgumentException($"Id del producto invalido: {producto.Id}, el id no puede ser menor a 1");
            }

            producto.Nombre = producto.Nombre.Trim();
            producto.Descripcion = producto.Descripcion.Trim();

            if (string.IsNullOrEmpty(producto.Nombre))
            {
                throw new ArgumentException("El nombre del producto no puede estar vacio.");
            }

            // Editar producto.
            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = @"update Productos set Nombre = @Nombre, Descripcion = @Descripcion where Id = @Id";
                conexion.Execute(q, new { Nombre = producto.Nombre, Descripcion = producto.Descripcion, Id = producto.Id });

                conexion.Open();
                using (var transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        q = "delete from ProductoCategoria where ProductoId = @Id";
                        conexion.Execute(q, new { Id = producto.Id});

                        q = @"insert into ProductoCategoria (productoId, CategoriaId)
                                values (@ProductoId, @CategoriaId)";

                        if (producto.Categorias != null)
                        {
                            foreach (var categoria in producto.Categorias)
                            {
                                if (categoria == null) continue;
                                conexion.Execute(q, new { ProductoId = producto.Id, CategoriaId = categoria.Id });
                            }
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
            if (id < 1)
            {
                throw new ArgumentException($"Id del producto invalido: { id }, el id no debe ser menor a 1.");
            }

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
        ///     No se permite agregar mas unidades al lote, por lo que lote.UnidadesDisponibles debe ser menor o igual
        ///     al valor actual almacenado en la base de datos.
        /// </param>
        public void EditarLote(LoteModelo lote)
        {
            // Validar argumentos.

            if (lote == null)
            {
                throw new ArgumentException("El lote proporcionado fue null.");
            }
            if (lote.Id < 1)
            {
                throw new ArgumentException($"Id del lote invalido: { lote.Id }, el id no puede ser menor a 1.");
            }
            if (lote.UnidadesDisponibles < 0)
            {
                throw new ArgumentException($"Unidades disponibles invalidas: { lote.UnidadesDisponibles }, la cantidad no puede ser negativa.");
            }
            if (lote.PrecioVentaUnidad < 0)
            {
                throw new ArgumentException($"Precio de venta por unidad invalido: { lote.PrecioVentaUnidad}, el precio no puede ser negativo.");
            }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                // Cargar unidades disponibles del lote desde la base de datos.
                var q = @"select UnidadesDisponibles from lotes where Id = @Id";
                var unidadesDisponibles = conexion.ExecuteScalar<int>(q, new { Id = lote.Id });

                // Validar que no se agreguen mas unidades al lote.
                if (lote.UnidadesDisponibles > unidadesDisponibles)
                {
                    throw new ArgumentException($@"Unidades disponibles solicitadas invalidas.
                                                    La cantidad de unidades disponibles solicitada es mayor a la cantidad de unidades disponibles en la base de datos.
                                                    Cantidad solicitada: { lote.UnidadesDisponibles }, cantidad en la base de datos: { unidadesDisponibles }.
                                                    No se permite agregar unidades al lote.");
                }

                // Editar lote.
                q = @"update lotes set UnidadesDisponibles = @UnidadesDisponibles, 
                        PrecioVentaUnidad = @PrecioVentaUnidad where Id = @Id";
                conexion.Execute(q, 
                    new
                    { UnidadesDisponibles = lote.UnidadesDisponibles,
                        PrecioVentaUnidad = ConvertirMonedaARepresentacionInterna(lote.PrecioVentaUnidad),
                        Id = lote.Id
                    });               
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
           if (cliente == null)
            {
                throw new ArgumentException("El cliente fue null.");
            }

            cliente.Nombre = cliente.Nombre.Trim();

            if (string.IsNullOrEmpty(cliente.Nombre))
            {
                throw new ArgumentException("El nombre del cliente no puede estar vacio.");
            }
            if (cliente.Id < 1)
            {
                throw new ArgumentException($"Id del cliente invalido: { cliente.Id }, el id no debe ser menor a 1.");
            }

            // Editar cliente.
            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = @"update clientes set Nombre = @Nombre, NumeroContacto = @NumeroContacto
                            where Id = @Id";

                var parametros = new { Nombre = cliente.Nombre, NumeroContacto = cliente.NumeroContacto, Id = cliente.Id };

                conexion.Execute(q, parametros);
            }
        }

        public void lotes_insert_fast()
        {
            SQLiteConnection con = new SQLiteConnection(stringConexion);

            SQLiteCommand cmd = new SQLiteCommand(@"insert into lotes(productoId, UnidadesDisponibles, UnidadesCompradas, FechaCreacion, inversion) 
                                                    values(1, 1, 1, 1, 9223372036854775807)", con);

            con.Open();
            var trans = con.BeginTransaction();

            for (int i = 0; i < 100000; i++)
            {
                cmd.ExecuteNonQuery();
            }

            trans.Commit();
            con.Close();
        }

        /// <summary>
        ///     Retorna un resumen de productos con informacion como Nombre, unidades disponible, y el valor de estas unidades disponibles.
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
        /// <returns></returns>
        public List<ReporteInventarioModelo> CargarReporteInventario(ReporteFiltroModelo filtro, int? limiteFilas = null, int? comienzo = null)
        {
            var q = @"select productos.id as 'IdProducto', 
                        productos.nombre as 'NombreProducto', 
                        productos.Descripcion as 'DescripcionProducto', 
                        total(lotes.inversion / lotes.UnidadesCompradas * lotes.UnidadesDisponibles) as 'InversionUnidadesProducto', 
                        sum(lotes.UnidadesDisponibles) as 'UnidadesProducto' 
                        from Productos
                        left join lotes on lotes.ProductoId = productos.Id";

            var parametros = new DynamicParameters();

            // Contrendan los joins de las tablas y la condiciones
            // necesarias para la generacion de los resumenes.
            var joins = new List<string>();
            var condiciones = new List<string>();

            if (filtro != null)
            {
                // Si se filtra por producto.
                if (filtro.FiltroPorProducto && filtro.Producto != null)
                {
                    condiciones.Add("productos.id = @ProductoId");
                    parametros.Add("@ProductoId", filtro.Producto.Id);
                }

                // Si se filtra por categorias.
                if (filtro.Categorias != null && filtro.Categorias.Count > 0)
                {
                    condiciones.Add(CondicionFiltroCategorias(parametros, filtro.Categorias));
                }
            }

            // Agregar los diferentes joins al query.
            if (joins.Count > 0)
            {
                q += " " + string.Join(" ", joins);
            }

            condiciones.Add("lotes.UnidadesDisponibles > 0");

            if (comienzo != null)
            {
                condiciones.Add("productos.id > @Comienzo");
                parametros.Add("@Comienzo", comienzo);
            }

            // Agregar las condiciones al query.
            if (condiciones.Count > 0)
            {
                q += " where ";
                q += string.Join(" and ", condiciones);
            }

            q += " group by productos.id";

            // Agregar el limite de filas a retornar.
            if (limiteFilas != null && limiteFilas > -1)
            {
                q += $" limit @Limite";
                parametros.Add("@Limite", limiteFilas);
            }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var reportes = conexion.Query<ReporteInventarioModelo>(q, parametros).ToList();

                foreach (var reporte in reportes)
                {
                    reporte.InversionUnidadesProducto = reporte.InversionUnidadesProducto / FactorConversion;
                }

                return reportes;
            }
        }

        /// <summary>
        ///     Magia negra para seleccionar solo productos
        ///     asociados con todas las categorias solicitadas.
        ///     https://stackoverflow.com/a/1330271
        ///     
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
        ///     Una string sql que representa la condicion necesaria para encontrar los productos asociados con todas las categorias proveidas.
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

            return  $@"(case when productos.id in 
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
    }         
}
