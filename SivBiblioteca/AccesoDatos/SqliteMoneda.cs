using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca.AccesoDatos
{
    /// <summary>
    /// Define la precision de la moneda con la que se trabajara en la base de datos
    /// y provee propiedades utiles para la conversion de la moneda / validacion de la moneda.
    /// y metodos para la conversion de precios.
    /// </summary>
    public static class SqliteMoneda
    {
        // Describe cuantos digitos se consideran despues del punto decimal
        // en todos los precios que se guardan en la base de datos.
        // Si la precision es 2 digitos, todos los precios se guardaran en
        // centavos.

        // Ej. 5.55 cordobas se convierte a 555 centavos.
        // En este caso se conservan 4 digitos despues del decimal, por lo que
        // se trabaja con 'diezmilesimas' es decir 5.55 -> 55500, 6.7899 -> 67899.
        // Los digitos restantes seran truncados.

        // En general si se trabaja con una precision p y
        // un precio x se representara en la base de datos como
        // x * (10^p)
        // una vez extraido de la base de datos se divide por (10^p) para obtener la representacion
        // original x
        const double MonedaPrecision = 4;

        // Factor de conversion para convertir los precios.
        static readonly int factorConversion = Convert.ToInt32(Math.Pow(10, MonedaPrecision));

        // Valor maximo de la moneda que se puede representar.
        static readonly decimal monedaMaximo = Int64.MaxValue / Convert.ToInt32(Math.Pow(10, MonedaPrecision));

        static public decimal MonedaMaximo { get { return monedaMaximo; } }
        static public decimal FactorConversion { get { return factorConversion; } }

        /// <summary>
        ///     x se multiplica por el factor de conversion para obtener 
        ///     la representacion de la moneda que se utilizara en la base de datos.
        ///     los decimales restantes se truncan. 
        ///     Si x * FactorConversion > decimal.MaxValue o x * FactorConversion > Int64.MaxValue se producira una excepcion.
        /// </summary>
        /// <param name="x"> El valor de la moneda en su representacion actual. </param>
        /// <returns> El valor de la moneda en la representacion utilizada en la base de datos. </returns>
        public static long ConvertirAInterna(decimal x)
        {
            return Convert.ToInt64(decimal.Truncate(x * factorConversion));
        }

        public static decimal ConvertirAOriginal(decimal x)
        {
            return x / factorConversion;
        }
    }
}
