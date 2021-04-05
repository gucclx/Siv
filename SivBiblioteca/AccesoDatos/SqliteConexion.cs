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
            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "delete from Categorias where Id = @Id";
                conexion.Execute(q, categorias);               
            }
        }

        /// <summary>
        /// Guarda un producto en la base de datos.
        /// </summary>
        /// <param name="productos"> Lista de productos a guardar. </param>
        public void GuardarProducto(ProductoModelo producto)
        {
            if (Ayudantes.EsProductoValido(producto) == false)
            {
                throw new ArgumentException("Producto con campos invalidos.");
            }
            foreach (var categoria in producto.Categorias)
            {
                if (string.IsNullOrEmpty(categoria.Nombre.Trim()))
                {
                    throw new ArgumentException("Categoria sin nombre.");
                }
            }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = @"insert into Productos 
                            (PrecioVenta, PrecioInversion, Unidades, Descripcion, FechaCreacion) 
                            values (@PrecioVenta, @PrecioInversion, @Unidades, @Descripcion, strftime('%s', 'now', 'localtime'))";

                conexion.Execute(q, 
                    new
                    {
                        PrecioVenta = ConvertirMonedaARepresentacionInterna(producto.PrecioVenta),
                        PrecioInversion = ConvertirMonedaARepresentacionInterna(producto.PrecioInversion),
                        Unidades = producto.Unidades,
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

        private int ConvertirMonedaARepresentacionInterna(decimal x)
        {
            int diezAlaP = Convert.ToInt32(Math.Pow(10, MonedaPrecision));
            return Convert.ToInt32(decimal.Truncate(x * diezAlaP));
        }

        /// <summary>
        /// Retorna el id del ultimo producto almacenado en la base de datos.
        /// </summary>
        /// <returns></returns>
        public int CargarUltimoProductoId()
        {
            int id = -1;
            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "select max(Id) from Productos";
                id = conexion.ExecuteScalar<int>(q);
            }
            return id;
        }

        /// <summary>
        /// Carga y retorna un producto de la base de datos.
        /// </summary>
        /// <param name="id"> Id del producto. </param>
        /// <returns> El producto. Si no se encontro se retorna un producto null. </returns>
        public ProductoModelo CargarProducto_PorId(int id)
        {
            ProductoModelo p = null;

            if (id < 1) { return p; }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = @"select Id, PrecioVenta, PrecioInversion, Descripcion, Unidades, datetime(FechaCreacion, 'unixepoch') as FechaCreacion  
                        from Productos 
                        where Id = @Id";
                p = conexion.QuerySingleOrDefault<ProductoModelo>(q, new { Id = id });
            }

            if (p == null) { return p; }

            // representacion original de los precios
            decimal diezALaP = Convert.ToDecimal(Math.Pow(10, MonedaPrecision));
            p.PrecioVenta = p.PrecioVenta / diezALaP;
            p.PrecioInversion = p.PrecioInversion / diezALaP;

            return p;
        }

        /// <summary>
        /// Guarda una lista de ventas a la base de datos.
        /// </summary>
        /// <param name="ventas"> Lisa de ventas a guardar. </param>
        public void GuardarVentas(List<VentaModelo> ventas)
        {
            foreach (var venta in ventas)
            {
                if (Ayudantes.EsProductoValido(venta.Producto) == false)
                {
                    throw new Exception("Producto con campos invalidos.");
                }
                else if (venta.Unidades < 1)
                {
                    throw new Exception($"Unidades solicitadas invalidas. Solicitud = {venta.Unidades}");
                }
                else if (venta.Total < 0)
                {
                    throw new Exception("Total de la venta no puede ser negativo");
                }
                else if (venta.Unidades > UnidadesExistentesProducto(venta.Producto.Id))
                {
                    throw new Exception($"Se han solicitado mas unidades del producto que hay en existencia.");
                }                    
            }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = @"insert into Ventas (ProductoId, Unidades, Total, Comentario, ClienteId, Fecha)
                          values (@ProductoId, @Unidades, @Total, @Comentario, @ClienteId, strftime('%s', 'now', 'localtime'))";

                conexion.Open();
                using (var transaccion = conexion.BeginTransaction())
                {
                    foreach (var venta in ventas)
                    {
                        conexion.Execute(q,
                            new
                            {
                                ProductoId = venta.Producto.Id,
                                Unidades = venta.Unidades,
                                Total = ConvertirMonedaARepresentacionInterna(venta.Total),
                                Comentario = venta.Comentario,
                                ClienteId = venta.ClienteId
                            }
                        );
                        conexion.Execute("update Productos set Unidades = Unidades - @UnidadesVendidas where Id = @Id", 
                            new { UnidadesVendidas = venta.Unidades, Id = venta.Producto.Id }
                        );
                    }
                    transaccion.Commit();
                }                 
            }
        }

        public int UnidadesExistentesProducto(int productoId)
        {
            int unidades = 0;
            if (productoId < 1) { return unidades; }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "select Unidades from Productos where Id = @Id";
                unidades = conexion.ExecuteScalar<int>(q, new { Id = productoId });
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
            }
        }

        /// <summary>
        /// Carga y retorna una lista de clientes cuyo nombre completo contiene el parametro 'nombre'.
        /// </summary>
        /// <param name="nombre"> La string a buscar. </param>
        /// <returns></returns>
        public List<ClienteModelo> BuscarCliente_PorNombre(string nombre)
        {
            var clientes = new List<ClienteModelo>();
            if (string.IsNullOrEmpty(nombre)) { return clientes; }

            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "select * from Clientes where (Nombre || ' ' || coalesce(Apellido, '')) like @Nombre";
                clientes = conexion.Query<ClienteModelo>(q, new { Nombre = '%' + nombre + '%'}).ToList();
            }
            return clientes;
        }
    }         
}
