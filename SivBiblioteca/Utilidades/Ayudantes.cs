using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca.Utilidades
{
    public static class Ayudantes
    {
        public static bool EsEnteroPositivo(this string x)
        {
            if (string.IsNullOrEmpty(x)) return false;

            x = string.Concat(x.Where(c => !char.IsWhiteSpace(c)));

            bool xEsEntero = int.TryParse(x, out int intX);

            return xEsEntero && (intX > 0);
        }

        public static bool EsEnteroNoNegativo(this string x)
        {
            if (string.IsNullOrEmpty(x)) return false;

            x = string.Concat(x.Where(c => !char.IsWhiteSpace(c)));

            bool xEsEntero = int.TryParse(x, out int intX);

            return xEsEntero && (intX >= 0);
        }

        public static bool EsDecimalNoNegativo(this string x)
        {
            if (string.IsNullOrEmpty(x)) return false;

            x = string.Concat(x.Where(c => !char.IsWhiteSpace(c)));

            bool xEsDecimal = decimal.TryParse(x, out decimal decimalX);

            return xEsDecimal && (decimalX >= 0);
        }
    }
}
