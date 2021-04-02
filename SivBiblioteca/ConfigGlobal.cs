using SivBiblioteca.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca
{
    public static class ConfigGlobal
    {
        public static IConexionDatos conexion;

        public static void inicializarConexion()
        {
            conexion = new SqliteConexion();
        }

        public static string ConseguirStringConexion(string id)
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
