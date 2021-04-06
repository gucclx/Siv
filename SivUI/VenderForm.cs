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
    public partial class VenderForm : Form, ISolicitudCliente
    {
        BindingSource ventas = new BindingSource();
        ClienteModelo cliente;
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
            ventas_dtgv.Columns.Add(descripcionProductoColumna);
            ventas_dtgv.Columns.Add(precioVentaProductoColumna);            
            ventas_dtgv.Columns.Add(unidadesColumna);
            ventas_dtgv.Columns.Add(totalVentaColumna);

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
            if (Ayudantes.EsEnteroPositivo(producto_id_tb.Text) == false)
            {
                MessageBox.Show("ID del producto inválido", "ID inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Ayudantes.EsEnteroPositivo(unidades_tb.Text) == false)
            {
                MessageBox.Show("Cantidad de unidades inválida", "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // cargar producto y verificar que el producto se haya encontrado
            var productoId = int.Parse(producto_id_tb.Text.Trim());
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
            venta.PrecioVentaUnidad = producto.PrecioVenta;
         
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

            foreach (VentaModelo venta in ventas)
            {
                venta.Comentario = comentario_tb.Text.Trim();
                venta.Cliente = cliente;
            }

            try
            {
                ConfigGlobal.conexion.GuardarVentas(listaVentas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            MessageBox.Show("Acción completada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarForm();
        }

        private void ventas_dtgv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // columna precio de venta
            if (e.ColumnIndex == 2)
            {
                if (Ayudantes.EsDecimalNoNegativo(e.FormattedValue.ToString()) == false)
                {
                    MessageBox.Show("Precio de venta inválido", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                var venta = ((VentaModelo)ventas_dtgv.Rows[e.RowIndex].DataBoundItem);
                venta.PrecioVentaUnidad = decimal.Parse(e.FormattedValue.ToString().Trim());
                CalcularTotal();
            }
            // columna unidades
            else if (e.ColumnIndex == 3)
            {
                var stringUnidadesAVender = e.FormattedValue.ToString().Trim();
                if (Ayudantes.EsEnteroPositivo(stringUnidadesAVender) == false)
                {
                    e.Cancel = true;
                    MessageBox.Show($"Cantidad solicitada de unidades inválida.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var venta = ((VentaModelo)ventas_dtgv.Rows[e.RowIndex].DataBoundItem);
                var intUnidadesAVender = int.Parse(stringUnidadesAVender);

                if (intUnidadesAVender > venta.Producto.Unidades)
                {
                    e.Cancel = true;
                    MessageBox.Show($"Cantidad solicitada de unidades inválida. Solo { venta.Producto.Unidades } unidades disponibles.", "Cantidad insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                venta.Unidades = intUnidadesAVender;
                CalcularTotal();          
            }
        }
      
        private void remover_venta_button_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in ventas_dtgv.SelectedRows)
            {
                ventas_dtgv.Rows.RemoveAt(r.Index);
            }
        }

        private void buscar_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new BuscarClienteForm(this);
            frm.Show();
        }

        private void LimpiarForm()
        {
            producto_id_tb.Text = "";
            producto_id_tb.Focus();
            unidades_tb.Text = "";
            comentario_tb.Clear();
            ventas.DataSource = null;
            ventas.DataSource = typeof(VentaModelo);
            cliente = null;
            cliente_tb.Clear();
        }

        public void ClienteListo(ClienteModelo cliente)
        {
            this.cliente = cliente;
            cliente_tb.Text = this.cliente.NombreCompleto;            
        }

        private void crear_nuevo_cliente_label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new CrearClienteForm(this);
            frm.Show();
        }

        private void limpiar_cliente_button_Click(object sender, EventArgs e)
        {
            cliente = null;
            cliente_tb.Clear();
        }
    }
}
