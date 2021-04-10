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

namespace SivUI
{
    public partial class CrearFiltroForm : Form, ISolicitudCategoria, ISolicitudCliente, ISolicitudProducto
    {
        List<CategoriaModelo> categoriasSeleccionadas = new List<CategoriaModelo>();
        ProductoModelo producto;
        ClienteModelo cliente;

        ISolicitudFiltro solicitante;

        public CrearFiltroForm(ISolicitudFiltro solicitante, ReporteFiltroModelo filtro = null)
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
                }

                filtrar_por_fechas_groupbox.Enabled = filtro.FiltroPorFechas;
                habilitar_fechas_checkbox.Checked = filtro.FiltroPorFechas;

                if (filtro.FiltroPorCliente && filtro.Cliente != null)
                {
                    cliente = filtro.Cliente;
                    cliente_tb.Text = cliente.NombreCompleto;
                }

                filtrar_por_cliente_groupbox.Enabled = filtro.FiltroPorCliente;
                filtrar_por_cliente_checkbox.Checked = filtro.FiltroPorCliente;

                if (filtro.FiltroPorProducto && filtro.Producto != null)
                {
                    producto = filtro.Producto;
                    nombre_producto_tb.Text = filtro.Producto.Nombre;
                }

                filtrar_por_producto_groupbox.Enabled = filtro.FiltroPorProducto;
                filtrar_por_producto_checkbox.Checked = filtro.FiltroPorProducto;

                categoriasSeleccionadas = filtro.Categorias;
                ActualizarCategorias();
            }
        }

        private void ActualizarCategorias()
        {
            categorias_listbox.DataSource = null;
            categorias_listbox.DataSource = categoriasSeleccionadas;
            categorias_listbox.DisplayMember = nameof(CategoriaModelo.Nombre);
        }

        private void habilitar_fechas_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            filtrar_por_fechas_groupbox.Enabled = habilitar_fechas_checkbox.Checked;
        }

        private void agregar_categorias_button_Click(object sender, EventArgs e)
        {
            var frm = new BuscarCategoriasForm(this);
            frm.Show();
        }

        public void CategoriasListas(List<CategoriaModelo> categorias)
        {
            foreach(var categoria in categorias)
            {
                categoriasSeleccionadas.Add(categoria);
            }
            ActualizarCategorias();
        }

        private void remover_categoria_button_Click(object sender, EventArgs e)
        {
            var seleccion = categorias_listbox.SelectedItems.Cast<CategoriaModelo>().ToList();

            foreach (var categoria in seleccion)
            {
                categoriasSeleccionadas.Remove(categoria);
            }
            ActualizarCategorias();
        }

        private void listo_button_Click(object sender, EventArgs e)
        {
            var filtro = new ReporteFiltroModelo();

            filtro.Categorias = categoriasSeleccionadas;
            filtro.FechaInicial = fecha_inicial_dtp.Value.Date;
            filtro.FechaFinal = fecha_final_dtp.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            filtro.FiltroPorFechas = habilitar_fechas_checkbox.Checked;
            
            if (filtrar_por_producto_checkbox.Checked)
            {
                filtro.Producto = producto;
                filtro.FiltroPorProducto = true;
            }

            if (filtrar_por_cliente_checkbox.Checked && cliente != null)
            {
                filtro.Cliente = cliente;
                filtro.FiltroPorCliente = true;
            }

            solicitante.FiltroCreado(filtro);
            MessageBox.Show("Filtro configurado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void buscar_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new BuscarClienteForm(this);
            frm.Show();
        }

        public void ClienteListo(ClienteModelo cliente)
        {
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
            frm.Show();
        }

        public void ProductoListo(ProductoModelo producto)
        {
            if (producto == null) return;
            this.producto = producto;
            nombre_producto_tb.Text = producto.Nombre;
        }
    }
}
