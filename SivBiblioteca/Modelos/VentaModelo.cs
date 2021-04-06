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
        public ProductoModelo Producto { get; set; }
        public int ProductoId { get { return Producto.Id;  } }
        public decimal ProductoPrecioVenta { get { return Producto.PrecioVenta; } set { Producto.PrecioVenta = value; } }
        public string ProductoDescripcion { get { return Producto.Descripcion;  } }
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
