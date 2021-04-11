using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca.Modelos
{
    public class LoteModelo
    {
        public int Id { get; set; }
        public ProductoModelo Producto { get; set; }
        public int ProductoId { get; set; }
        public int UnidadesDisponibles { get; set; }
        public int UnidadesCompradas { get; set; }
        public decimal Inversion { get; set; }
        public decimal InversionUnidad { get { return Inversion / UnidadesCompradas; } }
        public decimal PrecioVentaUnidad { get; set; }
        public string FechaCreacion { get; set; }

    }
}
