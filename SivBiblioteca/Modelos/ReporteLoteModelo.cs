using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca.Modelos
{
    /// <summary>
    ///     Representa un reporte de lotes para presentar un historial 
    ///     de la adquisicion de estos con sus detalles.
    ///     Los atributos especifican los titulos y el orden de las columnas
    ///     a la hora de exportar los reportes a un archivo .csv usando la biblioteca CsvHelper.
    /// </summary>
    public class ReporteLoteModelo
    {
        [Name("Producto")]
        [Index(0)]
        public string NombreProducto { get; set; }

        [Name("Descripción")]
        [Index(1)]
        public string DescripcionProducto { get; set; }

        [Name("Precio Venta Unidad")]
        [Index(2)]
        public decimal PrecioVentaUnidad { get; set; }

        [Name("ID lote")]
        [Index(3)]
        public int LoteId { get; set; }

        [Name("Unidades compradas")]
        [Index(4)]
        public int UnidadesCompradasLote { get; set; }

        [Name("Unidades disponibles")]
        [Index(5)]
        public int UnidadesDisponiblesLote { get; set; }

        [Name("Inversión Unidad")]
        [Index(6)]
        public decimal InversionUnidad { get { return InversionLote / UnidadesCompradasLote; } }

        [Name("Inversión total")]
        [Index(7)]
        public decimal InversionLote { get; set; }

        [Name("Fecha agregado")]
        [Index(8)]
        public string FechaAgregado { get; set; }
    }
}
