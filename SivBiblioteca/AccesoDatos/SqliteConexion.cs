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
    // TODO - validar que todos los datos esten correctos.
    // todo - cargar_porNombre<type>(string nombre);
    // todo - siempre revisar si una lista es nula antes de iterar en ella.

    // Nota - las fechas se guardan en tiempo unix UTC y se extraen como strings yyyy-mm-dd hh:mm:ss en tiempo local.
    public class SqliteConexion : IConexionDatos
    {
        string stringConexion = ConfigGlobal.ConseguirStringConexion("SqliteBd");

        // Describe cuantos digitos se consideran despues del punto decimal
        // en todos los precios que se guardan en la base de datos.
        // Si la precision es 2, todos los precios se deberan guardar en
        // centavos.
        // Ej. 5.55 cordobas se convierte a 555 centavos.
        // De esta manera, trabajando con enteros, se preserva la precision
        // sin tener problemas de redondeo cuando se realicen operaciones en los precios.
        // En este caso se conservan 4 digitos despues del decimal, por lo que
        // se trabaja con 'diezmilesimas' es decir 5.55 -> 55500, 6.7899 -> 67899.
        // Los digitos restantes seran truncados.

        // En general si se trabaja con una precision p y
        // un precio x se representara en la base de datos como
        // x * (10^p)
        // una vez extraido de la base de datos se divide por (10^p) para obtener la representacion
        // original de x
        const double MonedaPrecision = 4;

        // Factor de conversion para obtener la representacion original de los precios.
        // Se utiliza como parametro en los queries. El factor requiere '.0' para indicarle a
        // sqlite que la division deberia ser decimal y no entera.
        int FactorConversion = Convert.ToInt32(Math.Pow(10, MonedaPrecision));

        /// <summary>
        /// Revisa si la categoria existe en la base de datos.
        /// </summary>
        /// <param name="nombreCategoria"> Nombre de la categoria a buscar. </param>
        /// <returns> true si existe, false si no. </returns>
        public bool CategoriaExiste(string nombreCategoria)
        {
            if (string.IsNullOrEmpty(nombreCategoria.Trim())) { return false; }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                nombreCategoria = nombreCategoria.Trim();
                var q = "select exists (select 1 from Categorias where Nombre = @Nombre collate nocase)";
                return conexion.ExecuteScalar<bool>(q, new { Nombre = nombreCategoria });
            }
        }

        /// <summary>
        /// Carga y retorna todas las categorias existentes en la base de datos.
        /// </summary>
        /// <returns> Todas las categorias en la base de datos. </returns>
        public List<CategoriaModelo> CargarCategorias()
        {
            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                return conexion.Query<CategoriaModelo>("select Id, Nombre from Categorias order by Nombre").ToList();                
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
                if (string.IsNullOrEmpty(categoria.Nombre.Trim()))
                {
                    throw new ArgumentException("Categoria sin nombre.");
                }
            }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "insert into Categorias (Nombre) values (@Nombre)";
                
                foreach (var categoria in categorias)
                {
                    categoria.Nombre = categoria.Nombre.Trim();
                    conexion.Execute(q, categoria);
                    categoria.Id = conexion.ExecuteScalar<int>("select max(id) from Categorias");
                }
            }
        }

        /// <summary>
        /// Elimina de la base de datos una lista de categorias.
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
        /// Guarda un producto en la base de datos.
        /// </summary>
        /// <param name="producto"> Producto a guardar. </param>
        public void GuardarProducto(ProductoModelo producto)
        {
            producto.Nombre = producto.Nombre.Trim();

            if (string.IsNullOrEmpty(producto.Nombre))
            {
                throw new ArgumentException("El nombre del producto no puede estar vacio.");
            }

            if (ProductoExiste(producto.Nombre))
            {
                throw new ArgumentException("El nombre del producto ya existe en la base de datos.");
            }
            
            foreach (var categoria in producto.Categorias)
            {
                if (string.IsNullOrEmpty(categoria.Nombre.Trim()))
                {
                    throw new ArgumentException("Al menos una categoria del producto no tiene nombre.");
                }
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

                q = "insert into ProductoCategoria (ProductoId, CategoriaId) values (@ProductoId, @CategoriaId)";
                foreach (var categoria in producto.Categorias)
                {
                    conexion.Execute(q, new { ProductoId = producto.Id, CategoriaId = categoria.Id });
                }
            }
        }

        /// <summary>
        /// x se multiplica por el factor de conversion para obtener 
        /// la representacion de la moneda que se utilizara en la base de datos.
        /// los decimales restantes se truncan. 
        /// Si x * FactorConversion > decimal.MaxValue o x * FactorConversion > Int64.MaxValue se producira una excepcion.
        /// </summary>
        /// <param name="x"> El valor de la moneda en su representacion original. </param>
        /// <returns> El valor de la moneda en la representacion utilizada en la base de datos. </returns>
        private long ConvertirMonedaARepresentacionInterna(decimal x)
        {
            return Convert.ToInt64(decimal.Truncate(x * FactorConversion));
        }

        /// <summary>
        /// Carga y retorna un lote de la base de datos
        /// </summary>
        /// <param name="id"> Id del lote. </param>
        /// <returns> El lote. Si no se encontro se retorna un lote null. </returns>
        public LoteModelo CargarLote_PorId(int id)
        {
            LoteModelo lote = null;

            if (id < 1) { return lote; }

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
        /// Guarda una lista de ventas a la base de datos.
        /// </summary>
        /// <param name="ventas"> Lisa de ventas a guardar. </param>
        public void GuardarVentas(List<VentaModelo> ventas)
        {
            // validar campos de la venta
            foreach (var venta in ventas)
            {
                if (venta.Unidades < 1)
                {
                    throw new Exception($"Unidades solicitadas invalidas: {venta.Unidades}, solo valores positivos");
                }
                else if (venta.Total < 0)
                {
                    throw new Exception($"Total de la venta invalido: {venta.Total}, solo valores no negativos.");
                }
                else if (venta.Unidades > UnidadesDisponiblesLote(venta.Lote.Id))
                {
                    throw new Exception($"El numero de unidades solicitadas sobrepasa las disponibles en el lote.");
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
        /// Retorna las unidades disponibles de un lote.
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
        /// Guarda un cliente en la base de datos.
        /// </summary>
        /// <param name="cliente"> El cliente. </param>
        public void GuardarCliente(ClienteModelo cliente)
        {
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
        /// Carga y retorna una lista de clientes cuyo nombre completo contiene el parametro 'nombre'.
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
        ///     Genera y retorna reportes de ventas.
        /// </summary>
        /// <param name="filtro"> 
        ///     Objeto que contiene condiciones para generar el reporte. 
        /// </param>
        /// <param name="limiteFilas"> 
        ///     Limite de filas a retornar. Util si la informacion se presentara al usuario. 
        /// </param>
        /// <returns> Lista de reportes. </returns>
        public List<ReporteVentaModelo> CargarReporteVentas(ReporteFiltroModelo filtro = null, int? limiteFilas = null)
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
                // Si se filtra por categorias del producto.
                if (filtro.Categorias != null && filtro.Categorias.Count > 0)
                {
                    joins.Add("left join ProductoCategoria on ProductoCategoria.ProductoId = Productos.id");
                    condiciones.Add("ProductoCategoria.CategoriaId in @Ids");
                    parametros.Add("@Ids", filtro.Categorias.Select(c => c.Id).ToList());
                }

                // Si se filtra por fecha de venta.
                if (filtro.FechaInicial != null && filtro.FechaFinal != null && filtro.FiltroPorFechas)
                {
                    condiciones.Add("ventas.fecha BETWEEN @F1 AND @F2");
                    parametros.Add("@F1", ((DateTimeOffset)filtro.FechaInicial).ToUnixTimeSeconds());
                    parametros.Add("@F2", ((DateTimeOffset)filtro.FechaFinal).ToUnixTimeSeconds());
                }

                // Si se filtra por tipo de producto.
                if (filtro.FiltroPorProducto && filtro.Producto != null)
                {
                    // Se utiliza case para forzar a sqlite
                    // a buscar los lotes a partir de la columna loteId en la tabla ventas
                    // (utilizando el index unico en la columna id de la tabla lotes)
                    // y luego seleccionar solamente los lotes asociados con el producto especificado.
                    // Sin case, sqlite decide buscar los lotes asociados con el producto especificado,
                    // y luego buscar las ventas a partir de estos lotes.
                    // Sin embargo, esto es ineficiente si hay muchos lotes asociados con el producto especificado.

                    // query plan sin case:
                    // SEARCH TABLE productos USING INTEGER PRIMARY KEY(rowid =?)
                    // SEARCH TABLE lotes USING INDEX idx_Lotes_ProductoId(ProductoId=?)
                    // SEARCH TABLE ventas USING INDEX idx_Ventas_LoteId(LoteId=?)

                    // query plan con case:
                    // SCAN / SEARCH TABLE ventas (search si se especifica un rango de fechas)
                    // SEARCH TABLE lotes USING INTEGER PRIMARY KEY(rowid=?)
                    // SEARCH TABLE productos USING INTEGER PRIMARY KEY(rowid =?)

                    // https://stackoverflow.com/a/49861947

                    condiciones.Add("(case when productos.id = @ProductoId then 1 end) = 1");
                    parametros.Add("@ProductoId", filtro.Producto.Id);
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

            // Agregar las condiciones al query.
            if (condiciones.Count > 0)
            {
                q += " where ";
                q += string.Join(" and ", condiciones);
            }

            q += " order by ventas.id desc";

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
                    reporte.InversionLote = reporte.InversionLote / FactorConversion;
                    reporte.PrecioVentaUnidad = reporte.PrecioVentaUnidad / FactorConversion;
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
        /// Carga y retorna todos los productos en la base de datos.
        /// </summary>
        /// <returns> Todos los productos en la base de datos. </returns>
        public List<ProductoModelo> CargarProductos()
        {
            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                return conexion.Query<ProductoModelo>("select * from Productos").ToList();
            }
        }

        // todo - set unidadesdisponibles aqui.
        /// <summary>
        /// Guarda un lote en la base de datos.
        /// </summary>
        /// <param name="lote"> Lote a guardar. </param>
        public void GuardarLote(LoteModelo lote)
        {
            // Validar campos del lote.
            if (lote.Producto.Id < 1)
            {
                throw new ArgumentException($"Id de producto invalido: {lote.Producto.Id}, el id deber ser mayor a 0.");
            }

            if (lote.UnidadesCompradas < 1)
            {
                throw new ArgumentException($"Unidades invalidas: {lote.UnidadesCompradas}, las unidades deben ser positivas.");
            }

            if (lote.UnidadesCompradas != lote.UnidadesDisponibles)
            {
                throw new ArgumentException($"Las unidades compradas y disponibles no deben diferir incialmente. Unidades compra: {lote.UnidadesCompradas}, Unidades disponibles: {lote.UnidadesDisponibles}");
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
                    throw new Exception("El valor de la inversión es demasiado grande.");
                }

                // Validar que el precio de venta de las unidades no se demasiado grande.
                try
                {
                    precioVenta = ConvertirMonedaARepresentacionInterna(lote.PrecioVentaUnidad);
                }
                catch (OverflowException)
                {
                    throw new Exception("El precio de venta de la unidad es demasiado grande.");
                }

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
        /// Revisa si un producto existe en la base de datos a partir de un nombre proporcionado.
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
        /// Carga y retorna una lista de categorias de la base de datos
        /// cuyos nombres contienen el parametro 'nombre'.
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
        ///     Genera y retorna una lista de reportes de inventario.
        /// </summary>
        /// <param name="filtro"> 
        ///     Objeto que contiene condiciones para generar los reportes. 
        /// </param>
        /// <param name="limiteFilas"> 
        ///     Limite de filas a retonar. 
        /// </param>
        /// <returns> Una lista de reportes. </returns>
        public List<ReporteInventarioModelo> CargarReporteInventario(ReporteFiltroModelo filtro = null, int? limiteFilas = null)
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
            // para cumplir con las condiciones del filtro.
            var joins = new List<string>();
            var condiciones = new List<string>();

            if (filtro != null)
            {
                // Si se filtra por las categorias de los productos en el inventario.
                if (filtro.Categorias != null && filtro.Categorias.Count > 0)
                {
                    joins.Add("left join ProductoCategoria on ProductoCategoria.ProductoId = Productos.id");
                    condiciones.Add("ProductoCategoria.CategoriaId in @Ids");
                    parametros.Add("@Ids", filtro.Categorias.Select(c => c.Id).ToList());
                }

                // Si se filtra por fecha de agregado al inventario.
                if (filtro.FechaInicial != null && filtro.FechaFinal != null && filtro.FiltroPorFechas)
                {
                    condiciones.Add("lotes.FechaCreacion BETWEEN @F1 AND @F2");
                    parametros.Add("@F1", ((DateTimeOffset)filtro.FechaInicial).ToUnixTimeSeconds());
                    parametros.Add("@F2", ((DateTimeOffset)filtro.FechaFinal).ToUnixTimeSeconds());
                }

                // Si se filtra por el tipo de producto.
                if (filtro.FiltroPorProducto && filtro.Producto != null)
                {
                    // Se utiliza case para forzar a sqlite
                    // a que en caso de que se provea un rango de fechas
                    // en la que los lotes fueron creados, sqlite utilize
                    // el index en la columna lotes.FechaCreacion de primero
                    // y luego escoga solo los lotes asociados con el producto especificado.

                    // sin case, sqlite aparenta no utilizar el index de primero.
                    // Asumiendo que se proporciona un rango de fechas, aqui los query plans:

                    // query plan sin case:
                    // SEARCH TABLE Productos USING INTEGER PRIMARY KEY(rowid =?)
                    // SEARCH TABLE lotes USING INDEX idx_Lotes_ProductoId(ProductoId=?)

                    // query plan con case:
                    // SEARCH TABLE lotes USING INDEX idx_Lotes_FechaCreacion(FechaCreacion>? AND FechaCreacion <?)
                    // SEARCH TABLE Productos USING INTEGER PRIMARY KEY(rowid =?)

                    // https://stackoverflow.com/a/49861947

                    condiciones.Add("(case when productos.id = @ProductoId then 1 end) = 1");
                    parametros.Add("@ProductoId", filtro.Producto.Id);
                }
            }

            // Agregar joins necesarios al query.
            if (joins.Count > 0)
            {
                q += " " + string.Join(" ", joins);
            }

            // Agregar condiciones necesarias al query.
            if (condiciones.Count > 0)
            {
                q += " where ";
                q += string.Join(" and ", condiciones);
            }

            q += " order by lotes.id desc";

            // Agregar el limte de filas a retornar.
            if (limiteFilas != null && limiteFilas > -1)
            {
                q += $" limit @Limite";
                parametros.Add("@Limite", limiteFilas);
            }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                conexion.Open();
                var reportes = conexion.Query<ReporteInventarioModelo>(q, parametros).ToList();

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

        public void EditarProducto(ProductoModelo producto)
        {
            if (producto == null)
            {
                throw new ArgumentException($"Producto nulo.");
            }
            if (producto.Id < 1)
            {
                throw new ArgumentException($"Id del producto invalido: {producto.Id}, el id no puede ser menor a 1");
            }
            if (string.IsNullOrEmpty(producto.Nombre))
            {
                throw new ArgumentException("El nombre del producto no puede estar vacio.");
            }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = @"update Productos set Nombre = @Nombre where Id = @Id";
                conexion.Execute(q, new { Nombre = producto.Nombre, Id = producto.Id });

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
        /// Carga y retorna las categorias de un producto especificando el id del producto.
        /// Util cuando se carga un producto desde el metodo BuscarProducto_PorNombre
        /// ya que es ineficiente cargar todas las categorias de todos los posibles
        /// productos retornados por dicha funcion.
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
            // Validar argumentos.

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
                                                    values(1, 1, 1, 1, 9323372036854775808)", con);

            con.Open();
            var trans = con.BeginTransaction();

            for (int i = 0; i < 1000000; i++)
            {
                cmd.ExecuteNonQuery();
            }

            trans.Commit();
            con.Close();
        }
    }         
}
