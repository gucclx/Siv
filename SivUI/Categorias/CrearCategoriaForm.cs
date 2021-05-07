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

namespace SivUI.Categorias
{
    public partial class CrearCategoriaForm : Form
    {
        List<CategoriaModelo> categoriasSeleccionadas = new List<CategoriaModelo>();
        ISolicitudCategorias solicitante;
        public CrearCategoriaForm(ISolicitudCategorias solicitante = null)
        {
            InitializeComponent();
            this.solicitante = solicitante;
            nombre_categoria_tb.Focus();
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

        private bool CategoriaEsValida()
        {
            // esta el nombre en blanco?
            var categoriaNombre = nombre_categoria_tb.Text.Trim();
            if (String.IsNullOrWhiteSpace(categoriaNombre))
            {               
                return false;
            }

            // existe la categoria en la lista?
            var resultado = categoriasSeleccionadas.Find(categoria => categoria.Nombre.ToLower().Trim() == categoriaNombre.ToLower());

            if (resultado != null)
            {               
                return false;
            }

            var categoriaExiste = true;

            try
            {
                categoriaExiste = ConfigGlobal.conexion.CategoriaExiste(categoriaNombre);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // existe la categoria en la base de datos?
            if (categoriaExiste)
            {
                MessageBox.Show("La categoria ya existe en la base de datos", "Categoria existente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void crear_categorias_button_Click(object sender, EventArgs e)
        {
            if (categoriasSeleccionadas.Count == 0) return;

            try
            {
                ConfigGlobal.conexion.GuardarCategorias(categoriasSeleccionadas);              
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (solicitante != null)
            {
                solicitante.CategoriasListas(categoriasSeleccionadas);
            }
            
            MessageBox.Show("Tarea completada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void remover_categoria_button_Click(object sender, EventArgs e)
        {
            var categorias = categorias_listbox.SelectedItems;

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
