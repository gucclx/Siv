using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca.Modelos
{
    public class VentaModelo
    {
        LoteModelo lote;

        public int Id { get; set; }
        public string Fecha { get; set; }
        /// <summary>
        /// Se situa la propiedad loteId por simplicidad a la hora de presentar
        /// la propiedad en un datagridview.
        /// ej. solo se necesita realizar venta.lote = miLote;
        /// en vez de venta.lote = miLote; venta.loteId = miLote.Id;
        /// ya que el DataPropertyName de la columna en el datagridview
        /// sera VentaModelo.LoteId y esta propiedad no soporta propiedades hijas.
        /// </summary>
        public LoteModelo Lote { get { return lote; } set { lote = value; LoteId = value.Id; } }
        public int LoteId { get; set; }
        public string ProductoDescripcion { get { return Lote.Producto.Descripcion;  } }
        public string ProductoNombre { get { return Lote.Producto.Nombre; } }
        public int Unidades { get; set; }
        public decimal PrecioVentaUnidad { get; set; }
        public decimal Total { get { return PrecioVentaUnidad * Unidades;  } }
        public ClienteModelo Cliente { get; set; }
        public string Comentario { get; set; }
        public int ClienteId { get; set; }
    }
}
