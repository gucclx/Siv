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
