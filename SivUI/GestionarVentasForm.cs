using SivBiblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SivBiblioteca.Modelos;

namespace SivUI
{
    public partial class GestionarVentasForm : Form, ISolicitudFiltro
    {
        BindingSource resultados;
        ReporteFiltro reporteFiltro;
        public GestionarVentasForm()
        {
            InitializeComponent();
            resultados_dtgv.AutoGenerateColumns = false;

            // inicializar columnas

            var loteIdColumna = new DataGridViewTextBoxColumn();
            loteIdColumna.HeaderText = "ID Lote";
            loteIdColumna.DataPropertyName = nameof(ReporteVenta.LoteId);

            var nombreProductoColumna = new DataGridViewTextBoxColumn();
            nombreProductoColumna.HeaderText = "Producto";
            nombreProductoColumna.DataPropertyName = nameof(ReporteVenta.NombreProducto);

            var unidadesVendidasColumna = new DataGridViewTextBoxColumn();
            unidadesVendidasColumna.HeaderText = "Unidades Vendidas";
            unidadesVendidasColumna.DataPropertyName = nameof(ReporteVenta.UnidadesVendidas);

            var inversionUnidadColumna = new DataGridViewTextBoxColumn();
            inversionUnidadColumna.HeaderText = "Inversión Unidad";
            inversionUnidadColumna.DataPropertyName = nameof(ReporteVenta.InversionUnidad);

            var precioVentaUnidadColumna = new DataGridViewTextBoxColumn();
            precioVentaUnidadColumna.HeaderText = "Precio Venta Unidad";
            precioVentaUnidadColumna.DataPropertyName = nameof(ReporteVenta.PrecioVentaUnidad);

            var inversionVentaColumna = new DataGridViewTextBoxColumn();
            inversionVentaColumna.HeaderText = "Inversión Venta";
            inversionVentaColumna.DataPropertyName = nameof(ReporteVenta.InversionVenta);

            var ingresoVentaColumna = new DataGridViewTextBoxColumn();
            ingresoVentaColumna.HeaderText = "Ingreso Venta";
            ingresoVentaColumna.DataPropertyName = nameof(ReporteVenta.IngresoVenta);

            var gananciaVentaColumna = new DataGridViewTextBoxColumn();
            gananciaVentaColumna.HeaderText = "Ganancia Venta";
            gananciaVentaColumna.DataPropertyName = nameof(ReporteVenta.GananciaVenta);

            var fechaVentaColumna = new DataGridViewTextBoxColumn();
            fechaVentaColumna.HeaderText = "Fecha Venta";
            fechaVentaColumna.DataPropertyName = nameof(ReporteVenta.FechaVenta);

            var nombreClienteColumna = new DataGridViewTextBoxColumn();
            nombreClienteColumna.HeaderText = "Cliente";
            nombreClienteColumna.DataPropertyName = nameof(ReporteVenta.NombreCliente);

            resultados_dtgv.Columns.Add(loteIdColumna);
            resultados_dtgv.Columns.Add(nombreProductoColumna);
            resultados_dtgv.Columns.Add(unidadesVendidasColumna);
            resultados_dtgv.Columns.Add(inversionUnidadColumna);
            resultados_dtgv.Columns.Add(precioVentaUnidadColumna);
            resultados_dtgv.Columns.Add(inversionVentaColumna);
            resultados_dtgv.Columns.Add(ingresoVentaColumna);
            resultados_dtgv.Columns.Add(gananciaVentaColumna);
            resultados_dtgv.Columns.Add(fechaVentaColumna);
            resultados_dtgv.Columns.Add(nombreClienteColumna);
        }

        private void cargar_reporte_button_Click(object sender, EventArgs e)
        {
            try
            {
                var reportes = ConfigGlobal.conexion.ReporteVentas(reporteFiltro);
                resultados = new BindingSource();
                resultados.DataSource = reportes;
                resultados_dtgv.DataSource = resultados;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CalcularResumenReporte();
        }

        private void filtros_button_Click(object sender, EventArgs e)
        {
            var frm = new CrearFiltroForm(this, reporteFiltro);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
        private void CalcularResumenReporte()
        {
            decimal totalGanancia = 0;
            decimal totalIngreso = 0;
            decimal totalInversion = 0;

            foreach(ReporteVenta reporte in resultados)
            {
                totalGanancia += reporte.GananciaVenta;
                totalIngreso += reporte.IngresoVenta;
                totalInversion += reporte.InversionVenta;
            }

            total_ganancia_tb.Text = totalGanancia.ToString();
            total_ingreso_tb.Text = totalIngreso.ToString();
            total_inversion_tb.Text = totalInversion.ToString();
        }

        public void FiltroCreado(ReporteFiltro filtro)
        {
            reporteFiltro = filtro;
        }
    }
}
