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
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;
using SivBiblioteca.AccesoDatos;

namespace SivUI
{
    // TODO - paginar resultados de la base de datos y escribir el archivo por lotes.
    public partial class ExportarForm : Form, ISolicitudFiltro
    {
        ReporteFiltroModelo reporteFiltro;
        public ExportarForm()
        {
            InitializeComponent();
        }

        public void FiltroCreado(ReporteFiltroModelo filtro)
        {
            reporteFiltro = filtro;
        }

        private void filtros_button_Click(object sender, EventArgs e)
        {
            var frm = new CrearFiltroForm(this, reporteFiltro);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private async void exportar_inventario_button_Click(object sender, EventArgs e)
        {
            var destino = GuardarDialogo();
            if (destino == null) return;

            Exportando(true);
            CambiarTareaLabel("Extrayendo inventario de la base de datos...");

            List<ReporteInventarioModelo> reportes;

            try
            {
                reportes = await Task.Run(() => ConfigGlobal.conexion.CargarReporteInventario(reporteFiltro));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Exportando(false);
                return;
            }

            CambiarTareaLabel($"Exportando { reportes.Count.ToString("#,##0") } filas...");

            try
            {
                await Ayudantes.GuardarCsvReporteInventarioAsync(reportes, destino);
                MessageBox.Show("Tarea completada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Exportando(false);
        }

        /// <summary>
        /// Cambia el texto del label 'tarea' el cual indica el trabajo llevandose a cabo actualmente.
        /// </summary>
        /// <param name="s"></param>
        private void CambiarTareaLabel(string s)
        {
            tarea_label.Text = s;
            tarea_label.AutoSize = false;
            tarea_label.TextAlign = ContentAlignment.MiddleCenter;
            tarea_label.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Abre un dialogo donde el usuario escoge el destino a guardar la exportacion.
        /// </summary>
        /// <returns> La informacion del destino. Si el usuario no escoge uno se retorna null. </returns>
        private FileInfo GuardarDialogo()
        {
            using (var dialogGuardar = new SaveFileDialog())
            {
                dialogGuardar.Filter = "CSV |*.csv";
                dialogGuardar.OverwritePrompt = true;

                var resultadoDialogo = dialogGuardar.ShowDialog();

                if (resultadoDialogo == DialogResult.OK)
                {
                    return new FileInfo(dialogGuardar.FileName);
                }
                else { return null; }               
            }           
        }

        private async void exportar_ventas_button_Click(object sender, EventArgs e)
        {
            var destino = GuardarDialogo();
            if (destino == null) return;

            Exportando(true);
            List<ReporteVentaModelo> reportes;
            try
            {
                reportes = ConfigGlobal.conexion.CargarReporteVentas(reporteFiltro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Exportando(false);
                return;
            }
            
            try
            {
                await Ayudantes.GuardarCsvReporteVentasAsync(reportes, destino);
                MessageBox.Show("Tarea completada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Exportando(false);
        }

        /// <summary>
        /// Deshabilita o habilita los botones de la interfaz dependiendo si se esta exportando o no.
        /// Hace visible el header label si se esta trabajando. Invisible si no.
        /// </summary>
        /// <param name="trabajando"> Indica si se esta exportando o no. </param>
        private void Exportando(bool trabajando)
        {
            tarea_label.Visible = trabajando;
            filtros_button.Enabled = !trabajando;
            exportar_inventario_button.Enabled = !trabajando;
            exportar_ventas_button.Enabled = !trabajando;
        }
    }
}
