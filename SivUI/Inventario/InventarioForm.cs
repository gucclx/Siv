using SivBiblioteca;
using SivBiblioteca.Modelos;
using SivUI.Filtros;
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

namespace SivUI.Inventario
{
    public partial class InventarioForm : Form, ISolicitudFiltro
    {
        BindingSource resultados;
        ReporteFiltroModelo reporteFiltro;
        public InventarioForm()
        {
            InitializeComponent();

            resultados_dtgv.AutoGenerateColumns = false;

            // Inicializar columnas

            var nombreProducto = new DataGridViewTextBoxColumn();
            nombreProducto.HeaderText = "Producto";
            nombreProducto.DataPropertyName = nameof(ReporteInventarioModelo.NombreProducto);

            var descripcionProducto = new DataGridViewTextBoxColumn();
            descripcionProducto.HeaderText = "Descripción";
            descripcionProducto.DataPropertyName = nameof(ReporteInventarioModelo.DescripcionProducto);

            var unidades = new DataGridViewTextBoxColumn();
            unidades.HeaderText = "Unidades disponibles";
            unidades.DataPropertyName = nameof(ReporteInventarioModelo.UnidadesProducto);

            var inversionUnidades = new DataGridViewTextBoxColumn();
            inversionUnidades.HeaderText = "Inversión Unidades";
            inversionUnidades.DataPropertyName = nameof(ReporteInventarioModelo.InversionUnidadesProducto);

            resultados_dtgv.Columns.Add(nombreProducto);
            resultados_dtgv.Columns.Add(descripcionProducto);
            resultados_dtgv.Columns.Add(unidades);
            resultados_dtgv.Columns.Add(inversionUnidades);
        }

        private async void cargar_reporte_button_Click(object sender, EventArgs e)
        {
            cargar_reporte_button.Enabled = false;
            LimpiarResultados();

            ConfigTareaLabel(mensaje: "Extrayendo información de la base de datos...", visible: true);

            try
            {
                var reportes = await Task.Run(() =>
                    ConfigGlobal.conexion.CargarReporteInventario(reporteFiltro)
                );

                resultados = new BindingSource();
                resultados.DataSource = reportes;
                resultados_dtgv.DataSource = resultados;
                CalcularResumen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            cargar_reporte_button.Enabled = true;
            ConfigTareaLabel(visible: false);
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

            unidades_tb.Text = "N/A";
            inversion_tb.Text = "N/A";
        }

        /// <summary>
        /// Calcula las unidades totales e inversion total de todos los productos cargados
        /// y actualiza los campos de textos.
        /// </summary>
        private void CalcularResumen()
        {
            int unidadesTotales = 0;
            decimal inversionTotal = 0;

            foreach (ReporteInventarioModelo reporte in resultados)
            {
                unidadesTotales += reporte.UnidadesProducto;
                inversionTotal += reporte.InversionUnidadesProducto;
            }

            unidades_tb.Text = unidadesTotales.ToString();
            inversion_tb.Text = inversionTotal.ToString();
        }

        /// <summary>
        ///     Cambia el texto de tarea_label y hace visible o invisible este label.
        ///     Util para indicar al usuario la tarea que se esta realizando.
        /// </summary>
        /// <param name="mensaje"> Mensaje a mostrar. </param>
        /// <param name="visible"> Si el label es visible o no. </param>
        private void ConfigTareaLabel(string mensaje = "", bool visible = true)
        {
            tarea_label.Visible = visible;
            tarea_label.Text = mensaje;
            tarea_label.AutoSize = false;
            tarea_label.TextAlign = ContentAlignment.MiddleCenter;
            tarea_label.Dock = DockStyle.Fill;
        }

        private void filtros_button_Click(object sender, EventArgs e)
        {
            var frm = new InventarioFiltroForm(this, reporteFiltro);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        public void FiltroCreado(ReporteFiltroModelo filtro)
        {
            this.reporteFiltro = filtro;
        }

        private void Exportando(bool trabajando)
        {
            tarea_label.Visible = trabajando;
            exportar_button.Enabled = !trabajando;
            cargar_reporte_button.Enabled = !trabajando;
            limpiar_button.Enabled = !trabajando;
            filtros_button.Enabled = !trabajando;
        }

        private async void exportar_button_Click(object sender, EventArgs e)
        {
            if (resultados == null || resultados.DataSource == null) return;

            using (var dialogGuardar = new SaveFileDialog())
            {
                dialogGuardar.Filter = "CSV |*.csv";
                dialogGuardar.OverwritePrompt = true;

                if (dialogGuardar.ShowDialog() != DialogResult.OK) return;

                FileInfo archivo = new FileInfo(dialogGuardar.FileName);

                Exportando(true);
                ConfigTareaLabel($"Exportando { resultados.List.Count.ToString("#,##0") } filas...");

                try
                {
                    await Ayudantes.GuardarCsvReporteAsync(reportes: resultados.List.Cast<ReporteInventarioModelo>().ToList(), archivo: archivo);
                    MessageBox.Show("Tarea completada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Exportando(false);
            ConfigTareaLabel(visible: false);
        }

        private void limpiar_button_Click(object sender, EventArgs e)
        {
            LimpiarResultados();
        }
    }
}
