using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca.Modelos
{
    public class ReporteInventarioModelo
    {
        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public int UnidadesDisponiblesProducto { get; set; }
        public decimal ValorUnidadesDisponiblesProducto { get; set; }
    }
}
