﻿using SivBiblioteca.Modelos;
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
    public partial class HistorialLotesFiltroForm : Form, ISolicitudCategoria, ISolicitudProducto
    {
        CategoriaModelo categoria;
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
                }

                filtrar_por_fechas_groupbox.Enabled = filtro.FiltroPorFechas;
                habilitar_fechas_checkbox.Checked = filtro.FiltroPorFechas;

                if (filtro.FiltroPorProducto && filtro.Producto != null)
                {
                    producto = filtro.Producto;
                    nombre_producto_tb.Text = filtro.Producto.Nombre;
                }

                filtrar_por_producto_groupbox.Enabled = filtro.FiltroPorProducto;
                filtrar_por_producto_checkbox.Checked = filtro.FiltroPorProducto;

                if (filtro.FiltroPorCategoria && filtro.Categoria != null)
                {
                    categoria = filtro.Categoria;
                    categoria_nombre_tb.Text = filtro.Categoria.Nombre;
                }
                filtrar_por_categoria_checkbox.Checked = filtro.FiltroPorCategoria;
                filtrar_por_categoria_groupbox.Enabled = filtro.FiltroPorCategoria;
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

            filtro.Categoria = categoria;
            filtro.FiltroPorCategoria = filtrar_por_categoria_checkbox.Checked;

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

        private void filtrar_por_categoria_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            filtrar_por_categoria_groupbox.Enabled = filtrar_por_categoria_checkbox.Checked;
        }

        public void CategoriaLista(CategoriaModelo categoria)
        {
            if (categoria == null) return;
            this.categoria = categoria;
            categoria_nombre_tb.Text = categoria.Nombre;
        }

        private void buscar_categoria_label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new BuscarCategoriaForm(this);
            frm.ShowDialog();
        }
    }
}
