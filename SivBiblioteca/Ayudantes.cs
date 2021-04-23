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
            if (x == null) return false;

            x = string.Concat(x.Where(c => !char.IsWhiteSpace(c)));

            if (string.IsNullOrEmpty(x)) return false;

            int intX = 0;
            bool xEsEntero = int.TryParse(x, out intX);

            return xEsEntero && (intX > 0);
        }

        public static bool EsEnteroNoNegativo(string x)
        {
            if (x == null) return false;

            x = string.Concat(x.Where(c => !char.IsWhiteSpace(c)));

            if (string.IsNullOrEmpty(x)) return false;

            int intX = 0;
            bool xEsEntero = int.TryParse(x, out intX);

            return xEsEntero && (intX >= 0);
        }

        public static bool EsDecimalNoNegativo(string x)
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
