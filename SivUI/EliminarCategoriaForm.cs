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
    public partial class EliminarCategoriaForm : Form
    {
        List<CategoriaModelo> categoriasDisponibles = ConfigGlobal.conexion.CargarCategorias();
        public EliminarCategoriaForm()
        {
            InitializeComponent();
            ActualizarListaCategorias();
        }

        private void ActualizarListaCategorias()
        {
            categorias_existentes_listbox.DataSource = null;
            categorias_existentes_listbox.DataSource = categoriasDisponibles;
            categorias_existentes_listbox.DisplayMember = nameof(CategoriaModelo.Nombre);
        }

        private void eliminar_categoria_button_Click(object sender, EventArgs e)
        {
           
            var categorias = categorias_existentes_listbox.SelectedItems.Cast<CategoriaModelo>().ToList();
        
            if (categorias.Count == 0)
            {
                return;
            }

            var mensaje = "Las categorias seleccionadas se eliminarán de la base de datos. Estas categorias ya no serán asociadas con ningún producto. ¿Desea continuar?";
            var continuar = MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (continuar == DialogResult.No)
            {
                return;
            }

            ConfigGlobal.conexion.EliminarCategorias(categorias);
            MessageBox.Show("Categorias eliminadas", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            foreach (var categoria in categorias)
            {
                categoriasDisponibles.Remove(categoria);
            }
            ActualizarListaCategorias();
        }

        private void cerrar_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
