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
    // TODO - si no se cierrra el formulario quiza exista un bug potencial donde el frm llamante recibe multiples productos
    public partial class CrearProductoForm : Form, ISolicitudCategoria
    {
        List<CategoriaModelo> categoriasDisponibles = ConfigGlobal.conexion.CargarCategorias();
        List<CategoriaModelo> categoriasSeleccionadas = new List<CategoriaModelo>();
        ISolicitudProducto solicitante;
        public CrearProductoForm(ISolicitudProducto solicitante)
        {
            InitializeComponent();
            ActualizarCategorias();
            this.solicitante = solicitante;
        }

        private void ActualizarCategorias()
        {
            categorias_disponibles_dropdown.DataSource = null;
            categorias_disponibles_dropdown.DataSource = categoriasDisponibles;
            categorias_disponibles_dropdown.DisplayMember = nameof(CategoriaModelo.Nombre);
            categorias_seleccionadas_listbox.DataSource = null;
            categorias_seleccionadas_listbox.DataSource = categoriasSeleccionadas;
            categorias_seleccionadas_listbox.DisplayMember = nameof(CategoriaModelo.Nombre);
        }

        private void agregar_categoria_button_Click(object sender, EventArgs e)
        {
            var categoriaSeleccionada = (CategoriaModelo)categorias_disponibles_dropdown.SelectedItem;
            categoriasSeleccionadas.Add(categoriaSeleccionada);
            categoriasDisponibles.Remove(categoriaSeleccionada);
            ActualizarCategorias();
        }

        private void remover_categoria_button_Click(object sender, EventArgs e)
        {
            var categoriasARemover = categorias_seleccionadas_listbox.SelectedItems.Cast<CategoriaModelo>().ToList();

            foreach(var categoria in categoriasARemover)
            {
                categoriasSeleccionadas.Remove(categoria);
                categoriasDisponibles.Add(categoria);
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
                MessageBox.Show("El nombre del producto ya existe.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            foreach (var categoria in categoriasSeleccionadas)
            {
                categoriasDisponibles.Add(categoria);
            }

            categoriasSeleccionadas = new List<CategoriaModelo>();
            ActualizarCategorias();

            solicitante.ProductoListo(producto);
            MessageBox.Show("Tarea completada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void TareaCompleta(List<CategoriaModelo> categorias)
        {
            foreach (var categoria in categorias)
            {
                categoriasSeleccionadas.Add(categoria);
            }
            ActualizarCategorias();
        }

        private void nueva_categoria_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new CrearCategoriaForm(this);
            frm.Show();
        }

    }
}
