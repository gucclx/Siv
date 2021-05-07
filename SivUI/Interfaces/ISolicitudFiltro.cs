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
    /// el cual crea un filtro para el reporte de ventas, inventario o lotes.
    /// El form que solicita el filtro puede implementar esta interfaz,
    /// para que el form llamado le pase el filtro a traves del metodo
    /// definido aqui.
    /// </summary>
    public interface ISolicitudFiltro
    {
        void FiltroCreado(ReporteFiltroModelo filtro);
    }
}
