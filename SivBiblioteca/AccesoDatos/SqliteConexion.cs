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
        /// guarda una lista de categorias en la base de datos
        /// </summary>
        /// <param name="categorias">
        ///     Lista de categorias a guardar.
        /// </param>
        public void GuardarCategorias(List<CategoriaModelo> categorias)
        {
            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = "insert into Categorias (Nombre) values (@Nombre)";
                
                foreach (var categoria in categorias)
                {
                    categoria.Nombre = categoria.Nombre.Trim();
                    conexion.Execute(q, categoria);
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
                var q = "delete from Categorias where Nombre = @Nombre collate nocase";
                conexion.Execute(q, categorias);               
            }
        }

        /// <summary>
        /// Guarda un producto en la base de datos
        /// </summary>
        /// <param name="productos"> Lista de productos a guardar. </param>
        public void GuardarProducto(ProductoModelo producto)
        {
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
            }
        }

        private int ConvertirMonedaARepresentacionInterna(decimal x)
        {
            int diezAlaP = Convert.ToInt32(Math.Pow(10, MonedaPrecision));
            return Convert.ToInt32(decimal.Truncate(x * diezAlaP));
        }

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

        public ProductoModelo CargarProducto_PorId(int id)
        {
            ProductoModelo p;
            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                var q = @"select Id, PrecioVenta, PrecioInversion, Descripcion, Unidades, datetime(FechaCreacion, 'unixepoch') as FechaCreacion  
                        from Productos 
                        where Id = @Id";
                p = conexion.QuerySingle<ProductoModelo>(q, new { Id = id });
            }

            // representacion original de los precios
            decimal diezALaP = Convert.ToDecimal(Math.Pow(10, MonedaPrecision));
            p.PrecioVenta = p.PrecioVenta / diezALaP;
            p.PrecioInversion = p.PrecioInversion / diezALaP;

            return p;
        }
    }         
}
