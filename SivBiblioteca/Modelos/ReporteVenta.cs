using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca.Modelos
{
    public class ReporteVenta
    {
        public int LoteId { get; set; }
        public string NombreProducto { get; set; }
        public int UnidadesVendidas { get; set; }
        public decimal InversionUnidad { get; set; }
        public decimal InversionVenta { get { return UnidadesVendidas * InversionUnidad; } }
        public decimal PrecioVentaUnidad { get; set; }
        public decimal IngresoVenta { get { return PrecioVentaUnidad* UnidadesVendidas; } }
        public decimal GananciaVenta { get { return IngresoVenta - InversionVenta; } }
        public string FechaVenta { get; set; }
        public string NombreCliente { get; set; }
    }
}
