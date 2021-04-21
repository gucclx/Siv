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
using SivUI.Filtros;

namespace SivUI
{
    public partial class ExportarForm : Form, ISolicitudFiltro
    {
        ReporteFiltroModelo reporteFiltro;

        const int LimiteFilas = 100_000;
        public ExportarForm()
        {
            InitializeComponent();
        }

        public void FiltroCreado(ReporteFiltroModelo filtro)
        {
            reporteFiltro = filtro;
        }

        private async void exportar_lotes_button_Click(object sender, EventArgs e)
        {
            var frm = new HistorialLotesFiltroForm(this);
            this.Hide();
            frm.ShowDialog();
            this.Show();

            var destino = DialogoGuardar();
            if (destino == null) return;

            Exportando(true);
            CambiarTareaLabel("Exportando...");

            List<ReporteLoteModelo> reportes;
            int? comienzo = 0;

            try
            {
                // Exportar los resultados mediante paginacion
                do
                {
                    reportes = await Task.Run(() =>
                        ConfigGlobal.conexion.CargarReporteLotes(reporteFiltro, limiteFilas: LimiteFilas, comienzo: comienzo)
                    );
                    await Ayudantes.GuardarCsvReporteAsync(reportes, destino);
                    comienzo = reportes.LastOrDefault()?.LoteId;
                } while (reportes.Count > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Exportando(false);
                return;
            }

            MessageBox.Show("Tarea completada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Exportando(false);
            reporteFiltro = null;
        }

        /// <summary>
        ///     Cambia el texto del label 'tarea' el cual indica el trabajo llevandose a cabo actualmente.
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
        ///     Abre un dialogo donde el usuario escoge el destino a guardar la exportacion.
        /// </summary>
        /// <returns> La informacion del destino. Si el usuario no escoge uno se retorna null. </returns>
        private FileInfo DialogoGuardar()
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
                return null;              
            }           
        }

        private async void exportar_ventas_button_Click(object sender, EventArgs e)
        {
            var frm = new HistorialVentasFiltroForm(this);
            this.Hide();
            frm.ShowDialog();
            this.Show();

            var destino = DialogoGuardar();
            if (destino == null) return;

            Exportando(true);
            CambiarTareaLabel("Exportando...");

            List<ReporteVentaModelo> reportes;
            int? comienzo = 0;

            try
            {
                // Guardar los reportes utilizando paginacion.
                do
                {
                    reportes = await Task.Run(() =>
                        ConfigGlobal.conexion.CargarReporteVentas(reporteFiltro, limiteFilas: LimiteFilas, comienzo: comienzo)
                    );
                    await Ayudantes.GuardarCsvReporteAsync(reportes, destino);
                    comienzo = reportes.LastOrDefault()?.LoteId;
                } while (reportes.Count > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Exportando(false);
                return;
            }

            MessageBox.Show("Tarea completada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Exportando(false);
            reporteFiltro = null;
        }

        /// <summary>
        ///     Deshabilita o habilita los botones de la interfaz dependiendo si se esta exportando o no.
        ///     Hace visible el header label si se esta trabajando. Invisible si no.
        /// </summary>
        /// <param name="trabajando"> Indica si se esta exportando o no. </param>
        private void Exportando(bool trabajando)
        {
            tarea_label.Visible = trabajando;
            header_label.Visible = !trabajando;
            exportar_lotes_button.Enabled = !trabajando;
            exportar_ventas_button.Enabled = !trabajando;
            exportar_inventario_button.Enabled = !trabajando;
        }

        private async void exportar_inventario_button_Click(object sender, EventArgs e)
        {
            var frm = new InventarioFiltroForm(this);
            this.Hide();
            frm.ShowDialog();
            this.Show();

            var destino = DialogoGuardar();
            if (destino == null) return;

            Exportando(true);
            CambiarTareaLabel("Exportando...");

            List<ReporteInventarioModelo> inventario;
            int? comienzo = 0;

            try
            {
                do
                {
                    inventario = await Task.Run(() =>
                        ConfigGlobal.conexion.CargarReporteInventario(reporteFiltro, limiteFilas: LimiteFilas, comienzo: comienzo)
                    );
                    await Ayudantes.GuardarCsvReporteAsync(inventario, destino);
                    comienzo = inventario.LastOrDefault()?.IdProducto;
                } while (inventario.Count > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Exportando(false);
                return;
            }

            MessageBox.Show("Tarea completada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Exportando(false);
            reporteFiltro = null;
        }
    }
}
