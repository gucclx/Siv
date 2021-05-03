using CsvHelper;
using CsvHelper.Configuration;
using SivBiblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca
{
    /// <summary>
    /// Provee metodos para exportar reportes de ventas, lotes o inventario.
    /// </summary>
    public static class Exportar
    {
        /// <summary>
        /// Los reportes a exportar se cargan por paginacion.
        /// Esta variable indica cuantas filas posee cada paginacion.
        /// Util si la cantidad de filas es grande, ya que si no se utiliza se carga
        /// una cantidad innecesaria de objetos a la memoria.
        /// </summary>
        static int? filasPaginacion = 100_000;

        /// <summary>
        /// Se utiliza para exportar el inventario, historial de compras de lotes o historial de ventas.
        /// Los reportes se exportan a un archivo .csv utilizando la biblioteca CsvHelper.
        /// Si el archivo seleccionado existe, los reportes seran adjuntados al archivo.
        /// Esto es util si se exportan los reportes por paginacion.
        /// </summary>
        /// <typeparam name="T"> El tipo de reporte. </typeparam>
        /// <param name="reportes"> Reportes a guardar. </param>
        /// <param name="destino"> Informacion de ruta donde se guardaran los reportes. </param>
        /// <returns></returns>
        public static async Task GuardarCsvReporteAsync<T>(FileInfo destino, IEnumerable<T> reportes)
        {
            var config = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                // Si el archivo existe se adjuntara la informacion.
                // por lo que si este existe, no se deben incluir los headers de nuevo.
                HasHeaderRecord = !File.Exists(destino.FullName)
            };

            using (var writer = new StreamWriter(destino.FullName, true, Encoding.UTF8))
            using (var csv = new CsvWriter(writer, config))
            {
                await csv.WriteRecordsAsync(reportes);
            }
        }

        public async static Task ExportarReporte<T>(FileInfo destino, IEnumerable<T> reportes = null, ReporteFiltroModelo reporteFiltro = null) where T: IReporte
        {
            if (reportes != null)
            {
                await GuardarCsvReporteAsync<T>(destino, reportes);
                return;
            }

            await ExportarReportePaginacion<T>(destino, reporteFiltro);
        }

        public static async Task ExportarReportePaginacion<T>(FileInfo destino, ReporteFiltroModelo reporteFiltro) where T: IReporte
        {
            List<T> reportes;
            int? comienzo = null;

            do
            {
                reportes = await Task.Run(() => ConfigGlobal.conexion.CargarReporte<T>
                                            (
                                                filtro: reporteFiltro,
                                                limiteFilas: filasPaginacion,
                                                comienzo: comienzo
                                            ));
                await GuardarCsvReporteAsync(destino, reportes);
                comienzo = reportes.LastOrDefault()?.ReporteId;
            } while (reportes.Count > 0);
        }
    }
}
