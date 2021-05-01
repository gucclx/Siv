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
    public static class Exportar
    {
        /// <summary>
        ///     Abre un dialogo donde el usuario escoge un archivo a guardar 
        ///     un reporte de lotes, ventas o inventario.
        ///     Si el archivo existe, este se elimina.
        ///     Si se intenta eliminar y este esta haciendo ocupado por otro proceso
        ///     una excepcion IOException occurrira.
        /// </summary>
        /// <returns> 
        /// La informacion del destino. Si el usuario no escoge uno se retorna null. 
        /// </returns>
        public static FileInfo DialogoGuardar()
        {
            using (var dialogoGuardar = new SaveFileDialog())
            {
                dialogoGuardar.Filter = "CSV |*.csv";
                dialogoGuardar.OverwritePrompt = true;

                var resultadoDialogo = dialogoGuardar.ShowDialog();

                if (resultadoDialogo != DialogResult.OK) return null;

                var archivo = new FileInfo(dialogoGuardar.FileName);

                if (archivo.Exists)
                {
                    archivo.Delete();
                }

                return archivo;
            }
        }

        /// <summary>
        /// Exporta una lista de reportes de lotes, inventario o ventas.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reportes"></param>
        /// <returns></returns>
        public static async Task ExportarReportes<T>(IEnumerable<T> reportes, FileInfo destino)
        {
            await Ayudantes.GuardarCsvReporteAsync<T>(reportes, destino);
        }
    }
}
