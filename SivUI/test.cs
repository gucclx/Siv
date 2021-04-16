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

        private void button1_Click(object sender, EventArgs e)
        {
            var ventas = new List<VentaModelo>();
            var v = new VentaModelo();
            v.Lote = new LoteModelo();
            v.Lote.Id = 6;
            v.Unidades = 1;
            for (int i = 0; i < 1_0000; i++)
            {
                ventas.Add(v);
            }

            ConfigGlobal.conexion.GuardarVentas(ventas);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var con = new SqliteConexion();
            con.lotes_insert_fast();
        }
    }
}
