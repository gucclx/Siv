using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca.Modelos
{
    public class ProductoModelo
    {
        string nombre;
        public int Id { get; set; }
        public List<CategoriaModelo> Categorias { get; set; } = new List<CategoriaModelo>();
        public string Descripcion { get; set; }
        public string Nombre
        {
            get => nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre del producto no debe estar en blanco o ser null.");
                }
                nombre = value.Trim();
            }
        }
    }
}
