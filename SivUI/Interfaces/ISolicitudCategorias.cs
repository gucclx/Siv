using SivBiblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivUI
{
    public interface ISolicitudCategorias
    {
        void CategoriasListas(List<CategoriaModelo> categorias);
    }
}
