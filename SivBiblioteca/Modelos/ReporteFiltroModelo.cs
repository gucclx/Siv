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
    /// <remarks>
    /// Las propiedades solo son utilizadas donde tenga sentido.
    /// ej. Si se genera un reporte de inventario
    /// y se utiliza un filtro, se podria filtrar por producto
    /// o categorias, pero la propiedad Cliente no se utiliza
    /// ya que en ese contexto no existe ningun cliente.
    /// Por lo tanto, esta clase representa un filtro general donde algunas
    /// propiedades no son utilizadas dependiendo del contexto.
    /// </remarks>
    public class ReporteFiltroModelo
    {
        /// <summary>
        /// Producto por el cual se desea filtrar.
        /// </summary>
        public ProductoModelo Producto { get; set; }

        /// <summary>
        /// Categorias por las cuales se desean filtrar.
        /// </summary>
        public List<CategoriaModelo> Categorias { get; set; }

        /// <summary>
        /// Cliente por el cual se desea filtrar.
        /// </summary>
        public ClienteModelo Cliente { get; set; }

        /// <summary>
        /// Fecha inicial por la que se desea filtrar.
        /// </summary>
        public DateTime FechaInicial { get; set; }

        /// <summary>
        /// Fecha final por la que se desea filtrar.
        /// </summary>
        public DateTime FechaFinal { get; set; }

        // Describen si se desean filtrar por fechas, clientes o productos.
        // Se utilizan en la interfaz para que cuando se cargue un filtro ya existente,
        // se habiliten o deshabiliten los checkboxes en las ventanas filtros,
        // simplemente realizando miCheckbox.Checked = FiltroPor...;
        // Tambien se utilizan en el backend cuando se generan reportes.
        // No necesariamente se deben implementar estas propiedades,
        // por lo que se podria intentar cambiar el codigo a
        // miCheckbox.Checked = filtro.FechaInicial != null && filtro.FechaFinal != null;
        // o algo similar.
        public bool FiltroPorFechas { get; set; } = false;
        public bool FiltroPorCliente { get; set; } = false;
        public bool FiltroPorProducto { get; set; } = false;

        /// <summary>
        /// Si se deben incluir lotes sin unidades disponibles o no
        /// a la hora de generar un reporte de lotes.
        /// </summary>
        public bool IncluirLotesSinUnidades { get; set; } = true;

        /// <summary>
        /// Si se deben incluir productos sin unidades disponibles o no
        /// a la hora de generar un reporte de inventario.
        /// </summary>
        public bool IncluirProductosSinUnidades { get; set; } = false;
    }
}
