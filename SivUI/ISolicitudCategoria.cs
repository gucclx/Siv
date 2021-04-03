using SivBiblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivUI
{
    public interface ISolicitudCategoria
    {
        void CategoriaCreada(List<CategoriaModelo> categorias);
    }
}
