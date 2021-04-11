using SivBiblioteca;
using SivBiblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SivUI
{
    public partial class GestionarInventarioForm : Form, ISolicitudFiltro
    {
        BindingSource resultados;
        ReporteFiltroModelo reporteFiltro;
        const int LimiteFilasReporte = 1000;
        public GestionarInventarioForm()
        {
            InitializeComponent();
            resultados_dtgv.AutoGenerateColumns = false;

            var nombreProductoColumna = new DataGridViewTextBoxColumn();
            nombreProductoColumna.HeaderText = "Producto";
            nombreProductoColumna.DataPropertyName = nameof(ReporteInventarioModelo.NombreProducto);

            var descripcionProductoColumna = new DataGridViewTextBoxColumn();
            descripcionProductoColumna.HeaderText = "Descripción";
            descripcionProductoColumna.DataPropertyName = nameof(ReporteInventarioModelo.DescripcionProducto);

            var precioVentaUnidadColumna = new DataGridViewTextBoxColumn();
            precioVentaUnidadColumna.HeaderText = "Precio Venta Unidad";
            precioVentaUnidadColumna.DataPropertyName = nameof(ReporteInventarioModelo.PrecioVentaUnidad);

            var loteIdColumna = new DataGridViewTextBoxColumn();
            loteIdColumna.HeaderText = "ID lote";
            loteIdColumna.DataPropertyName = nameof(ReporteInventarioModelo.LoteId);

            var unidadesCompradasColumna = new DataGridViewTextBoxColumn();
            unidadesCompradasColumna.HeaderText = "Unidades compradas";
            unidadesCompradasColumna.DataPropertyName = nameof(ReporteInventarioModelo.UnidadesCompradas);

            var unidadesDisponiblesColumna = new DataGridViewTextBoxColumn();
            unidadesDisponiblesColumna.HeaderText = "Unidades disponibles";
            unidadesDisponiblesColumna.DataPropertyName = nameof(ReporteInventarioModelo.UnidadesDisponibles);

            var inversionUnidadColumna = new DataGridViewTextBoxColumn();
            inversionUnidadColumna.HeaderText = "Inversión Unidad";
            inversionUnidadColumna.DataPropertyName = nameof(ReporteInventarioModelo.InversionUnidad);

            var inversionTotalColumna = new DataGridViewTextBoxColumn();
            inversionTotalColumna.HeaderText = "Inversión total";
            inversionTotalColumna.DataPropertyName = nameof(ReporteInventarioModelo.InversionTotal);

            var fechaAgregadocolumna = new DataGridViewTextBoxColumn();
            fechaAgregadocolumna.HeaderText = "Fecha Agregado";
            fechaAgregadocolumna.DataPropertyName = nameof(ReporteInventarioModelo.FechaAgregado);

            resultados_dtgv.Columns.Add(nombreProductoColumna);
            resultados_dtgv.Columns.Add(descripcionProductoColumna);
            resultados_dtgv.Columns.Add(precioVentaUnidadColumna);
            resultados_dtgv.Columns.Add(loteIdColumna);
            resultados_dtgv.Columns.Add(unidadesCompradasColumna);
            resultados_dtgv.Columns.Add(unidadesDisponiblesColumna);
            resultados_dtgv.Columns.Add(inversionUnidadColumna);
            resultados_dtgv.Columns.Add(inversionTotalColumna);
            resultados_dtgv.Columns.Add(fechaAgregadocolumna);

        }

        private void cargar_reporte_button_Click(object sender, EventArgs e)
        {
            cargar_reporte_button.Enabled = false;
            LimpiarResultados();

            try
            {
                // cargar reportes
                var reportes = ConfigGlobal.conexion.CargarReporteInventario(reporteFiltro, limiteFilas: LimiteFilasReporte);

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

            total_unidades_tb.Text = "N/A";
            total_inversion_tb.Text = "N/A";
            valor_unidades_tb.Text = "N/A";
        }

        private void CalcularResumenReporte()
        {
            int unidadesTotal = 0;
            decimal inversionTotal = 0;
            decimal valorUnidades = 0;

            foreach (ReporteInventarioModelo reporte in resultados)
            {
                unidadesTotal += reporte.UnidadesDisponibles;
                inversionTotal += reporte.InversionTotal;
                valorUnidades += reporte.UnidadesDisponibles * reporte.InversionUnidad;
            }

            total_unidades_tb.Text = unidadesTotal.ToString();
            total_inversion_tb.Text = inversionTotal.ToString();
            valor_unidades_tb.Text = valorUnidades.ToString();
        }

        private void limpiar_button_Click(object sender, EventArgs e)
        {
            LimpiarResultados();
        }

        private void filtros_button_Click(object sender, EventArgs e)
        {
            var frm = new CrearFiltroForm(this, reporteFiltro);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        public void FiltroCreado(ReporteFiltroModelo filtro)
        {
            reporteFiltro = filtro;
        }

        private void Exportando(bool trabajando)
        {
            exportando_label.Visible = trabajando;
            exportar_button.Enabled = !trabajando;
            cargar_reporte_button.Enabled = !trabajando;
            limpiar_button.Enabled = !trabajando;
            filtros_button.Enabled = !trabajando;
        }

        private async void exportar_button_Click(object sender, EventArgs e)
        {
            if (resultados == null || resultados.DataSource == null) return;

            Exportando(true);

            using (var dialogGuardar = new SaveFileDialog())
            {
                dialogGuardar.Filter = "CSV |*.csv";
                dialogGuardar.OverwritePrompt = true;
                if (dialogGuardar.ShowDialog() == DialogResult.OK)
                {
                    FileInfo archivo = new FileInfo(dialogGuardar.FileName);
                    try
                    {
                        await Ayudantes.GuardarCsvReporteInventarioAsync(reportes: resultados.List.Cast<ReporteInventarioModelo>().ToList(), archivo: archivo);
                        MessageBox.Show("Tarea completada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            Exportando(false);
        }
    }
}
