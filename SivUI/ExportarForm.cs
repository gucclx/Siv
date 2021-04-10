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

namespace SivUI
{
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
            Exportando(true);

            List<ReporteInventarioModelo> reportes;
            try
            {
                reportes = ConfigGlobal.conexion.CargarReporteInventario(reporteFiltro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Exportando(false);
                return;
            }

            var destino = GuardarDialogo();
            if (destino == null)
            {
                Exportando(false);
                return;
            }

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

            var destino = GuardarDialogo();
            if (destino == null)
            {
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
            exportando_label.Visible = trabajando;
            filtros_button.Enabled = !trabajando;
            exportar_inventario_button.Enabled = !trabajando;
            exportar_ventas_button.Enabled = !trabajando;
        }
    }
}
