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
    }
}
