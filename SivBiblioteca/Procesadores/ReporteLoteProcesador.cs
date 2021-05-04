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
