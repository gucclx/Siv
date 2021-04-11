﻿using SivBiblioteca;
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
    public partial class EditarProductoForm : Form, ISolicitudProducto, ISolicitudCategoria
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
            frm.Show();
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

            producto.Nombre = nuevoNombre;
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
            ActualizarCategorias();
        }
    }
}
