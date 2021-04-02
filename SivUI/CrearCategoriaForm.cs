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
    public partial class CrearCategoriaForm : Form
    {
        List<CategoriaModelo> categoriasSeleccionadas = new List<CategoriaModelo>();
        public CrearCategoriaForm()
        {
            InitializeComponent();
        }

        private void ActualizarListaCategorias()
        {
            categorias_listbox.DataSource = null;
            categorias_listbox.DataSource = categoriasSeleccionadas;
            categorias_listbox.DisplayMember = nameof(CategoriaModelo.Nombre);
        }

        private void agregar_categoria_button_Click(object sender, EventArgs e)
        {
            AgregarCategoria();
        }

        private void AgregarCategoria()
        {
            if (CategoriaEsValida() == false)
            {
                nombre_categoria_tb.Clear();
                nombre_categoria_tb.Focus();
                return;
            }

            var categoria = new CategoriaModelo();
            categoria.Nombre = nombre_categoria_tb.Text.Trim();
            categoriasSeleccionadas.Add(categoria);
            ActualizarListaCategorias();
            nombre_categoria_tb.Clear();
            nombre_categoria_tb.Focus();
        }

        /// <summary>
        /// valida que el nombre de la categoria no este en blanco, ya este en la lista o exista en la base de datos.
        /// </summary>
        /// <returns></returns>
        private bool CategoriaEsValida()
        {
            // esta el nombre en blanco?
            var categoriaNombre = nombre_categoria_tb.Text.Trim();
            if (String.IsNullOrEmpty(categoriaNombre))
            {               
                return false;
            }

            // intentar encontrar la categoria en la lista de categorias
            var resultado = categoriasSeleccionadas.Find(categoria => categoria.Nombre.ToLower() == categoriaNombre.ToLower());
            if (resultado != null)
            {               
                return false;
            }

            // revisar si la categoria existe en la base de datos
            if (ConfigGlobal.conexion.CategoriaExiste(categoriaNombre))
            {
                MessageBox.Show("La categoria ya existe en la base de datos", "Categoria existente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void crear_categorias_button_Click(object sender, EventArgs e)
        {
            ConfigGlobal.conexion.GuardarCategorias(categoriasSeleccionadas);
        }

        private void remover_categoria_button_Click(object sender, EventArgs e)
        {
            var categorias = categorias_listbox.SelectedItems;

            if (categorias.Count == 0)
            {
                return;
            }

            foreach (var categoria in categorias)
            {
                categoriasSeleccionadas.Remove((CategoriaModelo)categoria);
            }
            ActualizarListaCategorias();
        }

        private void nombre_categoria_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AgregarCategoria();
                e.SuppressKeyPress = true;
            }
        }
    }
}
