﻿using SivBiblioteca;
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
    public partial class InventarioAgregarForm : Form, ISolicitudProducto
    {
        List<ProductoModelo> productosDisponibles = ConfigGlobal.conexion.CargarProductos();

        public InventarioAgregarForm()
        {
            InitializeComponent();
            ActualizarListaProductos();
            ActualizarUltimoLoteId();
        }

        /// <summary>
        /// Actualiza el textbox que expone el id del ultimo producto insertado en la base de datos
        /// </summary>
        private void ActualizarUltimoLoteId()
        {
            ultimo_lote_id_label.Text = ConfigGlobal.conexion.CargarUltimoLoteId().ToString();
        }

        private void LimpiarForm()
        {
            unidades_tb.Focus();
            unidades_tb.Text = "";
            inversion_total_tb.Text = "";
            inversion_unidad_tb.Text = "N/A";
            precio_venta_defecto_tb.Text = "";
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
        private void ActualizarListaProductos()
        {
            productos_dropdown.DataSource = null;
            productos_dropdown.DataSource = productosDisponibles;
            productos_dropdown.DisplayMember = nameof(CategoriaModelo.Nombre);
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

            LoteModelo lote = new LoteModelo();

            lote.UnidadesCompradas = int.Parse(unidades_tb.Text);
            lote.UnidadesDisponibles = lote.UnidadesCompradas;
            lote.InversionUnidad = decimal.Parse(inversion_unidad_tb.Text);
            lote.PrecioVentaUnidad = decimal.Parse(precio_venta_defecto_tb.Text);
            lote.Producto = (ProductoModelo)productos_dropdown.SelectedItem;
            
            try
            {
                ConfigGlobal.conexion.GuardarLote(lote);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LimpiarForm();
            ActualizarUltimoLoteId();
            MessageBox.Show($"ID del lote: {lote.Id}", "Lote agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void nuevo_producto_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new CrearProductoForm(this);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        public void ProductoListo(ProductoModelo producto)
        {
            productosDisponibles.Add(producto);
            ActualizarListaProductos();
            productos_dropdown.SelectedItem = producto;
            
        }
    }
}
