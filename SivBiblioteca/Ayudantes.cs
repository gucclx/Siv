using SivBiblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
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

        public static bool EsDecimalNoNegativo(string x)
        {
            x = x.Trim();
            if (string.IsNullOrEmpty(x)) { return false; }

            decimal decimalX = 0;
            bool xEsDecimal = decimal.TryParse(x, out decimalX);

            return xEsDecimal && (decimalX >= 0);
        }

        public static bool EsProductoValido(ProductoModelo producto)
        {
            return ((producto.Unidades > 0) && (producto.PrecioInversion >= 0)) && producto.PrecioVenta >= 0;
        }
        public static DataTable ToDataTable(this IEnumerable<dynamic> items)
        {
            var data = items.ToArray();
            if (data.Count() == 0) return null;

            var dt = new DataTable();
            foreach (var key in ((IDictionary<string, object>)data[0]).Keys)
            {
                dt.Columns.Add(key);
            }
            foreach (var d in data)
            {
                dt.Rows.Add(((IDictionary<string, object>)d).Values.ToArray());
            }
            return dt;
        }
    }
}
