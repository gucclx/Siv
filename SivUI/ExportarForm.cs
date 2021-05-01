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

        // Firma de la funcion que cargara los reportes.
        delegate List<T> ReportesFuncion<T>(ReporteFiltroModelo filtro, int? limiteFilas, int? comienzo);

        // todo - cambiar
        const int LimiteFilas = 1;
        public ExportarForm()
        {
            InitializeComponent();
        }

        public void FiltroCreado(ReporteFiltroModelo filtro)
        {
            reporteFiltro = filtro;
        }

        // todo - mover logica a biblioteca
        private async Task ExportarReportes<T>(FileInfo destino, ReportesFuncion<T> f) where T : IReporte
        {
            List<T> reportes;
            int? comienzo = null;

            // Exportar los resultados mediante paginacion.
            do
            {
                reportes = await Task.Run(() => f(filtro: reporteFiltro, limiteFilas: LimiteFilas, comienzo: comienzo));
                await Ayudantes.GuardarCsvReporteAsync(reportes, destino);
                comienzo = reportes.LastOrDefault()?.ReporteId;
            } while (reportes.Count > 0);
        }

        private async void exportar_lotes_button_Click(object sender, EventArgs e)
        {
            var frm = new HistorialLotesFiltroForm(solicitante: this);
            this.Hide();
            frm.ShowDialog();
            this.Show();

            var destino = AbrirDialogoGuardar();
            if (destino == null) return;

            Exportando(true);
            CambiarTareaLabel(mensaje: "Exportando...", visible: true);

            ReportesFuncion<ReporteLoteModelo> f = 
                (filtro, limiteFilas, comienzo) => ConfigGlobal.conexion.CargarReporteLotes(filtro: filtro, limiteFilas: limiteFilas, comienzo: comienzo);

            try
            {
                await ExportarReportes(destino, f);
                MessageBox.Show("Tarea completada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Exportando(false);
            CambiarTareaLabel(visible: false);
            reporteFiltro = null;
        }

        /// <summary>
        ///     Cambia el texto del label 'tarea' el cual indica el trabajo llevandose a cabo actualmente.
        /// </summary>
        /// <param name="s"></param>
        private void CambiarTareaLabel(string mensaje = "", bool visible = false)
        {
            tarea_label.Visible = visible;
            tarea_label.Text = mensaje;
            tarea_label.AutoSize = false;
            tarea_label.TextAlign = ContentAlignment.MiddleCenter;
            tarea_label.Dock = DockStyle.Fill;
        }

        private async void exportar_ventas_button_Click(object sender, EventArgs e)
        {
            var frm = new HistorialVentasFiltroForm(this);
            this.Hide();
            frm.ShowDialog();
            this.Show();

            var destino = AbrirDialogoGuardar();
            if (destino == null) return;

            Exportando(true);
            CambiarTareaLabel(mensaje: "Exportando...", visible: true);

            ReportesFuncion<ReporteVentaModelo> f =
                (filtro, limiteFilas, comienzo) => ConfigGlobal.conexion.CargarReporteVentas(filtro: filtro, limiteFilas: limiteFilas, comienzo: comienzo);

            try
            {
                await ExportarReportes(destino, f);
                MessageBox.Show("Tarea completada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Exportando(false);
            CambiarTareaLabel(visible: false);
            reporteFiltro = null;
        }

        /// <summary>
        ///     Deshabilita o habilita los botones de la interfaz dependiendo si se esta exportando o no.
        ///     Hace visible el header label si se esta trabajando. Invisible si no.
        /// </summary>
        /// <param name="trabajando"> Indica si se esta exportando o no. </param>
        private void Exportando(bool trabajando)
        {
            header_label.Visible = !trabajando;
            exportar_lotes_button.Enabled = !trabajando;
            exportar_ventas_button.Enabled = !trabajando;
            exportar_inventario_button.Enabled = !trabajando;
        }
        
        /// <summary>
        /// Abre el dialogo en el que el usuario escoge el destino del archivo.
        /// </summary>
        /// <returns> 
        /// La informacion de destino. Si el usuario no escoge uno, se retorna null.
        /// Si ocurre un error, se retornar null.
        /// </returns>
        private FileInfo AbrirDialogoGuardar()
        {
            FileInfo destino = null;
            try
            {
                destino = Exportar.DialogoGuardar();
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return destino;
        }

        private async void exportar_inventario_button_Click(object sender, EventArgs e)
        {
            reporteFiltro = new ReporteFiltroModelo();
            reporteFiltro.IncluirProductosSinUnidades = false;

            var frm = new InventarioFiltroForm(this, reporteFiltro);
            this.Hide();
            frm.ShowDialog();
            this.Show();

            var destino = AbrirDialogoGuardar();
            if (destino == null) return;

            Exportando(true);
            CambiarTareaLabel(mensaje: "Exportando...", visible: true);

            try
            {
                ReportesFuncion<ReporteInventarioModelo> f = 
                    (filtro, limiteFilas, comienzo) => ConfigGlobal.conexion.CargarReporteInventario(filtro: filtro, limiteFilas: limiteFilas, comienzo: comienzo);

                await ExportarReportes(destino, f);
                MessageBox.Show("Tarea completada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Exportando(false);
            CambiarTareaLabel(visible: false);
            reporteFiltro = null;
        }
    }
}
