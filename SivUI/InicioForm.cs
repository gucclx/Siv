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
    public partial class InicioForm : Form, ISolicitudCategoria
    {
        public InicioForm()
        {
            InitializeComponent();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new InventarioAgregarForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void agregarToolStripMenuItem_Click_1(object sender, EventArgs e)
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
            var frm = new CrearCategoriaForm(this);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        public void CategoriaCreada(List<CategoriaModelo> categorias)
        {
            
        }

        private void gestionarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new GestionarVentasForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
