using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca.Modelos
{
    /// <summary>
    ///     Representa un reporte de ventas.
    ///     Los atributos especifican los titulos y el orden de las columnas
    ///     a la hora de exportar los reportes a un archivo .csv usando la biblioteca CsvHelper.
    ///     El atributo Ignore le pide a CsvHelper ignorar la propiedad.
    /// </summary>
    public class ReporteVentaModelo
    {
        [Ignore]
        public decimal InversionLote { get; set; }

        [Ignore]
        public int UnidadesCompradasLote { get; set; }

        [Name("ID lote")]
        [Index(0)]
        public int LoteId { get; set; }

        [Name("Producto")]
        [Index(1)]
        public string NombreProducto { get; set; }

        [Name("Unidades Vendidas")]
        [Index(2)]
        public int UnidadesVendidas { get; set; }

        [Name("Inversión Unidad")]
        [Index(3)]
        public decimal InversionUnidad { get { return InversionLote / UnidadesCompradasLote; } }

        [Name("Precio Venta Unidad")]
        [Index(4)]
        public decimal PrecioVentaUnidad { get; set; }

        [Name("Inversión Venta")]
        [Index(5)]
        public decimal InversionVenta { get { return UnidadesVendidas * InversionUnidad; } }

        [Name("Ingreso Venta")]
        [Index(6)]
        public decimal IngresoVenta { get { return UnidadesVendidas * PrecioVentaUnidad; } }

        [Name("Ganancia Venta")]
        [Index(7)]
        public decimal GananciaVenta { get { return IngresoVenta - InversionVenta; } }

        [Name("Fecha Venta")]
        [Index(8)]
        public string FechaVenta { get; set; }

        [Name("Cliente")]
        [Index(9)]
        public string NombreCliente { get; set; }
    }
}
