using SivBiblioteca.Modelos;
using System.Collections.Generic;
using SivBiblioteca.Interfaces;
using SivBiblioteca.SqliteConfig;


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
