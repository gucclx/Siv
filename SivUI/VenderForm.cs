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

            var idLoteColumna = new DataGridViewTextBoxColumn();
            idLoteColumna.HeaderText = "ID Lote";
            idLoteColumna.DataPropertyName = nameof(VentaModelo.LoteId);
            idLoteColumna.ReadOnly = true;

            var nombreProductoColumna = new DataGridViewTextBoxColumn();
            nombreProductoColumna.HeaderText = "Producto";
            nombreProductoColumna.DataPropertyName = nameof(VentaModelo.ProductoNombre);
            nombreProductoColumna.ReadOnly = true;

            var descripcionProductoColumna = new DataGridViewTextBoxColumn();
            descripcionProductoColumna.HeaderText = "Descripción Producto";
            descripcionProductoColumna.DataPropertyName = nameof(VentaModelo.ProductoDescripcion);
            descripcionProductoColumna.ReadOnly = true;

            var precioVentaProductoColumna = new DataGridViewTextBoxColumn();
            precioVentaProductoColumna.HeaderText = "Precio por unidad";
            precioVentaProductoColumna.DataPropertyName = nameof(VentaModelo.PrecioVentaUnidad);
            precioVentaProductoColumna.ReadOnly = false;

            var unidadesColumna = new DataGridViewTextBoxColumn();
            unidadesColumna.HeaderText = "Unidades";
            unidadesColumna.DataPropertyName = nameof(VentaModelo.Unidades);

            var totalVentaColumna = new DataGridViewTextBoxColumn();
            totalVentaColumna.HeaderText = "Total";
            totalVentaColumna.DataPropertyName = nameof(VentaModelo.Total);
            totalVentaColumna.ReadOnly = true;

            ventas_dtgv.Columns.Add(idLoteColumna);
            ventas_dtgv.Columns.Add(nombreProductoColumna);
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
        private void agregar_lote_button_Click(object sender, EventArgs e)
        {
            // validar campos
            if (Ayudantes.EsEnteroPositivo(lote_id_tb.Text) == false)
            {
                MessageBox.Show("ID del lote inválido", "ID inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Ayudantes.EsEnteroPositivo(unidades_tb.Text) == false)
            {
                MessageBox.Show("Cantidad de unidades inválida", "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // cargar lote y verificar que el lote se haya encontrado

            var loteId = int.Parse(lote_id_tb.Text.Trim());
            var lote = ConfigGlobal.conexion.CargarLote_PorId(loteId);

            if (lote == null)
            {
                MessageBox.Show("El lote no existe.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // verificar que el lote no exista en la lista

            var loteExistente = ventas.List.OfType<VentaModelo>().ToList().Find(x => x.LoteId == lote.Id);
            if (loteExistente != null)
            {
                MessageBox.Show("El lote ya existe en la lista.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // verificar que existan suficientes unidades en el lote

            var unidadesAVender = int.Parse(unidades_tb.Text);

            if (unidadesAVender > lote.UnidadesDisponibles)
            {
                if (lote.UnidadesDisponibles == 0)
                {
                    MessageBox.Show($"El lote no contiene unidades.", "Lote vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                MessageBox.Show($"Cantidad solicitada de unidades inválida. Solo { lote.UnidadesDisponibles } unidades disponibles.", "Cantidad disponible insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // crear venta
            var venta = new VentaModelo();

            venta.Unidades = unidadesAVender;
            venta.Lote = lote;
            venta.PrecioVentaUnidad = lote.PrecioVentaUnidad;

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
            
            MessageBox.Show("Tarea completada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarForm();
        }

        private void ventas_dtgv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // columna precio de venta
            if (e.ColumnIndex == 3)
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
            else if (e.ColumnIndex == 4)
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

                if (intUnidadesAVender > venta.Lote.UnidadesDisponibles)
                {
                    e.Cancel = true;
                    MessageBox.Show($"Cantidad solicitada de unidades inválida. Solo { venta.Lote.UnidadesDisponibles } unidades disponibles.", "Cantidad insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            lote_id_tb.Text = "";
            lote_id_tb.Focus();
            unidades_tb.Text = "";
            comentario_tb.Clear();
            total_tb.Clear();
            ventas.DataSource = null;
            ventas.DataSource = typeof(VentaModelo);
            cliente = null;
            cliente_tb.Clear();
        }

        public void ClienteListo(ClienteModelo cliente)
        {
            if (cliente == null) return;
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
