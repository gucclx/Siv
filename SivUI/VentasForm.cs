﻿using SivBiblioteca;
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
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;

namespace SivUI
{
    public partial class VentasForm : Form, ISolicitudFiltro
    {
        BindingSource resultados;
        ReporteFiltroModelo reporteFiltro;
        const int LimiteFilasReporte = 1000;

        public VentasForm()
        {
            InitializeComponent();

            resultados_dtgv.AutoGenerateColumns = false;

            // inicializar columnas

            var loteIdColumna = new DataGridViewTextBoxColumn();
            loteIdColumna.HeaderText = "ID Lote";
            loteIdColumna.DataPropertyName = nameof(ReporteVentaModelo.LoteId);

            var nombreProductoColumna = new DataGridViewTextBoxColumn();
            nombreProductoColumna.HeaderText = "Producto";
            nombreProductoColumna.DataPropertyName = nameof(ReporteVentaModelo.NombreProducto);

            var unidadesVendidasColumna = new DataGridViewTextBoxColumn();
            unidadesVendidasColumna.HeaderText = "Unidades Vendidas";
            unidadesVendidasColumna.DataPropertyName = nameof(ReporteVentaModelo.UnidadesVendidas);

            var inversionUnidadColumna = new DataGridViewTextBoxColumn();
            inversionUnidadColumna.HeaderText = "Inversión Unidad";
            inversionUnidadColumna.DataPropertyName = nameof(ReporteVentaModelo.InversionUnidad);

            var precioVentaUnidadColumna = new DataGridViewTextBoxColumn();
            precioVentaUnidadColumna.HeaderText = "Precio Venta Unidad";
            precioVentaUnidadColumna.DataPropertyName = nameof(ReporteVentaModelo.PrecioVentaUnidad);

            var inversionVentaColumna = new DataGridViewTextBoxColumn();
            inversionVentaColumna.HeaderText = "Inversión Venta";
            inversionVentaColumna.DataPropertyName = nameof(ReporteVentaModelo.InversionVenta);

            var ingresoVentaColumna = new DataGridViewTextBoxColumn();
            ingresoVentaColumna.HeaderText = "Ingreso Venta";
            ingresoVentaColumna.DataPropertyName = nameof(ReporteVentaModelo.IngresoVenta);

            var gananciaVentaColumna = new DataGridViewTextBoxColumn();
            gananciaVentaColumna.HeaderText = "Ganancia Venta";
            gananciaVentaColumna.DataPropertyName = nameof(ReporteVentaModelo.GananciaVenta);

            var fechaVentaColumna = new DataGridViewTextBoxColumn();
            fechaVentaColumna.HeaderText = "Fecha Venta";
            fechaVentaColumna.DataPropertyName = nameof(ReporteVentaModelo.FechaVenta);

            var nombreClienteColumna = new DataGridViewTextBoxColumn();
            nombreClienteColumna.HeaderText = "Cliente";
            nombreClienteColumna.DataPropertyName = nameof(ReporteVentaModelo.NombreCliente);

            resultados_dtgv.Columns.Add(loteIdColumna);
            resultados_dtgv.Columns.Add(nombreProductoColumna);
            resultados_dtgv.Columns.Add(unidadesVendidasColumna);
            resultados_dtgv.Columns.Add(inversionUnidadColumna);
            resultados_dtgv.Columns.Add(precioVentaUnidadColumna);
            resultados_dtgv.Columns.Add(inversionVentaColumna);
            resultados_dtgv.Columns.Add(ingresoVentaColumna);
            resultados_dtgv.Columns.Add(gananciaVentaColumna);
            resultados_dtgv.Columns.Add(fechaVentaColumna);
            resultados_dtgv.Columns.Add(nombreClienteColumna);
        }

        private async void cargar_reporte_button_Click(object sender, EventArgs e)
        {
            cargar_reporte_button.Enabled = false;
            LimpiarResultados();

            try
            {
                ConfigTareaLabel("Extrayendo información de la base de datos...");
                // cargar reportes
                var reportes = await Task.Run(() =>
                    ConfigGlobal.conexion.CargarReporteVentas(reporteFiltro, limiteFilas: LimiteFilasReporte)
                );

                ConfigTareaLabel(visible: false);

                resultados = new BindingSource();
                resultados.DataSource = reportes;
                resultados_dtgv.DataSource = resultados;                
                CalcularResumenReporte();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                return;
            }
            cargar_reporte_button.Enabled = true;
        }

        private void LimpiarResultados()
        {
            if (resultados != null)
            {
                resultados.DataSource = null;
                resultados = null;
            }

            resultados_dtgv.DataSource = null;
            resultados_dtgv.Rows.Clear();
            GC.Collect();
        }

        private void filtros_button_Click(object sender, EventArgs e)
        {
            var frm = new CrearFiltroForm(this, reporteFiltro);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// Calcula los campos inversion total, ingreso total y ganancia total.
        /// </summary>
        private void CalcularResumenReporte()
        {
            decimal totalGanancia = 0;
            decimal totalIngreso = 0;
            decimal totalInversion = 0;

            foreach(ReporteVentaModelo reporte in resultados)
            {
                totalGanancia += reporte.GananciaVenta;
                totalIngreso += reporte.IngresoVenta;
                totalInversion += reporte.InversionVenta;
            }

            total_ganancia_tb.Text = totalGanancia.ToString();
            total_ingreso_tb.Text = totalIngreso.ToString();
            total_inversion_tb.Text = totalInversion.ToString();
        }

        public void FiltroCreado(ReporteFiltroModelo filtro)
        {
            reporteFiltro = filtro;
        }

        private void limpiar_button_Click(object sender, EventArgs e)
        {
            LimpiarResultados();
        }

        private void Exportando(bool trabajando)
        {
            tarea_label.Visible = trabajando;
            exportar_button.Enabled = !trabajando;
            cargar_reporte_button.Enabled = !trabajando;
            limpiar_button.Enabled = !trabajando;
            filtros_button.Enabled = !trabajando;
        }

        private void ConfigTareaLabel(string s = "", bool visible = true)
        {
            tarea_label.Visible = visible;
            tarea_label.Text = s;
            tarea_label.AutoSize = false;
            tarea_label.TextAlign = ContentAlignment.MiddleCenter;
            tarea_label.Dock = DockStyle.Fill;
        }

        private async void exportar_button_Click(object sender, EventArgs e)
        {
            if (resultados == null || resultados.DataSource == null) return;          

            using (var dialogGuardar = new SaveFileDialog())
            {
                dialogGuardar.Filter = "CSV |*.csv";
                dialogGuardar.OverwritePrompt = true;
                if (dialogGuardar.ShowDialog() == DialogResult.OK)
                {
                    FileInfo archivo = new FileInfo(dialogGuardar.FileName);
                    try
                    {
                        Exportando(true);
                        ConfigTareaLabel($"Exportando { resultados.List.Count.ToString("#,##0") } filas...");
                        await Ayudantes.GuardarCsvReporteAsync(reportes: resultados.List.Cast<ReporteVentaModelo>().ToList(), archivo: archivo);
                        MessageBox.Show("Tarea completada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                    
                }
            }
            Exportando(false);
            ConfigTareaLabel(visible: false);
        }
    }
}
