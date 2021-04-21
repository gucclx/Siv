using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca.Modelos
{
    /// <summary>
    ///     Representa un producto en el inventario con informacion acerca de las unidades
    ///     disponibles totales y la inversion / costo de estas.
    ///     Los atributos representan los titulos y orden de las columnas a la hora de exportar
    ///     los reportes a un archivo .csv utilizando la biblioteca CvsHelper.
    ///     El atributo ignore le pide a CsvHelper ignorar la propiedad.
    /// </summary>
    public class ReporteInventarioModelo
    {
        [Ignore]
        public int IdProducto { get; set; }

        [Name("Producto")]
        [Index(0)]
        public string NombreProducto { get; set; }

        [Name("Descripción")]
        [Index(1)]
        public string DescripcionProducto { get; set; }

        [Name("Unidades")]
        [Index(2)]
        public int UnidadesProducto { get; set; }

        [Name("Inversión Unidades")]
        [Index(3)]
        public decimal InversionUnidadesProducto { get; set; }
    }
}
