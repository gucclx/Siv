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
        uint unidades;
        decimal precioVentaUnidad;

        public int Id { get; set; }
        public string Fecha { get; set; }

        /// <summary>
        /// Se situa la propiedad loteId por simplicidad a la hora de presentar
        /// la propiedad en un datagridview.
        /// ej. solo se necesita realizar venta.lote = miLote;
        /// en vez de venta.lote = miLote; venta.loteId = miLote.Id;
        /// ya que el DataPropertyName de la columna en el datagridview
        /// sera VentaModelo.LoteId y datagridview no soporta propiedades hijas.
        /// </summary>
        public LoteModelo Lote 
        { 
            get { return lote; } 
            set 
            {
                if (value == null)
                {
                    throw new ArgumentException("El lote de la venta no puede ser null.");
                }
                lote = value; 
                LoteId = value.Id; 
            } 
        }
        public int LoteId { get; set; }
        public string ProductoDescripcion { get { return Lote.Producto.Descripcion;  } }
        public string ProductoNombre { get { return Lote.Producto.Nombre; } }
        public uint Unidades
        {
            get { return unidades; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Las cantidad de unidades de la venta no puede ser menor a 1.");
                }
                unidades = value;
            }
        }

        public decimal PrecioVentaUnidad
        {
            get { return precioVentaUnidad; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("El precio de venta de la unidad no debe ser negativo.");
                }
                precioVentaUnidad = value;
            }
        }
        public decimal Total { get { return PrecioVentaUnidad * Unidades;  } }
        public ClienteModelo Cliente { get; set; }
        public string Comentario { get; set; }
    }
}
