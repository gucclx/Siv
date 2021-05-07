using SivBiblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivUI
{
    /// <summary>
    /// Util para cuando un form desea llamar a otro form,
    /// el cual crea o busca una lista de categoria..
    /// El form que solicita las categorias puede implementar esta interfaz,
    /// para que el form llamado le pase las categorias a traves del metodo
    /// definido aqui.
    /// </summary>
    public interface ISolicitudCategorias
    {
        void CategoriasListas(List<CategoriaModelo> categorias);
    }
}
