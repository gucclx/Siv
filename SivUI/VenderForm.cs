using SivBiblioteca;
using SivBiblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SivUI
{
    public partial class VenderForm : Form
    {
        BindingSource ventas = new BindingSource();
        // TODO - agregar habilidad de borrar producto del carrito
        public VenderForm()
        {
            InitializeComponent();
            ventas.DataSource = typeof(VentaModelo);
            ventas_dtgv.AutoGenerateColumns = false;
            ventas_dtgv.DataSource = ventas;
           
            var idProductoColumna = new DataGridViewTextBoxColumn();
            idProductoColumna.HeaderText = "ID";
            idProductoColumna.DataPropertyName = nameof(VentaModelo.ProductoId);
            idProductoColumna.ReadOnly = true;

            var descripcionProductoColumna = new DataGridViewTextBoxColumn();
            descripcionProductoColumna.HeaderText = "Descripción";
            descripcionProductoColumna.DataPropertyName = nameof(VentaModelo.ProductoDescripcion);
            descripcionProductoColumna.ReadOnly = true;

            var precioVentaProductoColumna = new DataGridViewTextBoxColumn();
            precioVentaProductoColumna.HeaderText = "Precio por unidad";
            precioVentaProductoColumna.DataPropertyName = nameof(VentaModelo.ProductoPrecioVenta);
            precioVentaProductoColumna.ReadOnly = false;

            var unidadescolumna = new DataGridViewTextBoxColumn();
            unidadescolumna.HeaderText = "Unidades";
            unidadescolumna.DataPropertyName = nameof(VentaModelo.Unidades);
            unidadescolumna.ReadOnly = true;

            ventas_dtgv.Columns.Add(idProductoColumna);
            ventas_dtgv.Columns.Add(precioVentaProductoColumna);
            ventas_dtgv.Columns.Add(descripcionProductoColumna);
            ventas_dtgv.Columns.Add(unidadescolumna);

        }

        private bool ValidarUnidades()
        {
            var stringUnidades = unidades_tb.Text.Trim();

            if (string.IsNullOrEmpty(stringUnidades))
            {
                return false;
            }

            int unidades = 0;
            bool unidadesSonEnteras = int.TryParse(stringUnidades, out unidades);

            if (unidadesSonEnteras)
            {
                return (unidades > 0);
            }
            else
            {
                return false;
            }
        }
        private bool ValidarIdProducto()
        {
            var stringId = producto_id_tb.Text.Trim();

            if (string.IsNullOrEmpty(stringId))
            {
                return false;
            }

            int id = 0;
            bool idEsEntero = int.TryParse(stringId, out id);

            if (idEsEntero)
            {
                return (id > 0);
            }
            else
            {
                return false;
            }
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (VentaModelo venta in ventas)
            {
                total += venta.Producto.PrecioVenta * venta.Unidades;
            }
            total_tb.Text = total.ToString();
        }
        private void agregar_producto_button_Click(object sender, EventArgs e)
        {
            if (ValidarUnidades() == false)
            {
                MessageBox.Show("Cantidad de unidades inválida", "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ValidarIdProducto() == false)
            {
                MessageBox.Show("ID del producto inválido", "ID inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var productoId = int.Parse(producto_id_tb.Text);
            var producto = ConfigGlobal.conexion.CargarProducto_PorId(productoId);

            var unidadesAVender = int.Parse(unidades_tb.Text);

            if (unidadesAVender > producto.Unidades)
            {
                MessageBox.Show($"Cantidad solicitada de unidades inválida. Solo { producto.Unidades } unidades disponibles.", "Cantidad insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var venta = new VentaModelo();
            venta.Unidades = unidadesAVender;
            venta.Producto = producto;

            ventas.Add(venta);
            
            CalcularTotal();
        }

        private void ventas_dtgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ventas.EndEdit();
            return;
            if (e.ColumnIndex != 1)
            {
                return;
            }
            var venta = (VentaModelo)ventas[e.RowIndex];
            venta.Producto.PrecioVenta = Convert.ToDecimal(ventas_dtgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
        }
    }
}
