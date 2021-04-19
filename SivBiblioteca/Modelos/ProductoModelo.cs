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
        public List<CategoriaModelo> Categorias { get; set; } = new List<CategoriaModelo>();
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string FechaCreacion { get; set; }

    }
}
