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
    public static class Ayudantes
    {
        //delegate List<T> cargarFuncion<T>(ReporteFiltroModelo filtro, int? limiteFilas, int? comienzo);

        public static bool EsEnteroPositivo(this string x)
        {
            if (x == null) return false;

            x = string.Concat(x.Where(c => !char.IsWhiteSpace(c)));

            if (string.IsNullOrEmpty(x)) return false;

            int intX = 0;
            bool xEsEntero = int.TryParse(x, out intX);

            return xEsEntero && (intX > 0);
        }

        public static bool EsEnteroNoNegativo(this string x)
        {
            if (x == null) return false;

            x = string.Concat(x.Where(c => !char.IsWhiteSpace(c)));

            if (string.IsNullOrEmpty(x)) return false;

            int intX = 0;
            bool xEsEntero = int.TryParse(x, out intX);

            return xEsEntero && (intX >= 0);
        }

        public static bool EsDecimalNoNegativo(this string x)
        {
            if (x == null) return false;

            x = string.Concat(x.Where(c => !char.IsWhiteSpace(c)));

            if (string.IsNullOrEmpty(x)) return false;

            decimal decimalX = 0;
            bool xEsDecimal = decimal.TryParse(x, out decimalX);

            return xEsDecimal && (decimalX >= 0);
        }

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

        //public static async Task ExportarReportes<T>(FileInfo destino, ReporteFiltroModelo reporteFiltro) where T : IExpongoReporteId
        //{
        //    List<T> reportes;
        //    int? comienzo = null;
        //    int? limiteFilas = 100_000;

        //    //cargarFuncion<T> f;

        //    //if (typeof(T) == typeof(ReporteLoteModelo))
        //    //{
        //    //    f = ConfigGlobal.conexion.CargarReporteLotes;
        //    //}

        //    // Exportar los resultados mediante paginacion.
        //    do
        //    {
        //        reportes = await Task.Run(() => f(filtro: reporteFiltro, limiteFilas: limiteFilas, comienzo: comienzo));
        //        await Ayudantes.GuardarCsvReporteAsync(reportes, destino);
        //        comienzo = reportes.LastOrDefault()?.ReporteId;
        //    } while (reportes.Count > 0);
        //}
    }
}
