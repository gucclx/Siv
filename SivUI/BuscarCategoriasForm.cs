using SivBiblioteca;
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
    public partial class BuscarCategoriasForm : Form
    {
        List<CategoriaModelo> resultados;
        List<CategoriaModelo> categoriasSeleccionadas = new List<CategoriaModelo>();
        ISolicitudCategoria solicitante;

        public BuscarCategoriasForm(ISolicitudCategoria solicitante)
        {
            InitializeComponent();
            this.solicitante = solicitante;
        }

        private void ActualizarResultados()
        {
            resultados_listbox.DataSource = null;
            resultados_listbox.DataSource = resultados;
            resultados_listbox.DisplayMember = nameof(CategoriaModelo.Nombre);
            resultados_listbox.ClearSelected();
        }
        private void ActualizarCategorias()
        {
            categorias_seleccionadas_listbox.DataSource = null;
            categorias_seleccionadas_listbox.DataSource = categoriasSeleccionadas;
            categorias_seleccionadas_listbox.DisplayMember = nameof(CategoriaModelo.Nombre);
            categorias_seleccionadas_listbox.ClearSelected();
        }
        private void buscar_button_Click(object sender, EventArgs e)
        {
            var nombreCategoria = nombre_categoria_tb.Text.Trim();
            if (string.IsNullOrEmpty(nombreCategoria)) return;

            try
            {
                resultados = ConfigGlobal.conexion.BuscarCategoria_PorNombre(nombreCategoria);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ActualizarResultados();
        }

        private void agregar_categoria_button_Click(object sender, EventArgs e)
        {
            var seleccion = resultados_listbox.SelectedItems.Cast<CategoriaModelo>().ToList();
            foreach (var categoria in seleccion)
            {
                categoriasSeleccionadas.Add(categoria);
                resultados.Remove(categoria);
            }
            ActualizarCategorias();
            ActualizarResultados();
        }

        private void remover_categoria_button_Click(object sender, EventArgs e)
        {
            var seleccion = categorias_seleccionadas_listbox.SelectedItems.Cast<CategoriaModelo>().ToList();
            foreach (var categoria in seleccion)
            {
                categoriasSeleccionadas.Remove(categoria);
            }
            ActualizarCategorias();
        }

        private void listo_button_Click(object sender, EventArgs e)
        {
            solicitante.CategoriasListas(categoriasSeleccionadas);
            this.Close();
        }
    }
}
