using CsvHelper;
using CsvHelper.Configuration;
using SivBiblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca
{
    public static class Ayudantes
    {
        public static bool EsEnteroPositivo(string x)
        {
            x = x.Trim();
            if (string.IsNullOrEmpty(x)) { return false; }

            int intX = 0;
            bool xEsEntero = int.TryParse(x, out intX);

            return xEsEntero && (intX > 0);
        }

        public static bool EsEnteroNonegativo(string x)
        {
            x = x.Trim();
            if (string.IsNullOrEmpty(x)) { return false; }

            int intX = 0;
            bool xEsEntero = int.TryParse(x, out intX);

            return xEsEntero && (intX >= 0);
        }

        public static bool EsDecimalNoNegativo(string x)
        {
            x = x.Trim();
            if (string.IsNullOrEmpty(x)) { return false; }

            decimal decimalX = 0;
            bool xEsDecimal = decimal.TryParse(x, out decimalX);

            return xEsDecimal && (decimalX >= 0);
        }
        
        /// <summary>
        /// Se utiliza para exportar el inventario, historial de compras de lotes o historial de ventas.
        /// El archivo es de extension .csv.
        /// Si el archivo seleccionado existe, la lista sera adjuntada al archivo.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reportes"> Reportes a guardar. </param>
        /// <param name="archivo"> Archivo donde se escribiran los reportes. </param>
        /// <returns></returns>
        public static async Task GuardarCsvReporteAsync<T>(IEnumerable<T> reportes, FileInfo archivo)
        {
            var config = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = !File.Exists(archivo.FullName)
            };            

            using (var writer = new StreamWriter(archivo.FullName, true, Encoding.UTF8))
            using (var csv = new CsvWriter(writer, config))
            {
                await csv.WriteRecordsAsync(reportes);
            }
        }
    }
}
