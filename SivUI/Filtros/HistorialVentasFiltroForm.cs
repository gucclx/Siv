using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SivBiblioteca.Modelos;
using SivBiblioteca;
using SivUI.Categorias;
using SivUI.Interfaces;

namespace SivUI
{
    public partial class HistorialVentasFiltroForm : Form, ISolicitudCliente, ISolicitudProducto, ISolicitudCategorias
    {
        ProductoModelo producto;
        ClienteModelo cliente;
        List<CategoriaModelo> categoriasSeleccionadas = new List<CategoriaModelo>();
        ISolicitudFiltro solicitante;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="solicitante"> Form que solicita el filtro. </param>
        /// <param name="filtro"> Filtro anterior o preconfigurado a cargar. </param>
        public HistorialVentasFiltroForm(ISolicitudFiltro solicitante, ReporteFiltroModelo filtro = null)
        {
            InitializeComponent();
            this.solicitante = solicitante;

            // Cargar filtro anterior
            if (filtro != null)
            {
                if (filtro.FiltroPorFechas)
                {
                    fecha_inicial_dtp.Value = filtro.FechaInicial;
                    fecha_final_dtp.Value = filtro.FechaFinal;

                    filtrar_por_fechas_groupbox.Enabled = filtro.FiltroPorFechas;
                    habilitar_fechas_checkbox.Checked = filtro.FiltroPorFechas;
                }

                if (filtro.FiltroPorCliente && filtro.Cliente != null)
                {
                    cliente = filtro.Cliente;
                    cliente_tb.Text = cliente.NombreCompleto;

                    filtrar_por_cliente_groupbox.Enabled = filtro.FiltroPorCliente;
                    filtrar_por_cliente_checkbox.Checked = filtro.FiltroPorCliente;
                }

                if (filtro.FiltroPorProducto && filtro.Producto != null)
                {
                    producto = filtro.Producto;
                    nombre_producto_tb.Text = filtro.Producto.Nombre;
                }

                filtrar_por_producto_groupbox.Enabled = filtro.FiltroPorProducto;
                filtrar_por_producto_checkbox.Checked = filtro.FiltroPorProducto;

                if (filtro.Categorias != null)
                {
                    categoriasSeleccionadas = filtro.Categorias;
                    ActualizarCategorias();
                }
            }
        }

        private void habilitar_fechas_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            filtrar_por_fechas_groupbox.Enabled = habilitar_fechas_checkbox.Checked;
        }

        private void listo_button_Click(object sender, EventArgs e)
        {
            var filtro = new ReporteFiltroModelo();

            filtro.FechaInicial = fecha_inicial_dtp.Value.Date;
            filtro.FechaFinal = fecha_final_dtp.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            filtro.FiltroPorFechas = habilitar_fechas_checkbox.Checked;

            filtro.Producto = producto;
            filtro.FiltroPorProducto = filtrar_por_producto_checkbox.Checked;

            filtro.Cliente = cliente;
            filtro.FiltroPorCliente = filtrar_por_cliente_checkbox.Checked;

            filtro.Categorias = categoriasSeleccionadas;

            solicitante.FiltroCreado(filtro);
            MessageBox.Show("Filtro configurado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void buscar_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new BuscarClienteForm(this);
            frm.ShowDialog();
        }

        public void ClienteListo(ClienteModelo cliente)
        {
            if (cliente == null) return;
            this.cliente = cliente;
            cliente_tb.Text = cliente.NombreCompleto;
        }

        private void filtrar_por_producto_CheckedChanged(object sender, EventArgs e)
        {
           filtrar_por_producto_groupbox.Enabled = filtrar_por_producto_checkbox.Checked;
        }

        private void filtrar_por_cliente_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            filtrar_por_cliente_groupbox.Enabled = filtrar_por_cliente_checkbox.Checked;
        }

        private void buscar_producto_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new BuscarProductoForm(this);
            frm.ShowDialog();
        }

        public void ProductoListo(ProductoModelo producto)
        {
            if (producto == null) return;
            this.producto = producto;
            nombre_producto_tb.Text = producto.Nombre;
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
