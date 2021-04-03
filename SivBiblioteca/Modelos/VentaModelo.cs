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
        public int Fecha { get; set; }
        public ProductoModelo Producto { get; set; }
        public int ProductoId { get { return Producto.Id;  } }
        public decimal ProductoPrecioVenta { get { return Producto.PrecioVenta; } set { } }
        public string ProductoDescripcion { get { return Producto.Descripcion;  } }
        public int Unidades { get; set; }
    }
}
