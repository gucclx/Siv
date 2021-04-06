using SivBiblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SivUI
{
    public partial class GestionarVentasForm : Form
    {
        BindingSource resultados = new BindingSource();
        public GestionarVentasForm()
        {
            InitializeComponent();
            resultados_dtgv.DataSource = resultados;
        }

        private void habilitar_fechas_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            fechas_groupbox.Enabled = !fechas_groupbox.Enabled;
        }

        private void cargar_reporte_button_Click(object sender, EventArgs e)
        {          
            try
            {
                resultados.DataSource = ConfigGlobal.conexion.ReporteVentas
                (
                    fecha_inicial_dtp.Value.Date, 
                    fecha_final_dtp.Value, 
                    habilitar_fechas_checkbox.Checked

                ).ToDataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }       
    }
}
