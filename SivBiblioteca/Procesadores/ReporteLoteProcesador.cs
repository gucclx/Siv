using SivBiblioteca.Modelos;
using System.Collections.Generic;
using SivBiblioteca.Interfaces;
using SivBiblioteca.SqliteConfig;


namespace SivBiblioteca.Procesadores
{
    public class ReporteLoteProcesador : IReporteProcesador
    {
        List<ReporteLoteModelo> reportes;
        public ReporteLoteProcesador(List<ReporteLoteModelo> reportes)
        {
            this.reportes = reportes;
        }

        public void Procesar()
        {
            foreach (var reporte in reportes)
            {
                reporte.InversionLote = SqliteMoneda.ConvertirAOriginal(reporte.InversionLote);
                reporte.PrecioVentaUnidad = SqliteMoneda.ConvertirAOriginal(reporte.PrecioVentaUnidad);
            }
        }
    }
}
