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
        List<CategoriaModelo> CargarCategorias_PorProductoId(int id);
        bool CategoriaExiste(string nombreCategoria);
        void EliminarCategorias(List<CategoriaModelo> categorias);
        void GuardarProducto(ProductoModelo producto);
        int CargarUltimoLoteId();
        LoteModelo CargarLote_PorId(int id);
        void GuardarVentas(List<VentaModelo> ventas);
        int UnidadesDisponiblesLote(int productoId);
        void GuardarCliente(ClienteModelo cliente);
        List<ClienteModelo> BuscarCliente_PorNombre(string nombre, int limiteFilas = 10);
        List<ReporteVentaModelo> CargarReporteVentas(ReporteFiltroModelo filtro = null, int? limiteFilas = null, int? comienzo = null);
        List<ReporteLoteModelo> CargarReporteLotes(ReporteFiltroModelo filtro = null, int? limiteFilas = null, int? comienzo = null);
        void GuardarLote(LoteModelo lote);
        bool ProductoExiste(string nombre);
        List<CategoriaModelo> BuscarCategoria_PorNombre(string nombre, int limiteFilas = 10);
        List<ProductoModelo> BuscarProducto_PorNombre(string nombre, int limiteFilas = 10);
        void EditarProducto(ProductoModelo producto);
        void EditarLote(LoteModelo lote);
        void EditarCliente(ClienteModelo cliente);
        List<ReporteInventarioModelo> CargarReporteInventario(ReporteFiltroModelo filtro, int? limiteFilas = null, int? comienzo = null);
    }
}
