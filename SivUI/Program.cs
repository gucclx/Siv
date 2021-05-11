using SivBiblioteca;
using SivBiblioteca.SqliteConfig;
using System;
using System.Windows.Forms;


namespace SivUI
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SqliteCreacion.SituarBd_EnDirectorioLocal();
            ConfigGlobal.InicializarConexion(ConfigGlobal.TipoConexion.Sqlite);

            Application.Run(new InicioForm());
        }
    }
}
