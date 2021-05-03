using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca.Modelos
{
    public class CategoriaModelo
    {
        string nombre;
        public int Id { get; set; }
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre de la categoria no debe estar en blanco o ser null.");
                }
                nombre = value.Trim();
            }
        }
    }
}
