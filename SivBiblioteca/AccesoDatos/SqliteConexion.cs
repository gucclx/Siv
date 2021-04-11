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
    // todo - probar caso producto con lote agotado (lotes.unidades == 0)

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
        string FactorConversion = Convert.ToInt32(Math.Pow(10, MonedaPrecision)).ToString() + ".0";

        /// <summary>
        /// Revisa si la categoria existe en la base de datos.
        /// </summary>
        /// <param name="nombreCategoria"></param>
        /// <returns></returns>
        public bool CategoriaExiste(string nombreCategoria)
        {
            if (string.IsNullOrEmpty(nombreCategoria.Trim())) { return false; }

            bool resultado = false;

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                nombreCategoria = nombreCategoria.Trim();
                var q = "select exists (select 1 from Categorias where Nombre = @Nombre collate nocase)";
                resultado = conexion.ExecuteScalar<bool>(q, new { Nombre = nombreCategoria });
            }
            return resultado;
        }

        /// <summary>
        /// Carga y retorna todas las categorias existentes en la base de datos.
        /// </summary>
        /// <returns></returns>
        public List<CategoriaModelo> CargarCategorias()
        {
            var categorias = new List<CategoriaModelo>();

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                categorias = conexion.Query<CategoriaModelo>("select Id, Nombre from Categorias order by Nombre").ToList();                
            }
            return categorias;
        }

        /// <summary>
        /// Guarda una lista de categorias en la base de datos.
        /// </summary>
        /// <param name="categorias">
        ///     Lista de categorias a guardar.
        /// </param>
        public void GuardarCategorias(List<CategoriaModelo> categorias)
        {
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
            if (categorias == null) return;
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
            if (string.IsNullOrEmpty(producto.Nombre.Trim()))
            {
                throw new ArgumentException("El nombre del producto no puede estar vacio.");
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

        // todo - int64?
        private int ConvertirMonedaARepresentacionInterna(decimal x)
        {
            int diezAlaP = Convert.ToInt32(Math.Pow(10, MonedaPrecision));
            return Convert.ToInt32(decimal.Truncate(x * diezAlaP));
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
                            (Inversion / @FC) as 'Inversion',
                            (PrecioVentaUnidad / @FC) as 'PrecioVentaUnidad', 
                            datetime(FechaCreacion, 'unixepoch', 'localtime') as 'FechaCreacion'
                            from lotes where id = @Id";

                lote = conexion.QuerySingleOrDefault<LoteModelo>(q, new { Id = id, FC = FactorConversion });
                if (lote != null)
                {
                    lote.Producto = conexion.QuerySingle<ProductoModelo>("select * from productos where id = @ID", new { ID = lote.ProductoId });
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
            }
        }

        public int UnidadesDisponiblesLote(int loteId)
        {
            int unidades = 0;
            if (loteId < 1) { return unidades; }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "select UnidadesDisponibles from Lotes where Id = @Id";
                unidades = conexion.ExecuteScalar<int>(q, new { Id = loteId });
            }
            return unidades;
        }

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
        /// <param name="nombre"> La string a buscar. </param>
        /// <returns></returns>
        public List<ClienteModelo> BuscarCliente_PorNombre(string nombre)
        {
            nombre = nombre.Trim();
            var clientes = new List<ClienteModelo>();
            if (string.IsNullOrEmpty(nombre)) { return clientes; }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "select * from Clientes where (Nombre || ' ' || coalesce(Apellido, '')) like @Nombre";
                clientes = conexion.Query<ClienteModelo>(q, new { Nombre = '%' + nombre + '%'}).ToList();
            }
            return clientes;
        }

        public List<ReporteVentaModelo> CargarReporteVentas(ReporteFiltroModelo filtro = null, int? limiteFilas = null)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@FC", FactorConversion);

            var q = @"select lotes.id as 'LoteId', productos.nombre as 'NombreProducto', 
                            ventas.Unidades as 'UnidadesVendidas',
                            lotes.Inversion / @FC as 'InversionLote',
                            lotes.UnidadesCompradas as 'UnidadesCompradasLote',
                            ventas.PrecioVentaUnidad / @FC as 'PrecioVentaUnidad',
                            datetime(ventas.fecha, 'unixepoch', 'localtime') as 'FechaVenta',
                            clientes.Nombre || ' ' || coalesce(clientes.apellido, '') as 'NombreCliente'
                            from ventas
                            join lotes on lotes.id = ventas.LoteId
                            join productos on productos.id = lotes.ProductoId
                            left join Clientes on clientes.id = ventas.ClienteId";

            var joins = new List<string>();
            var condiciones = new List<string>();

            if (filtro != null)
            {

                if (filtro.Categorias != null && filtro.Categorias.Count > 0)
                {
                    joins.Add("left join ProductoCategoria on ProductoCategoria.ProductoId = Productos.id");
                    condiciones.Add("ProductoCategoria.CategoriaId in @Ids");
                    parametros.Add("@Ids", filtro.Categorias.Select(c => c.Id).ToList());
                }

                if (filtro.FechaInicial != null && filtro.FechaFinal != null && filtro.FiltroPorFechas)
                {
                    condiciones.Add("ventas.fecha BETWEEN @F1 AND @F2");
                    parametros.Add("@F1", ((DateTimeOffset)filtro.FechaInicial).ToUnixTimeSeconds());
                    parametros.Add("@F2", ((DateTimeOffset)filtro.FechaFinal).ToUnixTimeSeconds());
                }

                if (filtro.FiltroPorProducto && filtro.Producto != null)
                {
                    condiciones.Add("productos.id = @ProductoId");
                    parametros.Add("@ProductoId", filtro.Producto.Id);
                }

                if (filtro.FiltroPorCliente && filtro.Cliente != null)
                {
                    condiciones.Add("clientes.id = @ClienteId");
                    parametros.Add("@ClienteId", filtro.Cliente.Id);
                }


            }

            if (joins.Count > 0)
            {
                q += " " + string.Join(" ", joins);
            }

            if (condiciones.Count > 0)
            {
                q += " where ";
                q += string.Join(" and ", condiciones);
            }

            q += " order by ventas.id desc";

            if (limiteFilas != null && limiteFilas > -1)
            {
                q += $" limit @Limite";
                parametros.Add("@Limite", limiteFilas);
            }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {                
                return conexion.Query<ReporteVentaModelo>(q, parametros).ToList();
            }
        }

        public int CargarUltimoLoteId()
        {
            int id = 0;
            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "select max(Id) from Lotes";
                id = conexion.ExecuteScalar<int>(q);
            }
            return id;
        }

        public List<ProductoModelo> CargarProductos()
        {
            var productos = new List<ProductoModelo>();

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                productos = conexion.Query<ProductoModelo>("select * from Productos").ToList();
            }
            return productos;
        }

        public void GuardarLote(LoteModelo lote)
        {
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

                conexion.Execute(q, new
                {
                    ProductoId = lote.Producto.Id,
                    UnidadesCompradas = lote.UnidadesCompradas,
                    UnidadesDisponibles = lote.UnidadesDisponibles,
                    Inversion = ConvertirMonedaARepresentacionInterna(lote.Inversion),
                    PrecioVentaUnidad = ConvertirMonedaARepresentacionInterna(lote.PrecioVentaUnidad)
                });

                q = "select max(Id) from Lotes";
                lote.Id = conexion.ExecuteScalar<int>(q);
            }
        }

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
        /// <param name="nombre"> nombre a buscar. </param>
        /// <returns></returns>
        public List<CategoriaModelo> BuscarCategoria_PorNombre(string nombre)
        {
            nombre = nombre.Trim();
            var categorias = new List<CategoriaModelo>();
            if (string.IsNullOrEmpty(nombre)) { return categorias; }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "select * from Categorias where Nombre like @Nombre";
                categorias = conexion.Query<CategoriaModelo>(q, new { Nombre = '%' + nombre + '%' }).ToList();
            }
            return categorias;
        }

        public List<ReporteInventarioModelo> CargarReporteInventario(ReporteFiltroModelo filtro = null, int? limiteFilas = null)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@FC", FactorConversion);

            var q = @"select productos.Nombre as 'NombreProducto',
                    productos.Descripcion as 'DescripcionProducto',
                    lotes.PrecioVentaUnidad / @FC as 'PrecioVentaUnidad',
                    lotes.id as 'LoteId',
                    lotes.UnidadesCompradas as 'UnidadesCompradasLote',
                    lotes.UnidadesDisponibles as 'UnidadesDisponiblesLote',
                    lotes.Inversion / @FC as 'InversionLote',
                    datetime(lotes.FechaCreacion, 'unixepoch', 'localtime') as 'FechaAgregado'
                    from Productos
                    join lotes on lotes.ProductoId = productos.Id";

            var joins = new List<string>();
            var condiciones = new List<string>();

            if (filtro != null)
            {

                if (filtro.Categorias != null && filtro.Categorias.Count > 0)
                {
                    joins.Add("left join ProductoCategoria on ProductoCategoria.ProductoId = Productos.id");
                    condiciones.Add("ProductoCategoria.CategoriaId in @Ids");
                    parametros.Add("@Ids", filtro.Categorias.Select(c => c.Id).ToList());
                }

                if (filtro.FechaInicial != null && filtro.FechaFinal != null && filtro.FiltroPorFechas)
                {
                    condiciones.Add("lotes.FechaCreacion BETWEEN @F1 AND @F2");
                    parametros.Add("@F1", ((DateTimeOffset)filtro.FechaInicial).ToUnixTimeSeconds());
                    parametros.Add("@F2", ((DateTimeOffset)filtro.FechaFinal).ToUnixTimeSeconds());
                }

                if (filtro.FiltroPorProducto && filtro.Producto != null)
                {
                    condiciones.Add("productos.id = @ProductoId");
                    parametros.Add("@ProductoId", filtro.Producto.Id);
                }
            }

            if (joins.Count > 0)
            {
                q += " " + string.Join(" ", joins);
            }

            if (condiciones.Count > 0)
            {
                q += " where ";
                q += string.Join(" and ", condiciones);
            }

            q += " order by lotes.id desc";

            if (limiteFilas != null && limiteFilas > -1)
            {
                q += $" limit @Limite";
                parametros.Add("@Limite", limiteFilas);
            }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                return conexion.Query<ReporteInventarioModelo>(q, parametros).ToList();
            }
        }

        // TODO - cargar las categorias del producto.
        /// <summary>
        /// Carga y retorna una lista de productos cuyo nombre contiene el parametro 'nombre'.
        /// </summary>
        /// <param name="nombre"> Nombre del producto a buscar. </param>
        /// <returns> Los productos encontrados. </returns>
        public List<ProductoModelo> BuscarProducto_PorNombre(string nombre)
        {
            nombre = nombre.Trim();
            var productos = new List<ProductoModelo>();
            if (string.IsNullOrEmpty(nombre)) { return productos; }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "select * from Productos where Nombre like @Nombre";
                productos = conexion.Query<ProductoModelo>(q, new { Nombre = '%' + nombre + '%' }).ToList();
            }
            return productos;
        }

        // TODO - probar con productos.categoria == null
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

                        foreach (var categoria in producto.Categorias)
                        {
                            conexion.Execute(q, new { ProductoId = producto.Id, CategoriaId = categoria.Id});
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
        /// Util cuando se carga un producto desde BuscarProducto_PorNombre
        /// ya que es ineficiente cargar todas las categorias de todos los posibles
        /// productos de dicha funcion.
        /// </summary>
        /// <param name="id"> Id del producto. </param>
        /// <returns> Las categorias del producto cuyo id fue proporcionado. </returns>
        public List<CategoriaModelo> CargarCategorias_PorProductoId(int id)
        {
            List<CategoriaModelo> categorias = null;
            if (id < 1) return categorias;

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = @"select categorias.nombre, categorias.id from Categorias 
                        join ProductoCategoria on ProductoCategoria.CategoriaId = categorias.Id
                        where ProductoCategoria.ProductoId = @Id";
                return categorias = conexion.Query<CategoriaModelo>(q, new { Id = id }).ToList();
            }
        }

        public void EditarLote(LoteModelo lote)
        {
            if (lote == null)
            {
                throw new ArgumentException("Lote nulo");
            }
            if (lote.Id < 1)
            {
                throw new ArgumentException($"Id del lote invalido: { lote.Id }");
            }
            if (lote.UnidadesDisponibles < 0)
            {
                throw new ArgumentException($"Unidades disponibles invalidas: { lote.UnidadesDisponibles } La cantidad no puede ser negativa.");
            }
            if (lote.PrecioVentaUnidad < 0)
            {
                throw new ArgumentException($"Precio de venta por unidad invalido: { lote.PrecioVentaUnidad} El precio no puede ser negativo.");
            }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = @"select UnidadesDisponibles from lotes where Id = @Id";
                var unidadesDisponibles = conexion.ExecuteScalar<int>(q, new { Id = lote.Id });

                if (lote.UnidadesDisponibles > unidadesDisponibles)
                {
                    throw new ArgumentException($@"Unidades disponibles solicitadas invalidas. 
                                                    La cantidad de unidades disponibles solicitada es mayor a la cantidad de unidades disponibles en la base de datos.
                                                    Cantidad solicitada: { lote.UnidadesDisponibles }, cantidad en la base de datos: { unidadesDisponibles }.
                                                    No se permite agregar unidades al lote.");
                }

                q = "update lotes set UnidadesDisponibles = @UnidadesDisponibles, PrecioVentaUnidad = @PrecioVentaUnidad where Id = @Id";

                conexion.Execute(q, 
                    new
                    { UnidadesDisponibles = lote.UnidadesDisponibles,
                        PrecioVentaUnidad = ConvertirMonedaARepresentacionInterna(lote.PrecioVentaUnidad),
                        Id = lote.Id
                    });               
            }
        }

        public void EditarCliente(ClienteModelo cliente)
        {
            cliente.Nombre = cliente.Nombre.Trim();
            if (string.IsNullOrEmpty(cliente.Nombre))
            {
                throw new ArgumentException("El nombre del cliente no puede estar vacio.");
            }
            if (cliente.Id < 1)
            {
                throw new ArgumentException($"Id del cliente invalido: { cliente.Id }");
            }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = @"update clientes set Nombre = @Nombre, NumeroContacto = @NumeroContacto
                            where Id = @Id";

                var parametros = new { Nombre = cliente.Nombre, NumeroContacto = cliente.NumeroContacto, Id = cliente.Id };

                conexion.Execute(q, parametros);
            }
        }
    }         
}
