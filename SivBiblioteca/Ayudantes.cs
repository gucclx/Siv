using ClosedXML.Excel;
using SivBiblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca
{
    public static class Ayudantes
    {        
        public static bool EsEnteroPositivo(string x)
        {
            x = x.Trim();
            if (string.IsNullOrEmpty(x)) { return false; }

            int intX = 0;
            bool xEsEntero = int.TryParse(x, out intX);

            return xEsEntero && (intX > 0);

        }

        public static bool EsDecimalNoNegativo(string x)
        {
            x = x.Trim();
            if (string.IsNullOrEmpty(x)) { return false; }

            decimal decimalX = 0;
            bool xEsDecimal = decimal.TryParse(x, out decimalX);

            return xEsDecimal && (decimalX >= 0);
        }
        
        public static void GuardarExcelReporteVentas(List<ReporteVenta> reportes, FileInfo archivo)
        {
            if (archivo.Exists)
            {
                archivo.Delete();
            }
        
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Reporte Ventas");

            var tituloRango = ws.Range(ws.Cell(1, 1).Address, ws.Cell(1, 10).Address).Merge();
            tituloRango.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            tituloRango.Value = "Reporte de ventas";
            tituloRango.Style.Font.Bold = true;
            tituloRango.Style.Font.FontSize = 16;
            tituloRango.Style.Fill.SetBackgroundColor(XLColor.CornflowerBlue);

            var titulos = new List<string>
                ( 
                    new[]
                    {
                        "ID Lote",
                        "Producto",
                        "Unidades Vendidas",
                        "Inversión Unidad",
                        "Precio Venta Unidad",
                        "Inversión Venta",
                        "Ingreso Venta",
                        "Ganancia Venta",
                        "Fecha Venta",
                        "Cliente"
                    }
                );



            for (int i = 1; i <= titulos.Count; i++)
            {
                ws.Cell(2, i).Value = titulos[i - 1];
                ws.Cell(2, i).Style.Font.Bold = true;
            }

            for (int i = 0; i < reportes.Count; i++)
            {
                ws.Cell(3 + i, 1).Value = reportes[i].LoteId;
                ws.Cell(3 + i, 2).Value = reportes[i].NombreProducto;
                ws.Cell(3 + i, 3).Value = reportes[i].UnidadesVendidas;
                ws.Cell(3 + i, 4).Value = reportes[i].InversionUnidad;
                ws.Cell(3 + i, 5).Value = reportes[i].PrecioVentaUnidad;
                ws.Cell(3 + i, 6).Value = reportes[i].InversionVenta;
                ws.Cell(3 + i, 7).Value = reportes[i].IngresoVenta;
                ws.Cell(3 + i, 8).Value = reportes[i].GananciaVenta;
                ws.Cell(3 + i, 9).Value = reportes[i].FechaVenta;
                ws.Cell(3 + i, 10).Value = reportes[i].NombreCliente;
            }

            //var test = reportes.Select(r => 
            //    new
            //    {
            //        r.LoteId,
            //        r.NombreProducto,
            //        r.UnidadesVendidas,
            //        r.InversionUnidad,
            //        r.PrecioVentaUnidad,
            //        r.InversionVenta,
            //        r.IngresoVenta,
            //        r.GananciaVenta,
            //        r.FechaVenta,
            //        r.NombreCliente
            //    }
            //);
            ws.Columns().AdjustToContents();

            wb.SaveAs(archivo.FullName);
        }
    }
}
