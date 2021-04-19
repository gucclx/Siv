using SivBiblioteca;
using SivBiblioteca.AccesoDatos;
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
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            List<CategoriaModelo> cat = null;
            foreach (var categoria in cat)
            {
                var n = categoria.Nombre;
            }
            return;
            var con = new SqliteConexion();
            con.lotes_insert_fast();
        }
    }
}
