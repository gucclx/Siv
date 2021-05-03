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
        int? UnidadesDisponiblesLote(int productoId);
        void GuardarCliente(ClienteModelo cliente);
        void GuardarLote(LoteModelo lote);
        bool ProductoExiste(string nombre);
        void EditarProducto(ProductoModelo producto);
        void EditarLote(LoteModelo lote);
        void EditarCliente(ClienteModelo cliente);
        VentaModelo CargarVenta_PorId(int id);
        void EliminarVenta(int id);
        List<T> CargarReporte<T>(ReporteFiltroModelo filtro = null, int? limiteFilas = null, int? comienzo = null);
        List<T> BuscarModelo_PorNombre<T>(string nombre, int? limiteFilas = 10);
    }
}
