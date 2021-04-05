using SivBiblioteca;
using SivBiblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SivUI
{
    public partial class InventarioAgregarForm : Form, ISolicitudCategoria
    {
        List<CategoriaModelo> categoriasDisponibles = ConfigGlobal.conexion.CargarCategorias();
        List<CategoriaModelo> categoriasSeleccionadas = new List<CategoriaModelo>();
        public InventarioAgregarForm()
        {
            InitializeComponent();
            ActualizarListaCategorias();
            ActualizarUltimoProductoId();
        }

        /// <summary>
        /// Actualiza el textbox que expone el id del ultimo producto insertado en la base de datos
        /// </summary>
        private void ActualizarUltimoProductoId()
        {
            ultimo_producto_id_tb.Text = ConfigGlobal.conexion.CargarUltimoProductoId().ToString();
        }

        private void LimpiarForm()
        {
            unidades_tb.Focus();
            unidades_tb.Text = "";
            inversion_total_tb.Text = "";
            inversion_unidad_tb.Text = "N/A";
            precio_venta_defecto_tb.Text = "";
            descripcion_unidad_tb.Text = "";

            foreach (var categoria in categoriasSeleccionadas)
            {
                categoriasDisponibles.Add(categoria);
            }

            categoriasSeleccionadas = new List<CategoriaModelo>();
            ActualizarListaCategorias();
        }
        private bool ValidarForm()
        {
            bool esFormValido = true;

            if (Ayudantes.EsEnteroPositivo(unidades_tb.Text) == false)
            {
                esFormValido = false;
                MessageBox.Show("Cantidad de unidades inválida", "Cantidad inválida", MessageBoxButtons.OK,  MessageBoxIcon.Information);
            }

            if (Ayudantes.EsDecimalNoNegativo(inversion_total_tb.Text) == false)
            {
                esFormValido = false;
                MessageBox.Show("Inversión total inválida", "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (Ayudantes.EsDecimalNoNegativo(precio_venta_defecto_tb.Text) == false)
            {
                esFormValido = false;
                MessageBox.Show("Precio de venta inválido", "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return esFormValido;
        }
        private void ActualizarListaCategorias()
        {
            categorias_dropdown.DataSource = null;
            categorias_dropdown.DataSource = categoriasDisponibles;
            categorias_dropdown.DisplayMember = nameof(CategoriaModelo.Nombre);

            categorias_listbox.DataSource = null;
            categorias_listbox.DataSource = categoriasSeleccionadas;
            categorias_listbox.DisplayMember = nameof(CategoriaModelo.Nombre);

        }

        private void agregar_categoria_button_Click(object sender, EventArgs e)
        {
            var categoria = (CategoriaModelo)categorias_dropdown.SelectedItem;
            if (categoria == null) { return; }

            categoriasSeleccionadas.Add(categoria);
            categoriasDisponibles.Remove(categoria);
            ActualizarListaCategorias();
                     
        }

        private void remover_categoria_button_Click(object sender, EventArgs e)
        {
            var categorias = categorias_listbox.SelectedItems.Cast<CategoriaModelo>().ToList();
            if (categorias.Count == 0) { return; }

            foreach (var categoria in categorias)
            {
                categoriasSeleccionadas.Remove(categoria);
                categoriasDisponibles.Add(categoria);
            }
            ActualizarListaCategorias();
        }

        private void inversion_total_tb_TextChanged(object sender, EventArgs e)
        {
            CalcularInversionPorUnidad();
        }

        private void CalcularInversionPorUnidad()
        {
            inversion_unidad_tb.Text = "N/A";

            if (Ayudantes.EsEnteroPositivo(unidades_tb.Text) == false) return;
            if (Ayudantes.EsDecimalNoNegativo(inversion_total_tb.Text) == false) return;

            int unidades = int.Parse(unidades_tb.Text.Trim());
            if (unidades == 0) return;

            decimal inversion = decimal.Parse(inversion_total_tb.Text.Trim());
            inversion_unidad_tb.Text = (inversion / unidades).ToString();
        }

        private void unidades_tb_TextChanged(object sender, EventArgs e)
        {
            CalcularInversionPorUnidad();
        }

        private void agregar_al_inventario_button_Click(object sender, EventArgs e)
        {
            if (ValidarForm() == false) return;

            ProductoModelo producto = new ProductoModelo();

            producto.Unidades = int.Parse(unidades_tb.Text);
            producto.PrecioInversion = decimal.Parse(inversion_unidad_tb.Text);
            producto.PrecioVenta = decimal.Parse(precio_venta_defecto_tb.Text);
            producto.Descripcion = descripcion_unidad_tb.Text.Trim();
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

            LimpiarForm();
            ActualizarUltimoProductoId();
            MessageBox.Show($"ID del producto: {producto.Id}", "Producto agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void nueva_categoria_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CrearCategoriaForm frm = new CrearCategoriaForm(this);
            frm.Show();
        }

        public void CategoriaCreada(List<CategoriaModelo> categorias)
        {
            foreach (var categoria in categorias)
            {
                categoriasSeleccionadas.Add(categoria);
            }
            ActualizarListaCategorias();
        }
    }
}
