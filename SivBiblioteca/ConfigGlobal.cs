using SivBiblioteca.AccesoDatos;
using System.Configuration;
using SivBiblioteca.Interfaces;
using System;

namespace SivBiblioteca
{
    public static class ConfigGlobal
    {
        public enum TipoConexion
        {
            Sqlite
        }

        public static IConexionDatos conexion;

        public static void InicializarConexion(TipoConexion t)
        {
            switch (t)
            {
                case TipoConexion.Sqlite:
                    conexion = new SqliteConexion();
                    break;

                default:
                    throw new ArgumentException("Tipo de conexion no valida");
            }
        }

        public static string StringConexion(TipoConexion t)
        {
            switch (t)
            {
                case TipoConexion.Sqlite: 
                    return ConfigurationManager.ConnectionStrings["Sqlite"].ConnectionString;

                default:
                    throw new ArgumentException("Tipo de conexion no valida");
            }
        }
    }
}
