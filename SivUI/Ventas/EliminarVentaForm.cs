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
using SivBiblioteca.Utilidades;


namespace SivUI.Ventas
{
    public partial class EliminarVentaForm : Form
    {
        VentaModelo venta;
        public EliminarVentaForm()
        {
            InitializeComponent();
            venta_id_tb.Focus();
        }

        private void cargar_venta_button_Click(object sender, EventArgs e)
        {
            if (venta != null) return;

            if (Ayudantes.EsEnteroPositivo(venta_id_tb.Text) == false)
            {
                MessageBox.Show("ID del lote inválido", "ID inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var ventaId = Convert.ToInt32(venta_id_tb.Text);
                venta = ConfigGlobal.conexion.CargarVenta_PorId(ventaId);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (venta == null)
            {
                MessageBox.Show("La venta no existe.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            lote_id_tb.Text = venta.Lote.Id.ToString();
            producto_tb.Text = venta.Lote.Producto.Nombre;
            unidades_vendidas_tb.Text = venta.Unidades.ToString();
            total_tb.Text = venta.Total.ToString();
            fecha_venta_tb.Text = venta.Fecha;
            cliente_tb.Text = venta.Cliente?.NombreCompleto;
        }

        private void eliminar_venta_button_Click(object sender, EventArgs e)
        {
            if (venta == null) return;

            var mensaje = "La venta se eliminará de la base de datos. Las unidades vendidas se agregarán al lote al cual pertenecían. ¿Desea continuar?";

            var continuar = MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (continuar == DialogResult.No) return;

            try
            {
                ConfigGlobal.conexion.EliminarVenta(venta.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Tarea completada.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            lote_id_tb.Text = "N/A";
            producto_tb.Text = "N/A";
            unidades_vendidas_tb.Text = "N/A";           
            total_tb.Text = "N/A";
            fecha_venta_tb.Text = "N/A";
            cliente_tb.Text = "N/A";
            venta_id_tb.Clear();
            venta_id_tb.Focus();
            venta = null;
        }
    }
}
