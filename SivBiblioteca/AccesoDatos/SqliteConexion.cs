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

        /// <summary>
        /// revisa si la categoria existe en la base de datos
        /// </summary>
        /// <param name="nombreCategoria"></param>
        /// <returns></returns>
        public bool CategoriaExiste(string nombreCategoria)
        {
            using (IDbConnection conexion = new SQLiteConnection(stringConexion))
            {
                nombreCategoria = nombreCategoria.Trim();
                var q = "select exists (select 1 from Categorias where Nombre = @Nombre collate nocase)";
                var resultado = conexion.ExecuteScalar<bool>(q, new { Nombre = nombreCategoria });
                return resultado;
            }
        }

        /// <summary>
        /// carga y retorna todas las categorias existentes en la base de datos
        /// </summary>
        /// <returns></returns>
        public List<CategoriaModelo> Categoria_Todas()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// guarda una lista de categorias en la base de datos
        /// </summary>
        /// <param name="categorias">
        ///     la lista de categorias a guardar
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


    }
}
