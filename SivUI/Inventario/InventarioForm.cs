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

namespace SivUI.Inventario
{
    public partial class InventarioForm : Form
    {
        BindingSource resultados;
        ReporteFiltroModelo reporteFiltro;
        public InventarioForm()
        {
            InitializeComponent();

            resultados_dtgv.AutoGenerateColumns = false;

            // Inicializar columnas

            var nombreProductoColumna = new DataGridViewTextBoxColumn();
            nombreProductoColumna.HeaderText = "Producto";
            nombreProductoColumna.DataPropertyName = nameof(ReporteInventarioModelo.NombreProducto);

            var descripcionProductoColumna = new DataGridViewTextBoxColumn();
            descripcionProductoColumna.HeaderText = "Descripción";
            descripcionProductoColumna.DataPropertyName = nameof(ReporteInventarioModelo.DescripcionProducto);

            var unidadesDisponiblesColumna = new DataGridViewTextBoxColumn();
            unidadesDisponiblesColumna.HeaderText = "Unidades disponibles";
            unidadesDisponiblesColumna.DataPropertyName = nameof(ReporteInventarioModelo.UnidadesDisponiblesProducto);

            // mucho texto
            var valorUnidadesDisponiblesProductoColumna = new DataGridViewTextBoxColumn();
            valorUnidadesDisponiblesProductoColumna.HeaderText = "Unidades disponibles";
            valorUnidadesDisponiblesProductoColumna.DataPropertyName = nameof(ReporteInventarioModelo.ValorUnidadesDisponiblesProducto);

            resultados_dtgv.Columns.Add(nombreProductoColumna);
            resultados_dtgv.Columns.Add(descripcionProductoColumna);
            resultados_dtgv.Columns.Add(unidadesDisponiblesColumna);
            resultados_dtgv.Columns.Add(valorUnidadesDisponiblesProductoColumna);
        }

        private async void cargar_reporte_button_Click(object sender, EventArgs e)
        {
            cargar_reporte_button.Enabled = false;
            //LimpiarResultados();

            try
            {
                ConfigTareaLabel("Extrayendo información de la base de datos...");

                // cargar reportes
                var reportes = await Task.Run(() =>
                    ConfigGlobal.conexion.CargarReporteInventario(reporteFiltro)
                );

                ConfigTareaLabel(visible: false);

                resultados = new BindingSource();
                resultados.DataSource = reportes;
                resultados_dtgv.DataSource = resultados;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            //total_unidades_tb.Text = "N/A";
            //total_inversion_tb.Text = "N/A";
            //valor_unidades_tb.Text = "N/A";
        }

        private void ConfigTareaLabel(string s = "", bool visible = true)
        {
            tarea_label.Visible = visible;
            tarea_label.Text = s;
            tarea_label.AutoSize = false;
            tarea_label.TextAlign = ContentAlignment.MiddleCenter;
            tarea_label.Dock = DockStyle.Fill;
        }
    }
}
