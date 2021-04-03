using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca.Modelos
{
    public class ProductoModelo
    {
        public int Id { get; set; }
        public List<CategoriaModelo> Categorias { get; set; }
        public decimal PrecioInversion { get; set; }
        public decimal PrecioVenta { get; set; }
        public string FechaCreacion { get; set; }
        public int Unidades { get; set; }
        public string Descripcion { get; set; }

    }
}
