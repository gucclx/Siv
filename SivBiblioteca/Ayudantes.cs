using CsvHelper;
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
        
        public static async Task GuardarCsvReporteVentasAsync(List<ReporteVentaModelo> reportes, FileInfo archivo)
        {
            if (archivo.Exists)
            {
                archivo.Delete();
            }

            using (var stream = File.OpenWrite(archivo.FullName))
            using (var writer = new StreamWriter(stream, Encoding.UTF8))
            using (var csv = new CsvWriter(writer, CultureInfo.CurrentCulture))
            {
                await csv.WriteRecordsAsync(reportes);
            }
        }

        public static async Task GuardarCsvReporteInventarioAsync(List<ReporteInventarioModelo> reportes, FileInfo archivo)
        {
            if (archivo.Exists)
            {
                archivo.Delete();
            }

            using (var stream = File.OpenWrite(archivo.FullName))
            using (var writer = new StreamWriter(stream, Encoding.UTF8))
            using (var csv = new CsvWriter(writer, CultureInfo.CurrentCulture))
            {
                await csv.WriteRecordsAsync(reportes);
            }
        }
    }
}
