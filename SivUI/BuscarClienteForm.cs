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

namespace SivUI
{
    public partial class BuscarClienteForm : Form
    {
        List<ClienteModelo> resultados;
        ISolicitudCliente solicitante;
        public BuscarClienteForm(ISolicitudCliente solicitante)
        {
            InitializeComponent();
            this.solicitante = solicitante;
        }

        private void ActualizarResultados()
        {
            resultados_listbox.DataSource = null;
            resultados_listbox.DataSource = resultados;
            resultados_listbox.DisplayMember = nameof(ClienteModelo.NombreCompleto);
        }

        private void buscar_cliente_button_Click(object sender, EventArgs e)
        {
            var nombre = nombre_completo_tb.Text.Trim();
            resultados_listbox.Visible = false;
            aceptar_button.Visible = false;
            if (string.IsNullOrEmpty(nombre))
            {
                return;
            }
            
            try
            {
                resultados = ConfigGlobal.conexion.BuscarCliente_PorNombre(nombre);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            resultados_listbox.Visible = true;
            aceptar_button.Visible = true;
            ActualizarResultados();
        }

        private void aceptar_button_Click(object sender, EventArgs e)
        {
            var clienteSeleccionado = (ClienteModelo)resultados_listbox.SelectedItem;
            solicitante.ClienteListo(clienteSeleccionado);
            this.Close();
        }
    }
}
