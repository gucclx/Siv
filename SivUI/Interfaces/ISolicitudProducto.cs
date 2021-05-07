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
    /// el cual crea o busca un producto.
    /// El form que solicita el producto puede implementar esta interfaz,
    /// para que el form llamado le pase el producto a traves del metodo
    /// definido aqui.
    /// </summary>
    public interface ISolicitudProducto
    {
        void ProductoListo(ProductoModelo producto);
    }
}
