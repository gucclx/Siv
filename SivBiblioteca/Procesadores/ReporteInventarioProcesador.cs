using SivBiblioteca.AccesoDatos;
using SivBiblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SivBiblioteca.Interfaces;

namespace SivBiblioteca.Procesadores
{
    public class ReporteInventarioProcesador : IReporteProcesador
    {
        List<ReporteInventarioModelo> reportes;
        public ReporteInventarioProcesador(List<ReporteInventarioModelo> reportes)
        {
            this.reportes = reportes;
        }

        public void Procesar()
        {
            foreach (var reporte in reportes)
            {
                reporte.InversionUnidadesProducto = SqliteMoneda.ConvertirAOriginal(reporte.InversionUnidadesProducto);
            }
        }
    }
}
