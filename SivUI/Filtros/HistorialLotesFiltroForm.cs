using SivBiblioteca.Modelos;
using SivUI.Categorias;
using SivUI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SivUI.Filtros
{
    public partial class HistorialLotesFiltroForm : Form, ISolicitudProducto, ISolicitudCategorias
    {
        List<CategoriaModelo> categoriasSeleccionadas = new List<CategoriaModelo>();
        ProductoModelo producto;
        ISolicitudFiltro solicitante;

        public HistorialLotesFiltroForm(ISolicitudFiltro solicitante, ReporteFiltroModelo filtro = null)
        {
            InitializeComponent();

            this.solicitante = solicitante;

            // Cargar filtro anterior
            if (filtro != null)
            {
                if (filtro.FiltroPorFechas)
                {
                    if (filtro.FechaInicial != null) { fecha_inicial_dtp.Value = filtro.FechaInicial; }
                    if (filtro.FechaFinal != null) { fecha_final_dtp.Value = filtro.FechaFinal; }

                    filtrar_por_fechas_groupbox.Enabled = filtro.FiltroPorFechas;
                    habilitar_fechas_checkbox.Checked = filtro.FiltroPorFechas;
                }

                if (filtro.FiltroPorProducto && filtro.Producto != null)
                {
                    producto = filtro.Producto;
                    nombre_producto_tb.Text = filtro.Producto.Nombre;

                    filtrar_por_producto_groupbox.Enabled = filtro.FiltroPorProducto;
                    filtrar_por_producto_checkbox.Checked = filtro.FiltroPorProducto;
                }

                if (filtro.Categorias != null)
                {
                    categoriasSeleccionadas = filtro.Categorias;
                    ActualizarCategorias();
                }

                no_incluir_lotes_sin_unidades_checkbox.Checked = !filtro.IncluirLotesSinUnidades;
            }
        }

        private void habilitar_fechas_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            filtrar_por_fechas_groupbox.Enabled = habilitar_fechas_checkbox.Checked;
        }

        private void filtrar_por_producto_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            filtrar_por_producto_groupbox.Enabled = filtrar_por_producto_checkbox.Checked;
        }

        private void listo_button_Click(object sender, EventArgs e)
        {
            var filtro = new ReporteFiltroModelo();

            filtro.FechaInicial = fecha_inicial_dtp.Value.Date;
            filtro.FechaFinal = fecha_final_dtp.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            filtro.FiltroPorFechas = habilitar_fechas_checkbox.Checked;

            filtro.Producto = producto;
            filtro.FiltroPorProducto = filtrar_por_producto_checkbox.Checked;

            filtro.Categorias = categoriasSeleccionadas;

            filtro.IncluirLotesSinUnidades = !no_incluir_lotes_sin_unidades_checkbox.Checked;

            solicitante.FiltroCreado(filtro);
            MessageBox.Show("Filtro configurado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        public void ProductoListo(ProductoModelo producto)
        {
            if (producto == null) return;
            this.producto = producto;
            nombre_producto_tb.Text = producto.Nombre;
        }

        private void buscar_producto_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new BuscarProductoForm(this);
            frm.ShowDialog();
        }
        private void agregar_categorias_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new BuscarCategoriasForm(this);
            frm.ShowDialog();
        }

        public void CategoriasListas(List<CategoriaModelo> categorias)
        {
            if (categorias == null) return;
            foreach (var categoria in categorias)
            {
                // Existe ya la categoria en la lista?
                if (categoriasSeleccionadas.Find(c => c.Id == categoria.Id) != null) continue;

                categoriasSeleccionadas.Add(categoria);
            }
            ActualizarCategorias();
        }

        private void ActualizarCategorias()
        {
            categorias_seleccionadas_listbox.DataSource = null;
            categorias_seleccionadas_listbox.DataSource = categoriasSeleccionadas;
            categorias_seleccionadas_listbox.DisplayMember = nameof(CategoriaModelo.Nombre);
        }

        private void remover_categoria_button_Click(object sender, EventArgs e)
        {
            var categoriasARemover = categorias_seleccionadas_listbox.SelectedItems.Cast<CategoriaModelo>().ToList();
            
            foreach (var categoria in categoriasARemover)
            {
                categoriasSeleccionadas.Remove(categoria);
            }
            ActualizarCategorias();
        }
    }
}
