using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca.Modelos
{
    public class VentaModelo
    {
        public int Id { get; set; }
        public string Fecha { get; set; }
        public LoteModelo Lote { get; set; }
        public int LoteId { get { return Lote.Id; } }      
        public string ProductoDescripcion { get { return Lote.Producto.Descripcion;  } }
        public string ProductoNombre { get { return Lote.Producto.Nombre; } }
        public int Unidades { get; set; }
        public decimal PrecioVentaUnidad { get; set; }
        public decimal Total { get { return PrecioVentaUnidad * Unidades;  } }
        public ClienteModelo Cliente { get; set; }
        public string Comentario { get; set; }
        public int? ClienteId
        { get
            {
                if (Cliente == null) { return null; }
                else { return Cliente.Id;  }
            }
        }
    }
}
