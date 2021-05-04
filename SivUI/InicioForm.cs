using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SivUI.Inventario;
using SivUI.Ventas;
using SivUI.ExportarUI;
using SivUI.Categorias;
using SivUI.Clientes;
using SivUI.Productos;
using SivUI.Lotes;


namespace SivUI
{
    public partial class InicioForm : Form
    {
        public InicioForm()
        {
            InitializeComponent();
        }

        private void agregar_inventario_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new InventarioAgregarForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void venderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new VenderForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void crear_categorias_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new CrearCategoriaForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void historial_ventas_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new VentasForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new ExportarForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void eliminar_categorias_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new EliminarCategoriaForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void editar_producto_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new EditarProductoForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void editar_lotes_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new EditarLoteForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void crear_clientes_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new CrearClienteForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void editar_cliente_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new EditarClienteForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void ver_inventario_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new InventarioForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void historial_lotes_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new HistorialLotesForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void crear_producto_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new CrearProductoForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void eliminar_venta_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new EliminarVentaForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
