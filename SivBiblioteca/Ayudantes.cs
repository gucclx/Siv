using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca
{
    public static class Ayudantes
    {
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
    }
}
