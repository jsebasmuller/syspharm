using PagedList;
using Syncfusion.XlsIO;
using SysPharm.Models;
using SysPharm.Models.ViewModel;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysPharm.Controllers
{
  public class PedidoController
  {
    private readonly Context _context;

    public PedidoController(Context context)
    {
      _context = context;
    }

    public ResponseViewModel RegisterPedido(Pedido pedido)
    {
      var response = new ResponseViewModel();
      _context.Pedidos.Add(pedido);
      try
      {
        _context.SaveChanges();
        foreach (var detallePedido in pedido.DetallesPedido)
        {
          var medicamentoDb = _context.Medicamentos.Where(m => m.Id == detallePedido.IdMedicamento).FirstOrDefault();
          if (medicamentoDb.VlrVenta != detallePedido.VlrVenta)
          {
            medicamentoDb.VlrVenta = (medicamentoDb.VlrVenta + detallePedido.VlrVenta) / 2;
          }
          medicamentoDb.Cantidad += detallePedido.Cantidad;
          _context.SaveChanges();
        }
        response.Respuesta = true;
        response.Mensaje = "¡Pedido registrado satisfactoriamente!";
      }
      catch (Exception e)
      {
        response.Respuesta = false;
        response.Mensaje = e.Message;
        return response;
      }
      return response;
    }

    public List<Pedido> GetPedidos()
    {
      return _context.Pedidos.OrderByDescending(x => x.Id).ToList();
    }

    public IPagedList<Pedido> GetPedidosPag(int? pagina)
    {
      int pageNumber = pagina ?? 1;
      return _context.Pedidos.OrderByDescending(x => x.Id).ToPagedList(pageNumber, 13);
    }

    public IPagedList<Pedido> BuscadorPag(string txtBuscar, int? pagina)
    {
      int pageNumber = pagina ?? 1;
      return _context.Pedidos.Where(x => x.Id.Trim().ToLower().Contains(txtBuscar.Trim().ToLower()) ||
                                            x.Proveedor.Trim().ToLower().Contains(txtBuscar.Trim().ToLower()) ||
                                            x.VlrTotal.ToString().Trim().ToLower().Contains(txtBuscar.Trim().ToLower()) ||
                                            x.FechaIngreso.ToString().Trim().Contains(txtBuscar.Trim()) ||
                                            x.FechaPedido.ToString().Trim().ToLower().Contains(txtBuscar.Trim().ToLower())).OrderByDescending(x => x.Id).ToPagedList(pageNumber, 13);
    }

    public string GetNextId(DateTime fechaAct)
    {
      DateTime fechaInicio = new DateTime(fechaAct.Year, fechaAct.Month, 1);
      DateTime fechaFinal = fechaInicio.AddMonths(1);
      var lastAnt = _context.Pedidos.Where(a => a.FechaIngreso >= fechaInicio && a.FechaIngreso < fechaFinal)
                          .OrderByDescending(a => a.Id).Select(a => a.Id).Take(1).FirstOrDefault();
      if (lastAnt == null)
      {
        return $"{fechaAct.ToString("yyyyMM")}01";
      }
      else
      {
        return $"{Convert.ToInt32(lastAnt) + 1}";
      }
    }

    public ResponseViewModel Report(DateTime fecha, string path)
    {
      ResponseViewModel response = new ResponseViewModel();
      try
      {
        using (ExcelEngine excelEngine = new ExcelEngine())
        {
          IApplication application = excelEngine.Excel;

          application.DefaultVersion = ExcelVersion.Excel2010;
          var pedidos = _context.DetallesPedido
                                  .Include(dp => dp.Pedido)
                                  .Include(dp => dp.Medicamento)
                                  .Where(dp => dp.Pedido.FechaIngreso.Year == fecha.Year && dp.Pedido.FechaIngreso.Month == fecha.Month)
                                  .OrderByDescending(dp => dp.IdPedido).ToList();

          //Create a workbook
          IWorkbook workbook = application.Workbooks.Create(1);
          IWorksheet worksheet = workbook.Worksheets[0];
          worksheet.Name = $"PEDIDOS MES {fecha.ToString("MMMM").ToUpper()}";
          int row = 2;
          worksheet.IsGridLinesVisible = false;

          #region WorkSheetMes
          worksheet.Range["A1:L10000"].CellStyle.Font.FontName = "Arial";
          worksheet.Range["A1:L10000"].CellStyle.Font.Size = 11;
          worksheet.Range["A1:L10000"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
          worksheet.Range["A1:L10000"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;
          worksheet.Range["A1:L1"].CellStyle.Color = Color.FromArgb(89, 193, 203);
          worksheet.Range["A1:L1"].CellStyle.Font.Bold = true;
          worksheet.Range["A1:L1"].CellStyle.Font.RGBColor = Color.FromArgb(255, 255, 255);
          worksheet.Range["A1"].Text = "NÚMERO FACTURA";
          worksheet.Range["A1"].ColumnWidth = 12.86;
          worksheet.Range["B1"].Text = "FECHA DE SOLICITUD";
          worksheet.Range["B1"].ColumnWidth = 13.57;
          worksheet.Range["C1"].Text = "FECHA DE RECEPCIÓN";
          worksheet.Range["C1"].ColumnWidth = 17;
          worksheet.Range["D1"].Text = "PROVEEDOR";
          worksheet.Range["D1"].ColumnWidth = 30.14;
          worksheet.Range["E1"].Text = "NOMBRE DEL MEDICAMENTO";
          worksheet.Range["E1"].ColumnWidth = 51.57;
          worksheet.Range["F1"].Text = "REGISTRO SANITARIO";
          worksheet.Range["F1"].ColumnWidth = 20.43;
          worksheet.Range["G1"].Text = "LOTE N.o";
          worksheet.Range["G1"].ColumnWidth = 14.14;;
          worksheet.Range["H1"].Text = "CANT SOLICITADA";
          worksheet.Range["H1"].ColumnWidth = 14;
          worksheet.Range["I1"].Text = "CANT RECIBIDA";
          worksheet.Range["I1"].ColumnWidth = 10.71;
          worksheet.Range["J1"].Text = "VALOR UNIDAD";
          worksheet.Range["J1"].ColumnWidth = 10.71;
          worksheet.Range["K1"].Text = "VALOR TOTAL";
          worksheet.Range["K1"].ColumnWidth = 10.71;
          worksheet.Range["L1"].Text = "CUM";
          worksheet.Range["L1"].ColumnWidth = 17.86;
          foreach (var detalle in pedidos)
          {
            worksheet.Range[$"A{row}"].Text = detalle.Pedido.NumeroFactura;
            worksheet.Range[$"B{row}"].Text = detalle.Pedido.FechaPedido.ToString("dd/MM/yyyy");
            worksheet.Range[$"C{row}"].Text = detalle.Pedido.FechaIngreso.ToString("dd/MM/yyyy");
            worksheet.Range[$"D{row}"].Text = detalle.Pedido.Proveedor;
            worksheet.Range[$"E{row}"].Text = detalle.Medicamento.Nombre;
            worksheet.Range[$"F{row}"].Text = detalle.RegSanitario;
            worksheet.Range[$"G{row}"].Text = detalle.Lote;
            worksheet.Range[$"H{row}"].Number = detalle.Cantidad;
            worksheet.Range[$"I{row}"].Number = detalle.Cantidad;
            worksheet.Range[$"J{row}"].NumberFormat = "_($* #,##0_)";
            worksheet.Range[$"J{row}"].Number = detalle.VlrCompra;
            worksheet.Range[$"K{row}"].NumberFormat = "_($* #,##0_)";
            worksheet.Range[$"K{row}"].Number = detalle.VlrCompra * detalle.Cantidad;
            worksheet.Range[$"L{row}"].Text = detalle.CUM;
            row++;
          }
          worksheet.PageSetup.PrintArea = $"$A$1:$L${row-1}";
          worksheet.Range[$"A1:L{row-1}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A1:L{row-1}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A1:L{row-1}"].CellStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A1:L{row-1}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A2:L{(row == 2 ? row : row-1)}"].CellStyle.Font.RGBColor = Color.FromArgb(0, 0, 0);
          worksheet.Range[$"A1:L{row-1}"].CellStyle.WrapText = true;
          worksheet.PageSetup.Orientation = ExcelPageOrientation.Portrait;
          worksheet.PageSetup.FitToPagesWide = 1;
          worksheet.PageSetup.PaperSize = ExcelPaperSize.PaperLetter;
          worksheet.View = SheetView.PageBreakPreview;
          #endregion
          workbook.SaveAs(path);
          response.Respuesta = true;
          response.Mensaje = "El informe ha sido guardado satisfactoriamente.";
        }
      }
      catch (Exception e)
      {
        response.Respuesta = false;
        response.Mensaje = e.Message;
        return response;
      }
      return response;
    }
  }
}
