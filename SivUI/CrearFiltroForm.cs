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
    public partial class CrearFiltroForm : Form, ISolicitudCategoria
    {
        List<CategoriaModelo> categoriasSeleccionadas = new List<CategoriaModelo>();
        ISolicitudFiltro solicitante;
        public CrearFiltroForm(ISolicitudFiltro solicitante, ReporteFiltro filtro = null)
        {
            InitializeComponent();
            this.solicitante = solicitante;
            
            if (filtro != null)
            {
                categoriasSeleccionadas = filtro.Categorias;
                habilitar_fechas_checkbox.Checked = filtro.FiltroPorFechas;
                fecha_inicial_dtp.Value = filtro.FechaInicial;
                fecha_final_dtp.Value = filtro.FechaFinal;
                ActualizarCategorias();
            }
        }

        private void ActualizarCategorias()
        {
            categorias_listbox.DataSource = null;
            categorias_listbox.DataSource = categoriasSeleccionadas;
            categorias_listbox.DisplayMember = nameof(CategoriaModelo.Nombre);
        }

        private void habilitar_fechas_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            fechas_groupbox.Enabled = habilitar_fechas_checkbox.Checked;
        }

        private void agregar_categorias_button_Click(object sender, EventArgs e)
        {
            var frm = new BuscarCategoriasForm(this);
            frm.Show();
        }

        public void TareaCompleta(List<CategoriaModelo> categorias)
        {
            foreach(var categoria in categorias)
            {
                categoriasSeleccionadas.Add(categoria);
            }
            ActualizarCategorias();
        }

        private void remover_categoria_button_Click(object sender, EventArgs e)
        {
            var seleccion = categorias_listbox.SelectedItems.Cast<CategoriaModelo>().ToList();

            foreach (var categoria in seleccion)
            {
                categoriasSeleccionadas.Remove(categoria);
            }
            ActualizarCategorias();
        }

        private void listo_button_Click(object sender, EventArgs e)
        {
            var filtro = new ReporteFiltro();
            filtro.Categorias = categoriasSeleccionadas;
            filtro.FechaInicial = fecha_inicial_dtp.Value.Date;
            filtro.FechaFinal = fecha_final_dtp.Value;
            filtro.FiltroPorFechas = habilitar_fechas_checkbox.Checked;

            solicitante.FiltroCreado(filtro);
            MessageBox.Show("Filtro configurado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
