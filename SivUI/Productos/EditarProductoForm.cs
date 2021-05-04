using SivBiblioteca;
using SivBiblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SivUI.Categorias;

namespace SivUI.Productos
{
    public partial class EditarProductoForm : Form, ISolicitudProducto, ISolicitudCategorias
    {
        ProductoModelo producto;
        public EditarProductoForm()
        {
            InitializeComponent();
        }

        public void ProductoListo(ProductoModelo producto)
        {
            if (producto == null) return;

            this.producto = producto;
            nombre_producto_tb.Text = producto.Nombre;
            nuevo_nombre_tb.Text = producto.Nombre;
            descripcion_tb.Text = producto.Descripcion;
            nueva_descripcion_tb.Text = producto.Descripcion;

            try
            {
                this.producto.Categorias = ConfigGlobal.conexion.CargarCategorias_PorProductoId(producto.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ActualizarCategorias();
        }

        private void ActualizarCategorias()
        {
            categorias_listbox.DataSource = null;

            if (producto != null)
            {
                categorias_listbox.DataSource = producto.Categorias;
            }
            categorias_listbox.DisplayMember = nameof(CategoriaModelo.Nombre);
        }

        private void buscar_producto_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new BuscarProductoForm(this);
            frm.ShowDialog();
        }

        private void remover_categorias_button_Click(object sender, EventArgs e)
        {
            if (producto == null) return;

            var categoriasSeleccionadas = categorias_listbox.SelectedItems.Cast<CategoriaModelo>().ToList();

            foreach (var categoria in categoriasSeleccionadas)
            {
                producto.Categorias.Remove(categoria);
            }
            ActualizarCategorias();
        }

        private void agregar_categorias_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new BuscarCategoriasForm(this);
            frm.ShowDialog();
        }

        public void CategoriasListas(List<CategoriaModelo> categorias)
        {
            if (producto == null) return;
            foreach (var categoria in categorias)
            {
                if (producto.Categorias.Find(c => c.Id == categoria.Id) != null) continue;
                producto.Categorias.Add(categoria);
            }
            ActualizarCategorias();
        }

        private void crear_categoria_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new CrearCategoriaForm(this);
            frm.ShowDialog();
        }

        private void editar_button_Click(object sender, EventArgs e)
        {
            if (producto == null) return;

            var nuevoNombre = nuevo_nombre_tb.Text.Trim();

            if (string.IsNullOrEmpty(nuevoNombre))
            {
                MessageBox.Show("El nuevo nombre no puede estar en blanco.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show("¿Desea realizar los cambios?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultado == DialogResult.No) return;

            producto.Nombre = nuevoNombre;
            producto.Descripcion = nueva_descripcion_tb.Text.Trim();

            try
            {
                ConfigGlobal.conexion.EditarProducto(producto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Tarea completada.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarForm();
        }

        private void LimpiarForm()
        {
            producto = null;
            nombre_producto_tb.Clear();
            nombre_producto_tb.Focus();
            nuevo_nombre_tb.Clear();
            nueva_descripcion_tb.Clear();
            descripcion_tb.Clear();
            ActualizarCategorias();
        }
    }
}
