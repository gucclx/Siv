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
using SivBiblioteca;

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

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new CrearCategoriaForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void gestionar_ventas_ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new GestionarVentasForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void crear_producto_ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var frm = new CrearProductoForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void gestionar_ventas_ToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            var frm = new GestionarVentasForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void gestionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new GestionarInventarioForm();
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

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new EliminarCategoriaForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void crearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new CrearClienteForm();
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

        private void editar_cliente_ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new EditarClienteForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
