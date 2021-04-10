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
    public partial class EliminarCategoriaForm : Form, ISolicitudCategoria
    {
        List<CategoriaModelo> CategoriasAEliminar;
        public EliminarCategoriaForm()
        {
            InitializeComponent();
            ActualizarListaCategorias();
        }

        private void ActualizarListaCategorias()
        {
            categorias_listbox.DataSource = null;
            categorias_listbox.DataSource = CategoriasAEliminar;
            categorias_listbox.DisplayMember = nameof(CategoriaModelo.Nombre);
        }

        private void eliminar_categoria_button_Click(object sender, EventArgs e)
        {
            
            var mensaje = "Las categorias seleccionadas se eliminarán de la base de datos. Estas categorias ya no serán asociadas con ningún producto. ¿Desea continuar?";
            var continuar = MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (continuar == DialogResult.No)
            {
                return;
            }

            try
            {
                ConfigGlobal.conexion.EliminarCategorias(CategoriasAEliminar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CategoriasAEliminar = null;
            
            MessageBox.Show("Categorias eliminadas", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ActualizarListaCategorias();
        }

        private void buscar_categoria_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new BuscarCategoriasForm(this);
            frm.Show();
        }

        public void CategoriasListas(List<CategoriaModelo> categorias)
        {
            CategoriasAEliminar = categorias;
            ActualizarListaCategorias();
        }

        private void remover_button_Click(object sender, EventArgs e)
        {
            var categoriasSeleccionadas = categorias_listbox.SelectedItems.Cast<CategoriaModelo>().ToList();
            foreach (var categoria in categoriasSeleccionadas)
            {
                CategoriasAEliminar.Remove(categoria);
            }
        }
    }
}
