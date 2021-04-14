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

namespace SivUI
{
    public partial class CrearProductoForm : Form, ISolicitudCategoria
    {
        List<CategoriaModelo> categoriasSeleccionadas = new List<CategoriaModelo>();
        ISolicitudProducto solicitante;
        public CrearProductoForm(ISolicitudProducto solicitante = null)
        {
            InitializeComponent();
            ActualizarCategorias();
            this.solicitante = solicitante;
        }

        /// <summary>
        /// Actualiza la lista de categorias presentadas en el listbox.
        /// </summary>
        private void ActualizarCategorias()
        {
            categorias_seleccionadas_listbox.DataSource = null;
            categorias_seleccionadas_listbox.DataSource = categoriasSeleccionadas;
            categorias_seleccionadas_listbox.DisplayMember = nameof(CategoriaModelo.Nombre);
        }

        private void remover_categoria_button_Click(object sender, EventArgs e)
        {
            var categoriasARemover = categorias_seleccionadas_listbox.SelectedItems.Cast<CategoriaModelo>().ToList();

            foreach(var categoria in categoriasARemover)
            {
                categoriasSeleccionadas.Remove(categoria);
            }

            ActualizarCategorias();
        }

        private void crear_producto_button_Click(object sender, EventArgs e)
        {
            // validar nombre
            var productoNombre = nombre_producto_tb.Text.Trim();
            if (string.IsNullOrEmpty(productoNombre))
            {
                MessageBox.Show("Nombre inválido", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // verificar que el nombre del producto no exista en la base de datos

            bool productoExiste = false;
            
            try
            {
                productoExiste = ConfigGlobal.conexion.ProductoExiste(productoNombre);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (productoExiste)
            {
                MessageBox.Show("El nombre del producto ya existe en la base de datos.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // crear producto y guardar en la base de datos

            var producto = new ProductoModelo();
            producto.Nombre = productoNombre;
            producto.Descripcion = descripcion_tb.Text.Trim();
            producto.Categorias = categoriasSeleccionadas;

            try
            {
                ConfigGlobal.conexion.GuardarProducto(producto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // limpiar form
            nombre_producto_tb.Clear();
            nombre_producto_tb.Focus();
            descripcion_tb.Clear();
            categoriasSeleccionadas = new List<CategoriaModelo>();
            ActualizarCategorias();

            // Pasar el producto al form solicitante.
            if (solicitante != null)
            {
                solicitante.ProductoListo(producto);
            }
            
            MessageBox.Show("Tarea completada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CategoriasListas(List<CategoriaModelo> categorias)
        {
            foreach (var categoria in categorias)
            {
                if (categoriasSeleccionadas.Find(c => c.Id == categoria.Id) != null) continue;

                categoriasSeleccionadas.Add(categoria);
            }
            ActualizarCategorias();
        }

        private void nueva_categoria_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new CrearCategoriaForm(this);
            frm.ShowDialog();
        }

        private void buscar_categoria_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new BuscarCategoriasForm(this);
            frm.ShowDialog();
        }
    }
}
