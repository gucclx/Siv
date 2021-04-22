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
        ISolicitudCategorias solicitante;

        public BuscarCategoriasForm(ISolicitudCategorias solicitante)
        {
            InitializeComponent();
            this.solicitante = solicitante;
        }

        /// <summary>
        ///     Actualiza la lista de resultados.
        /// </summary>
        private void ActualizarResultados()
        {
            resultados_listbox.DataSource = null;
            resultados_listbox.DataSource = resultados;
            resultados_listbox.DisplayMember = nameof(CategoriaModelo.Nombre);
            resultados_listbox.ClearSelected();
        }

        /// <summary>
        ///     Actualiza la lista de categorias seleccionadas.
        /// </summary>
        private void ActualizarCategorias()
        {
            categorias_seleccionadas_listbox.DataSource = null;
            categorias_seleccionadas_listbox.DataSource = categoriasSeleccionadas;
            categorias_seleccionadas_listbox.DisplayMember = nameof(CategoriaModelo.Nombre);
            categorias_seleccionadas_listbox.ClearSelected();
        }
        private async void buscar_button_Click(object sender, EventArgs e)
        {
            var nombreCategoria = nombre_categoria_tb.Text.Trim();
            if (string.IsNullOrEmpty(nombreCategoria)) return;

            buscar_button.Enabled = false;
            ConfigTareaLabel(mensaje: "Buscando categoria...", visible: true);

            try
            {
                resultados = await Task.Run(() => ConfigGlobal.conexion.BuscarCategoria_PorNombre(nombreCategoria));
                ActualizarResultados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buscar_button.Enabled = true;
                return;
            }
            
            ConfigTareaLabel(visible: false);
            buscar_button.Enabled = true;
        }
        private void agregar_categoria_button_Click(object sender, EventArgs e)
        {
            var seleccion = resultados_listbox.SelectedItems.Cast<CategoriaModelo>().ToList();

            foreach (var categoria in seleccion)
            {
                if (categoriasSeleccionadas.Count > 0 && categoriasSeleccionadas.Find(c => c.Id == categoria.Id) != null) continue;
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

        private void ConfigTareaLabel(string mensaje = "", bool visible = true)
        {
            tarea_label.Visible = visible;
            tarea_label.Text = mensaje;
            tarea_label.AutoSize = false;
            tarea_label.TextAlign = ContentAlignment.MiddleCenter;
            tarea_label.Dock = DockStyle.Fill;
        }
    }
}
