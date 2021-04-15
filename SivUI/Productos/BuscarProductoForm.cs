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
    public partial class BuscarProductoForm : Form
    {
        List<ProductoModelo> resultados;
        ISolicitudProducto solicitante;
        public BuscarProductoForm(ISolicitudProducto solicitante = null)
        {
            InitializeComponent();
            this.solicitante = solicitante;
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

        private void buscar_producto_button_Click(object sender, EventArgs e)
        {
            var nombre = nombre_producto_tb.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                return;
            }

            Trabajando(true);

            try
            {
                resultados = ConfigGlobal.conexion.BuscarProducto_PorNombre(nombre);
                ActualizarResultados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Trabajando(false);
        }

        private void seleccionar_button_Click(object sender, EventArgs e)
        {
            var producto = ((ProductoModelo)resultados_listbox.SelectedItem);
            solicitante.ProductoListo(producto);
            this.Close();
        }
    }
}
