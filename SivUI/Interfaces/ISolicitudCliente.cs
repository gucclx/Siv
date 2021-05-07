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
    /// el cual crea o busca un cliente..
    /// El form que solicita el cliente  puede implementar esta interfaz,
    /// para que el form llamado le pase el cliente  a traves del metodo
    /// definido aqui.
    /// </summary>
    public interface ISolicitudCliente
    {
        void ClienteListo(ClienteModelo cliente);
    }
}
