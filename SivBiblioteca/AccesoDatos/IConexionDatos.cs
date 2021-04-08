using SivBiblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca.AccesoDatos
{
    public interface IConexionDatos
    {
        void GuardarCategorias(List<CategoriaModelo> categoria);
        List<CategoriaModelo> CargarCategorias();
        bool CategoriaExiste(string nombreCategoria);
        void EliminarCategorias(List<CategoriaModelo> categorias);
        void GuardarProducto(ProductoModelo producto);
        int CargarUltimoLoteId();
        LoteModelo CargarLote_PorId(int id);
        void GuardarVentas(List<VentaModelo> ventas);
        int UnidadesExistentesLote(int productoId);
        void GuardarCliente(ClienteModelo cliente);
        List<ClienteModelo> BuscarCliente_PorNombre(string nombre);
        List<ReporteVenta> ReporteVentas(ReporteFiltro filtro, int? limiteFilas);
        List<ProductoModelo> CargarProductos();
        void GuardarLote(LoteModelo lote);
        bool ProductoExiste(string nombre);
        List<CategoriaModelo> BuscarCategoria_PorNombre(string nombre);
    }
}
