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
           
            // inicializar columnas

            var idProductoColumna = new DataGridViewTextBoxColumn();
            idProductoColumna.HeaderText = "ID Producto";
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

            var unidadesColumna = new DataGridViewTextBoxColumn();
            unidadesColumna.HeaderText = "Unidades";
            unidadesColumna.DataPropertyName = nameof(VentaModelo.Unidades);

            var totalVentaColumna = new DataGridViewTextBoxColumn();
            totalVentaColumna.HeaderText = "Total";
            totalVentaColumna.DataPropertyName = nameof(VentaModelo.Total);
            totalVentaColumna.ReadOnly = true;

            ventas_dtgv.Columns.Add(idProductoColumna);
            ventas_dtgv.Columns.Add(precioVentaProductoColumna);
            ventas_dtgv.Columns.Add(descripcionProductoColumna);
            ventas_dtgv.Columns.Add(unidadesColumna);
            ventas_dtgv.Columns.Add(totalVentaColumna);

        }

        // TODO - refactorizar codigo, implementar EsEnteroPositivo(), EsDecimalPositivo() ya que el mismo patron ocurre en multiples forms
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
                total += venta.Total;
            }
            total_tb.Text = total.ToString();
        }
        private void agregar_producto_button_Click(object sender, EventArgs e)
        {
            // validar campos
            if (ValidarIdProducto() == false)
            {
                MessageBox.Show("ID del producto inválido", "ID inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ValidarUnidades() == false)
            {
                MessageBox.Show("Cantidad de unidades inválida", "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // cargar producto y verificar que el producto se haya encontrado
            var productoId = int.Parse(producto_id_tb.Text);
            var producto = ConfigGlobal.conexion.CargarProducto_PorId(productoId);

            if (producto == null)
            {
                MessageBox.Show("El producto no existe.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // verificar que el producto no exista en la lista
            var productoExistente = ventas.List.OfType<VentaModelo>().ToList().Find(x => x.ProductoId == productoId);
            if (productoExistente != null)
            {

                MessageBox.Show("El producto ya existe en la lista.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // verificar que existan suficientes unidades del producto
            var unidadesAVender = int.Parse(unidades_tb.Text);

            if (unidadesAVender > producto.Unidades)
            {
                MessageBox.Show($"Cantidad solicitada de unidades inválida. Solo { producto.Unidades } unidades disponibles.", "Cantidad insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            // crear venta
            var venta = new VentaModelo();
            venta.Unidades = unidadesAVender;
            venta.Producto = producto;
         
            ventas.Add(venta);            
            CalcularTotal();
        }

        private void vender_button_Click(object sender, EventArgs e)
        {
            // verificar que la lista no este vacia
            var listaVentas = ventas.List.OfType<VentaModelo>().ToList();
            if (listaVentas.Count == 0)
            {
                return;
            }

            ConfigGlobal.conexion.GuardarVentas(listaVentas);
            MessageBox.Show("Acción completada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ventas_dtgv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // columna precio de venta
            if (e.ColumnIndex == 1)
            {
                decimal precioVenta = 0;
                bool precioVentaEsDecimal = decimal.TryParse(e.FormattedValue.ToString(), out precioVenta);

                if (!precioVentaEsDecimal || precioVenta < 0)
                {
                    MessageBox.Show("Precio de venta inválido", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                var venta = ((VentaModelo)ventas_dtgv.Rows[e.RowIndex].DataBoundItem);
                venta.Producto.PrecioVenta = precioVenta;
                CalcularTotal();
            }
            // columna unidades
            else if (e.ColumnIndex == 3)
            {
                int unidadesAVender = 0;
                bool unidadesAVenderEsDecimal = int.TryParse(e.FormattedValue.ToString(), out unidadesAVender);

                if (!unidadesAVenderEsDecimal || unidadesAVender < 1)
                {
                    e.Cancel = true;
                    MessageBox.Show($"Cantidad solicitada de unidades inválida.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var venta = ((VentaModelo)ventas_dtgv.Rows[e.RowIndex].DataBoundItem);

                if (unidadesAVender > venta.Producto.Unidades)
                {
                    e.Cancel = true;
                    MessageBox.Show($"Cantidad solicitada de unidades inválida. Solo { venta.Producto.Unidades } unidades disponibles.", "Cantidad insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                venta.Unidades = unidadesAVender;
                CalcularTotal();          
            }
        }
    }
}
