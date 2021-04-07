using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca.Modelos
{
    /// <summary>
    /// Representa un filtro para el reporte de ventas o inventario.
    /// El filtro luego se utiliza para determinar las condiciones de los queries en la base de datos.
    /// </summary>
    public class ReporteFiltro
    {
        public List<int> ProductoIds { get; set; } = new List<int>();
        public List<int> LoteIds { get; set; } = new List<int>();
        public List<CategoriaModelo> Categorias { get; set; } = new List<CategoriaModelo>();
        public int ClienteId { get; set; }
        public DateTime FechaInicial { get; set; } = new DateTime();
        public DateTime FechaFinal { get; set; } = new DateTime();
        public bool FiltroPorFechas { get; set; } = false;

    }
}
