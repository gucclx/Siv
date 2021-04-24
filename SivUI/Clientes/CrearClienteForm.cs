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
    public partial class CrearClienteForm : Form
    {
        ISolicitudCliente solicitante;
        public CrearClienteForm(ISolicitudCliente solicitante = null)
        {
            InitializeComponent();
            this.solicitante = solicitante;
            nombre_cliente_tb.Focus();
        }

        private bool ValidarForm()
        {
            bool resultado = true;
            if (string.IsNullOrEmpty(nombre_cliente_tb.Text.Trim()))
            {
                MessageBox.Show("Nombre inválido.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                resultado = false;
            }
            return resultado;
        }

        private void crear_cliente_button_Click(object sender, EventArgs e)
        {
            if (ValidarForm() == false) { return; }
            
            ClienteModelo cliente = new ClienteModelo();
            cliente.Nombre = nombre_cliente_tb.Text.Trim();
            cliente.Apellido = apellido_cliente_tb.Text.Trim();
            cliente.NumeroContacto = numero_contacto_cliente_tb.Text.Trim();

            try
            {
                ConfigGlobal.conexion.GuardarCliente(cliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Tarea completada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            nombre_cliente_tb.Clear();
            nombre_cliente_tb.Focus();
            apellido_cliente_tb.Clear();
            numero_contacto_cliente_tb.Clear();

            if (solicitante != null)
            {
                solicitante.ClienteListo(cliente);
            }
            this.Close();
        }
    }
}
