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
    public partial class EditarClienteForm : Form, ISolicitudCliente
    {
        ClienteModelo cliente;
        public EditarClienteForm()
        {
            InitializeComponent();
        }

        public void ClienteListo(ClienteModelo cliente)
        {
            if (cliente == null) return;

            this.cliente = cliente;
            nombre_cliente_tb.Text = cliente.Nombre;
            numero_actual_tb.Text = cliente.NumeroContacto;
            nuevo_nombre_tb.Text = cliente.Nombre;
            nuevo_numero_tb.Text = cliente.NumeroContacto;
        }

        private void buscar_cliente_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new BuscarClienteForm(this);
            frm.ShowDialog();
        }

        private void editar_button_Click(object sender, EventArgs e)
        {
            if (cliente == null) return;

            var nuevoNombre = nuevo_nombre_tb.Text.Trim();
            var nuevoNumero = nuevo_numero_tb.Text.Trim();

            if (string.IsNullOrEmpty(nuevoNombre))
            {
                MessageBox.Show("El nuevo nombre no puede estar en blanco.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            cliente.Nombre = nuevoNombre;
            cliente.NumeroContacto = nuevoNumero;

            try
            {
                ConfigGlobal.conexion.EditarCliente(cliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Tarea completada.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarForm();
        }

        private void LimpiarForm()
        {
            nombre_cliente_tb.Clear();
            nuevo_nombre_tb.Clear();
            numero_actual_tb.Clear();
            nuevo_numero_tb.Clear();
            cliente = null;
        }
    }
}
