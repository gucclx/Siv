using SivBiblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca.AccesoDatos
{
    public interface IConexionDatos
    {
        void GuardarCategorias(List<CategoriaModelo> categoria);
        List<CategoriaModelo> Categoria_Todas();
        bool CategoriaExiste(string nombreCategoria);
    }
}
