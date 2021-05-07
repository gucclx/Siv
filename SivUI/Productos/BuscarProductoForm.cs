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

namespace SivUI.Productos
{
    public partial class BuscarProductoForm : Form
    {
        List<ProductoModelo> resultados;
        ISolicitudProducto solicitante;
        public BuscarProductoForm(ISolicitudProducto solicitante)
        {
            InitializeComponent();
            this.solicitante = solicitante;
            nombre_producto_tb.Focus();
        }

        private void ActualizarResultados()
        {
            resultados_listbox.DataSource = null;
            resultados_listbox.DataSource = resultados;
            resultados_listbox.DisplayMember = nameof(ProductoModelo.Nombre);
        }

        private void Trabajando(bool trabajando)
        {
            seleccionar_button.Enabled = !trabajando;
            buscar_producto_button.Enabled = !trabajando;
        }

        private async void buscar_producto_button_Click(object sender, EventArgs e)
        {
            await BuscarProducto();
        }

        private async Task BuscarProducto()
        {
            var nombre = nombre_producto_tb.Text.Trim();

            if (string.IsNullOrEmpty(nombre)) return;

            Trabajando(true);
            ConfigTareaLabel(mensaje: "Buscando producto...", visible: true);

            try
            {
                resultados = await Task.Run(() => ConfigGlobal.conexion.BuscarModelo_PorNombre<ProductoModelo>(nombre));
                ActualizarResultados();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Trabajando(false);
            ConfigTareaLabel(visible: false);
        }

        private void seleccionar_button_Click(object sender, EventArgs e)
        {
            var producto = ((ProductoModelo)resultados_listbox.SelectedItem);
            solicitante.ProductoListo(producto);
            this.Close();
        }

        private void ConfigTareaLabel(string mensaje = "", bool visible = true)
        {
            tarea_label.Visible = visible;
            tarea_label.Text = mensaje;
            tarea_label.AutoSize = false;
            tarea_label.TextAlign = ContentAlignment.MiddleCenter;
            tarea_label.Dock = DockStyle.Fill;
        }

        private async void nombre_producto_tb_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await BuscarProducto();
            }
        }
    }
}
