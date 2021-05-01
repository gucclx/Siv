using SivBiblioteca;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SivUI
{
    public static class ExportarDialogo
    {
        /// <summary>
        ///     Abre un dialogo donde el usuario escoge una ruta a guardar 
        ///     un reporte de lotes, ventas o inventario.
        ///     Si la ruta es la de un archivo y existe, este se elimina.
        ///     Si se intenta eliminar y este esta haciendo ocupado por otro proceso
        ///     una excepcion IOException occurrira.
        /// </summary>
        /// <returns> 
        /// La informacion de la ruta. Si el usuario no escoge uno se retorna null. 
        /// </returns>
        public static FileInfo Mostrar()
        {
            using (var dialogoGuardar = new SaveFileDialog())
            {
                dialogoGuardar.Filter = "CSV |*.csv";
                dialogoGuardar.OverwritePrompt = true;

                var resultadoDialogo = dialogoGuardar.ShowDialog();

                if (resultadoDialogo != DialogResult.OK) return null;

                var ruta = new FileInfo(dialogoGuardar.FileName);

                if (ruta.Exists)
                {
                    ruta.Delete();
                }

                return ruta;
            }
        }
    }
}
