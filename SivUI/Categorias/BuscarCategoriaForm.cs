using SivBiblioteca;
using SivBiblioteca.Modelos;
using SivUI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SivUI.Categorias
{
    public partial class BuscarCategoriaForm : Form
    {
        List<CategoriaModelo> resultados;
        ISolicitudCategoria solicitante;
        public BuscarCategoriaForm(ISolicitudCategoria solicitante)
        {
            InitializeComponent();
            this.solicitante = solicitante;
        }

        private void buscar_button_Click(object sender, EventArgs e)
        {
            var nombre = nombre_categoria_tb.Text.Trim();
            if (string.IsNullOrEmpty(nombre)) return;

            try
            {
                resultados = ConfigGlobal.conexion.BuscarCategoria_PorNombre(nombre);
                ActualizarResultados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarResultados()
        {
            resultados_listbox.DataSource = null;
            resultados_listbox.DataSource = resultados;
            resultados_listbox.DisplayMember = nameof(CategoriaModelo.Nombre);
        }

        private void seleccionar_button_Click(object sender, EventArgs e)
        {
            var categoria = ((CategoriaModelo)resultados_listbox.SelectedItem);
            solicitante.CategoriaLista(categoria);
            this.Close();
        }
    }
}
