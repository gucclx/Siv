using SivBiblioteca.Interfaces;
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
using System.IO;
using SivUI.Filtros;
using SivBiblioteca.Utilidades;

namespace SivUI.ExportarUI
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

        private async void exportar_lotes_button_Click(object sender, EventArgs e)
        {
            var frm = new HistorialLotesFiltroForm(solicitante: this);
            this.Hide();
            frm.ShowDialog();
            this.Show();

            var destino = AbrirDialogoGuardar();
            if (destino == null) return;

            await ExportarReporte<ReporteLoteModelo>(destino, reporteFiltro);
            reporteFiltro = null;
        }

        private async Task ExportarReporte<T>(FileInfo destino, ReporteFiltroModelo filtro) where T: IReporte
        {
            Exportando(true);
            CambiarTareaLabel(mensaje: "Exportando...", visible: true);

            try
            {
                await Exportar.ExportarReporte<T>(destino, reporteFiltro: filtro);
                MessageBox.Show("Tarea completada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Exportando(false);
            CambiarTareaLabel(visible: false);
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

            await ExportarReporte<ReporteVentaModelo>(destino, reporteFiltro);
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
                destino = ExportarDialogo.Mostrar();
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return destino;
        }

        private async void exportar_inventario_button_Click(object sender, EventArgs e)
        {
            var reporteFiltro = new ReporteFiltroModelo
            {
                IncluirProductosSinUnidades = false
            };

            var frm = new InventarioFiltroForm(this, reporteFiltro);
            this.Hide();
            frm.ShowDialog();
            this.Show();

            var destino = AbrirDialogoGuardar();
            if (destino == null) return;

            await ExportarReporte<ReporteInventarioModelo>(destino, reporteFiltro);
            reporteFiltro = null;
        }
    }
}
