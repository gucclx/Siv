using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca.Modelos
{
    /// <summary>
    ///     Representa un filtro para el historial de ventas, lotes, o inventario.
    ///     El filtro se utiliza para determinar las condiciones de los queries en la base de datos.
    /// </summary>
    public class ReporteFiltroModelo
    {
        public ProductoModelo Producto { get; set; }
        public int? LoteId { get; set; }
        public List<CategoriaModelo> Categorias { get; set; }
        public ClienteModelo Cliente { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public bool FiltroPorFechas { get; set; } = false;
        public bool FiltroPorCliente { get; set; } = false;
        public bool FiltroPorProducto { get; set; } = false;

        public bool IncluirLotesSinUnidades = true;
    }
}
