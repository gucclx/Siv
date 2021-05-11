using SivBiblioteca.Modelos;
using System.Collections.Generic;
using SivBiblioteca.Interfaces;
using SivBiblioteca.SqliteConfig;


namespace SivBiblioteca.Procesadores
{
    public class ReporteVentaProcesador : IReporteProcesador
    {
        List<ReporteVentaModelo> reportes;
        public ReporteVentaProcesador(List<ReporteVentaModelo> reportes)
        {
            this.reportes = reportes;
        }
        public void Procesar()
        {
            // Convertir representacion interna de la moneda a la representacion original.
            foreach (var reporte in reportes)
            {
                reporte.InversionLote = SqliteMoneda.ConvertirAOriginal(reporte.InversionLote);
                reporte.PrecioVentaUnidad = SqliteMoneda.ConvertirAOriginal(reporte.PrecioVentaUnidad);
            }
        }
    }
}
