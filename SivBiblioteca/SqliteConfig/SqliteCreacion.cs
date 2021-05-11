using System;
using System.Configuration;
using System.IO;
using System.Data.SQLite;


namespace SivBiblioteca.SqliteConfig
{
    public static class SqliteCreacion
    {
        const string TablasScriptsRuta = @".\SqliteConfig\Tablas";
        const string IndicesScriptsRuta = @".\SqliteConfig\Indices";

        /// <summary>
        /// Crea y situa el archivo de la base de datos en el directorio
        /// Enviroment.SpecialFolder.LocalApplicationData.
        /// </summary>
        /// <remarks>
        /// 
        /// El directorio Enviroment.SpecialFolder.LocalApplicationData
        /// hace referencia a %localAppData% en windows.
        /// 
        /// Se situa el archivo de la base de datos en este directorio
        /// debido a que se utiliza ClickOnce para publicar la aplicacion.
        /// Cuando se realiza una actualizacion a la aplicacion, 
        /// ClickOnce crea un nuevo directorio para cada actualizacion. 
        /// Si se incluye el archivo de la base de datos en el directorio de publicacion, 
        /// ClickOnce reemplazara dicho archivo por uno nuevo y los datos del usuario se perderan.
        /// 
        /// Por lo tanto, se utiliza este directorio del usuario, 
        /// el cual esta fuera del directorio de publicacion, 
        /// por lo que la base de datos persistira luego de una actualizacion.
        /// 
        /// Si el usuario desinstala la aplicacion, la base de datos no se eliminara, ya que reside fuera
        /// del directorio de publicacion.
        /// 
        /// referencia: https://robindotnet.wordpress.com/2009/08/19/where-do-i-put-my-data-to-keep-it-safe-from-clickonce-updates/
        /// </remarks>
        public static void SituarBd_EnDirectorioLocal()
        {
            var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            // La string conexion de la base de datos
            // tiene como Data Source "|DataDirectory|\BdFolderNombre\BdNombre".
            // esta linea de codigo indica que |DataDirectory|
            // debe ser reemplazado por localAppData.
            AppDomain.CurrentDomain.SetData("DataDirectory", localAppData);

            var bdFolderNombre = ConfigurationManager.AppSettings.Get("BdFolderNombre");
            var bdDirectorioDestino = Path.Combine(localAppData, bdFolderNombre);

            if (Directory.Exists(bdDirectorioDestino) == false)
            {
                Directory.CreateDirectory(bdDirectorioDestino);
            }

            var bdNombre = ConfigurationManager.AppSettings.Get("BdNombre");

            string bdRutaDestino = Path.Combine(bdDirectorioDestino, bdNombre);

            if (File.Exists(bdRutaDestino)) return;

            var stringConexion = ConfigurationManager.ConnectionStrings["Sqlite"].ToString();

            CrearBaseDatos(bdRutaDestino, stringConexion);
        }

        private static  void CrearBaseDatos(string destino, string stringConexion)
        {
            SQLiteConnection.CreateFile(destino);

            using var conexion = new SQLiteConnection(stringConexion);
            conexion.Open();

            EjecutarScripts(conexion, TablasScriptsRuta);
            EjecutarScripts(conexion, IndicesScriptsRuta);
        }

        /// <summary>
        /// Ejecuta todos los scripts sql dentro del directorio <paramref name="scriptsRuta"/>
        /// </summary>
        /// <param name="conexion">Conexion sqlite</param>
        /// <param name="scriptsRuta">Ruta del directorio donde los scripts sql residen.</param>
        private static void EjecutarScripts(SQLiteConnection conexion, string scriptsRuta)
        {
            var scripts = Directory.GetFiles(scriptsRuta);

            foreach (var script in scripts)
            {
                var q = File.ReadAllText(script);

                var command = new SQLiteCommand(q, conexion);
                command.ExecuteNonQuery();
            }
        }
    }
}
