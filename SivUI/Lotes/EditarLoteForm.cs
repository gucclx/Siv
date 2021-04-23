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
    public partial class EditarLoteForm : Form
    {
        LoteModelo lote;
        public EditarLoteForm()
        {
            InitializeComponent();
            lote_id_tb.Focus();
        }

        private void cargar_lote_button_Click(object sender, EventArgs e)
        {
            if (Ayudantes.EsEnteroPositivo(lote_id_tb.Text) == false)
            {
                MessageBox.Show("ID del lote inválido", "ID inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var loteId = Convert.ToInt32(lote_id_tb.Text);
                lote = ConfigGlobal.conexion.CargarLote_PorId(loteId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (lote == null)
            {
                MessageBox.Show("El lote no existe.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            producto_tb.Text = lote.Producto.Nombre;
            unidades_adquiridas_tb.Text = lote.UnidadesCompradas.ToString();
            unidades_disponibles_tb.Text = lote.UnidadesDisponibles.ToString();
            inversion_unidad_tb.Text = lote.InversionUnidad.ToString();
            precio_venta_unidad_tb.Text = lote.PrecioVentaUnidad.ToString();
            inversion_total_tb.Text = (lote.InversionUnidad * lote.UnidadesCompradas).ToString();
        }

        private void LimpiarForm()
        {
            producto_tb.Text = "N/A";
            unidades_adquiridas_tb.Text = "N/A";
            unidades_disponibles_tb.Text = "N/A";
            inversion_unidad_tb.Text = "N/A";
            precio_venta_unidad_tb.Text = "N/A";
            inversion_total_tb.Text = "N/A";
            lote_id_tb.Clear();
            lote_id_tb.Focus();
        }

        private void editar_button_Click(object sender, EventArgs e)
        {
            if (lote == null) return;
            if (Ayudantes.EsEnteroNoNegativo(unidades_disponibles_tb.Text) == false)
            {
                MessageBox.Show("Unidades disponibles inválidas.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var nuevoUnidadesDisponibles = int.Parse(unidades_disponibles_tb.Text);

            if (nuevoUnidadesDisponibles > lote.UnidadesDisponibles)
            {
                MessageBox.Show("No se permite agregar unidades al lote. Unidades disponibles inválidas.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Ayudantes.EsDecimalNoNegativo(precio_venta_unidad_tb.Text) == false)
            {
                MessageBox.Show("Precio de venta por unidad inválido.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var nuevoPrecioVenta = decimal.Parse(precio_venta_unidad_tb.Text);

            lote.PrecioVentaUnidad = nuevoPrecioVenta;
            lote.UnidadesDisponibles = nuevoUnidadesDisponibles;

            try
            {
                ConfigGlobal.conexion.EditarLote(lote);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Tarea completada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarForm();
        }
    }
}
