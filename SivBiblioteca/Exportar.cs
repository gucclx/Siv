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
        // todo - cambiar
        /// <summary>
        /// Los reportes a exportar se cargan por paginacion.
        /// Esta variable indica cuantas filas posee cada paginacion.
        /// Util si la cantidad de filas es grande, ya que si no se utiliza se carga
        /// una cantidad innecesaria de objetos a la memoria.
        /// </summary>
        static int? filasPaginacion = 1;

        /// <summary>
        /// Se utiliza para exportar el inventario, historial de compras de lotes o historial de ventas.
        /// Los reportes se exportan a un archivo .csv utilizando la biblioteca CsvHelper.
        /// Si el archivo seleccionado existe, los reportes seran adjuntados al archivo.
        /// Esto es util se se exportan los reportes por paginacion.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reportes"> Reportes a guardar. </param>
        /// <param name="archivo"> Archivo donde se escribiran los reportes. </param>
        /// <returns></returns>
        public static async Task GuardarCsvReporteAsync<T>(IEnumerable<T> reportes, FileInfo destino)
        {
            var config = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = !File.Exists(destino.FullName)
            };

            using (var writer = new StreamWriter(destino.FullName, true, Encoding.UTF8))
            using (var csv = new CsvWriter(writer, config))
            {
                await csv.WriteRecordsAsync(reportes);
            }
        }

        public async static Task ExportarReporte<T>(FileInfo destino, ReporteFiltroModelo reporteFiltro)
        {
            if (typeof(T) == typeof(ReporteLoteModelo))
            {
                await ExportarReporteLotes(destino, reporteFiltro);
            }
            if (typeof(T) == typeof(ReporteVentaModelo))
            {
                await ExportarReporteVentas(destino, reporteFiltro);
            }
            if (typeof(T) == typeof(ReporteInventarioModelo))
            {
                await ExportarReporteInventario(destino, reporteFiltro);
            }
        }

        public static async Task ExportarReporteLotes(FileInfo destino, ReporteFiltroModelo reporteFiltro)
        {
            List<ReporteLoteModelo> reportes;
            int? comienzo = null;

            do
            {
                reportes = await Task.Run(() => ConfigGlobal.conexion.CargarReporteLotes
                                            (
                                                filtro: reporteFiltro,
                                                limiteFilas: filasPaginacion,
                                                comienzo: comienzo
                                            ));
                await GuardarCsvReporteAsync(reportes, destino);
                comienzo = reportes.LastOrDefault()?.LoteId;
            } while (reportes.Count > 0);
        }

        public static async Task ExportarReporteVentas(FileInfo destino, ReporteFiltroModelo reporteFiltro)
        {
            List<ReporteVentaModelo> reportes;
            int? comienzo = null;

            do
            {
                reportes = await Task.Run(() => ConfigGlobal.conexion.CargarReporteVentas
                            (
                                filtro: reporteFiltro,
                                limiteFilas: filasPaginacion,
                                comienzo: comienzo
                            ));
                await GuardarCsvReporteAsync(reportes, destino);
                comienzo = reportes.LastOrDefault()?.VentaId;
            } while (reportes.Count > 0);
        }

        public static async Task ExportarReporteInventario(FileInfo destino, ReporteFiltroModelo reporteFiltro)
        {
            List<ReporteInventarioModelo> reportes;
            int? comienzo = null;

            do
            {
                reportes = await Task.Run(() => ConfigGlobal.conexion.CargarReporteInventario
                            (
                                filtro: reporteFiltro,
                                limiteFilas: filasPaginacion,
                                comienzo: comienzo
                            ));
                await GuardarCsvReporteAsync(reportes, destino);
                comienzo = reportes.LastOrDefault()?.ProductoId;
            } while (reportes.Count > 0);
        }
    }
}
