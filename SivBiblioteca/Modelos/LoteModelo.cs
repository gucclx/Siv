using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca.Modelos
{
    public class LoteModelo
    {
        uint unidadesCompradas;
        decimal inversion;
        decimal precioVentaUnidad;

        public int Id { set; get; }
        public ProductoModelo Producto { get; set; }
        public uint UnidadesDisponibles { set; get; }
        public uint UnidadesCompradas
        {
            get => unidadesCompradas;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("La cantidad de unidades compradas no pueden ser menor a 1.");
                }
                unidadesCompradas = value;
            }
        }
        public decimal Inversion
        {
            get => inversion;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("La inversión no debe ser negativa.");
                }
                inversion = value;
            }
        }
        public decimal InversionUnidad => Inversion / UnidadesCompradas;
        public decimal PrecioVentaUnidad
        {
            get => precioVentaUnidad;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("El precio de venta de la unidad no debe ser negativo.");
                }
                precioVentaUnidad = value;
            }
        }
        public string FechaCreacion { get; set; }
    }
}
