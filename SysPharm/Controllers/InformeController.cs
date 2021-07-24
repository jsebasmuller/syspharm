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
  public class InformeController
  {
    private readonly Context _context;

    public InformeController(Context context)
    {
      _context = context;
    }

    public ResponseViewModel ReportMonth(DateTime fecha, string path)
    {
      ResponseViewModel response = new ResponseViewModel();
      try
      {
        using (ExcelEngine excelEngine = new ExcelEngine())
        {
          IApplication application = excelEngine.Excel;

          application.DefaultVersion = ExcelVersion.Excel2010;

          //Create a workbook
          IWorkbook workbook = application.Workbooks.Create(2);
          IWorksheet worksheetRes = workbook.Worksheets[0];
          IWorksheet worksheet = workbook.Worksheets[1];
          worksheetRes.Name = "RESUMEN";
          worksheet.Name = $"INFORME MES {fecha.ToString("MMMM").ToUpper()}";

          worksheet.IsGridLinesVisible = false;
          worksheetRes.IsGridLinesVisible = false;

          IPictureShape shapeIconSP = worksheet.Pictures.AddPicture(1, 1, System.IO.Path.Combine(Application.StartupPath, "IconoSysPharm.png"));
          IPictureShape shapeIconRSP = worksheetRes.Pictures.AddPicture(1, 1, System.IO.Path.Combine(Application.StartupPath, "IconoSysPharm.png"));
          shapeIconSP.Top = 5;
          shapeIconSP.Left = 63;
          shapeIconRSP.Top = 5;
          shapeIconRSP.Left = 63;

          shapeIconSP.Height = 70;
          shapeIconSP.Width = 91;
          shapeIconRSP.Height = 70;
          shapeIconRSP.Width = 91;

          IPictureShape shapeESE = worksheet.Pictures.AddPicture(1, 1, System.IO.Path.Combine(Application.StartupPath, "IconoESE.png"));
          IPictureShape shapeRESE = worksheetRes.Pictures.AddPicture(1, 1, System.IO.Path.Combine(Application.StartupPath, "IconoESE.png"));
          shapeESE.Top = 5;
          shapeESE.Left = 402;
          shapeRESE.Top = 5;
          shapeRESE.Left = 315;

          shapeESE.Height = 70;
          shapeESE.Width = 189;
          shapeRESE.Height = 70;
          shapeRESE.Width = 189;
          //worksheetResumen.PageSetup.PrintTitleColumns = "$A:$H";
          #region WorkSheetMes
          worksheet.Range["A1:H10000"].CellStyle.Font.FontName = "Arial";
          worksheet.Range["A1:H10000"].CellStyle.Font.Size = 11;
          worksheet.Range["A1:H10000"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
          worksheet.Range["A1:H10000"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;

          worksheet.Range["A1:H4"].Merge();
          worksheet.Range["A1:H8"].CellStyle.Font.Bold = true;
          worksheet.Range["A1:H4"].CellStyle.Color = Color.FromArgb(89, 193, 203);
          worksheet.Range["A5:H5"].CellStyle.Color = Color.FromArgb(243, 204, 157);
          worksheet.Range["A1:H8"].CellStyle.Font.RGBColor = Color.FromArgb(255, 255, 255);
          worksheet.Range["A5"].RowHeight = 6;
          worksheet.Range["A1"].Text = $"ESE CENTRO DE SALUD SAN PEDRO - CABRERA \n INFORME ESTADÍSTICO MENSUAL \n SERVICIO FARMACÉUTICO \n {fecha.ToString("MMMM").ToUpper()} DE {fecha.ToString("yyyy")}";

          worksheet.Range["A1:G1"].ColumnWidth = 13.57;
          worksheet.Range["H1"].ColumnWidth = 18.14;

          worksheet.Range["A7:C8"].Merge();
          worksheet.Range["D7:E8"].Merge();
          worksheet.Range["F7:G8"].Merge();
          worksheet.Range["H7:H8"].Merge();
          worksheet.Range["A7:A8"].RowHeight = 37;
          worksheet.Range["A7:H8"].CellStyle.Color = Color.FromArgb(89, 193, 203);
          worksheet.Range["A7:H8"].CellStyle.WrapText = true;
          worksheet.Range["A7"].Text = "CONCEPTO";
          worksheet.Range["D7"].Text = "N° FORMULAS DESPACHADAS";
          worksheet.Range["F7"].Text = "COSTO FORMULACIÓN";
          worksheet.Range["H7"].Text = "MEDICAMENTOS FORMULADOS";
          worksheet.Range["A7:H8"].CellStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range["A7:H8"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range["A7:C8"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range["H7:H8"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range["D7:G8"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range["D7:G8"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          DateTime fechaInicio = new DateTime(fecha.Year, fecha.Month, 1);
          DateTime fechaFinal = fechaInicio.AddMonths(1);
          var formulas = _context.Formulas
                                 .Include(x => x.Medico)
                                 .Include(x => x.Paciente)
                                 .Include(x => x.Servicio)
                                 .Include(x => x.DetalleFormula)
                                 .Include(x => x.Paciente.Eps).Where(x => x.FechaDespacho >= fechaInicio && x.FechaDespacho < fechaFinal).ToList();
          var medicos = formulas.Where(x => x.IdMedico.Trim().ToLower() != "otros").GroupBy(m => m.Medico, (key, g) => new { key = key, g = g }).ToList();
          int row = 9;
          int i = 0;
          foreach (var medico in medicos)
          {
            worksheet.Range[$"A{row}:C{row}"].Merge();
            worksheet.Range[$"D{row}:E{row}"].Merge();
            worksheet.Range[$"F{row}:G{row}"].Merge();
            worksheet.Range[$"A{row}"].Text = medico.key.Nombres;
            worksheet.Range[$"D{row}"].Number = medico.g.Count();
            worksheet.Range[$"F{row}"].Number = medico.g.Sum(x => x.TotalVenta);
            worksheet.Range[$"F{row}"].NumberFormat = "_($* #,##0_)";
            worksheet.Range[$"H{row}"].Number = medico.g.Sum(x =>
            {
              return _context.DetallesFormula.Where(d => d.IdFormula == x.Id).Sum(d => d.Cantidad);
            });
            if (i == medicos.Count() - 1)
              worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
            else
              worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
            worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
            worksheet.Range[$"D{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
            worksheet.Range[$"D{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
            worksheet.Range[$"A{row}:C{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
            worksheet.Range[$"H{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
            row++;
            i++;
          }
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Medium;
          var servicios = formulas.GroupBy(m => new { m.Paciente.Eps, m.Servicio }, (key, g) => new { eps = key.Eps, servicio = key.Servicio, g = g }).ToList();
          i = 0;
          foreach (var servicio in servicios)
          {
            worksheet.Range[$"A{row}:C{row}"].Merge();
            worksheet.Range[$"D{row}:E{row}"].Merge();
            worksheet.Range[$"F{row}:G{row}"].Merge();
            worksheet.Range[$"A{row}"].Text = servicio.servicio.Nombre + " " + servicio.eps.Nombre;
            worksheet.Range[$"D{row}"].Number = servicio.g.Count();
            worksheet.Range[$"F{row}"].Number = servicio.g.Sum(x => x.TotalCompra);
            worksheet.Range[$"F{row}"].NumberFormat = "_($* #,##0_)";
            worksheet.Range[$"H{row}"].Number = servicio.g.Sum(x =>
            {
              return _context.DetallesFormula.Where(d => d.IdFormula == x.Id).Sum(d => d.Cantidad);
            });
            if (i == servicios.Count() - 1)
              worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
            else
              worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
            worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
            worksheet.Range[$"D{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
            worksheet.Range[$"D{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
            worksheet.Range[$"A{row}:C{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
            worksheet.Range[$"H{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
            row++;
            i++;
          }
          worksheet.Range[$"A{row}:C{row}"].Merge();
          worksheet.Range[$"D{row}:E{row}"].Merge();
          worksheet.Range[$"F{row}:G{row}"].Merge();
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Color = Color.FromArgb(178, 223, 228);
          worksheet.Range[$"A{row}"].Text = "TOTAL";
          worksheet.Range[$"D{row}"].Number = formulas.Count();
          worksheet.Range[$"F{row}"].Number = formulas.Sum(x => x.TotalCompra);
          worksheet.Range[$"F{row}"].NumberFormat = "_($* #,##0_)";
          worksheet.Range[$"H{row}"].Number = formulas.Sum(x =>
          {
            return _context.DetallesFormula.Where(d => d.IdFormula == x.Id).Sum(d => d.Cantidad);
          });
          worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:C{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"H{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"D{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"D{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          row = row + 2;
          worksheet.Range[$"A{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Color = Color.FromArgb(89, 193, 203);
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Font.Bold = true;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Font.RGBColor = Color.FromArgb(255, 255, 255);
          worksheet.Range[$"A{row}"].Text = "INDICADORES FARMACÉUTICOS";
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:C{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"H{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          row++;
          worksheet.Range[$"A{row}:E{row}"].Merge();
          worksheet.Range[$"F{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}"].Text = "Total Medicamentos Pendientes";
          worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"F{row}"].Number = formulas.Sum(x => x.DetalleFormula.Sum(d => d.CantidadPendiente));
          row++;
          worksheet.Range[$"A{row}:E{row}"].Merge();
          worksheet.Range[$"F{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}"].Text = "Total Medicamentos Despachados en el Mes (Sin Incluir Gastos ni Ventas)";
          worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"F{row}"].Number = formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público")
                                                      .Sum(x => x.DetalleFormula.Sum(d => d.Cantidad));
          row++;
          worksheet.Range[$"A{row}:E{row}"].Merge();
          worksheet.Range[$"F{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}"].Text = "Promedio de Medicamentos por Formula";
          worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"F{row}"].Number = formulas.Sum(x => x.TotalMedicamentos) / formulas.Count();
          row++;
          worksheet.Range[$"A{row}:E{row}"].Merge();
          worksheet.Range[$"F{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}"].Text = "Cumplimiento de Entrega de Medicamentos";
          worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"F{row}"].Number = formulas.Sum(x => x.DetalleFormula.Sum(d => d.CantidadPendiente)) / formulas.Sum(x => x.DetalleFormula.Sum(d => d.CantidadFormula));
          worksheet.Range[$"F{row}"].NumberFormat = "0.00%";
          row = row + 2;
          worksheet.Range[$"A{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Color = Color.FromArgb(89, 193, 203);
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Font.Bold = true;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Font.RGBColor = Color.FromArgb(255, 255, 255);
          worksheet.Range[$"A{row}"].Text = "COSTO PROMEDIO FORMULA POR MEDICO";
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:C{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"H{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          row++;
          i = 0;
          foreach (var medico in medicos)
          {
            worksheet.Range[$"A{row}:E{row}"].Merge();
            worksheet.Range[$"F{row}:H{row}"].Merge();
            worksheet.Range[$"A{row}"].Text = medico.key.Nombres;
            worksheet.Range[$"F{row}"].Number = medico.g.Sum(x => x.TotalCompra) / medico.g.Count();
            worksheet.Range[$"F{row}"].NumberFormat = "_($* #,##0_)";
            if (i == medicos.Count() - 1)
              worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
            else
              worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
            worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
            worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
            worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
            worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
            row++;
            i++;
          }
          i = 0;
          foreach (var servicio in servicios)
          {
            worksheet.Range[$"A{row}:E{row}"].Merge();
            worksheet.Range[$"F{row}:H{row}"].Merge();
            worksheet.Range[$"A{row}"].Text = servicio.servicio.Nombre + " " + servicio.eps.Nombre;
            worksheet.Range[$"F{row}"].Number = servicio.g.Sum(x => x.TotalCompra) / servicio.g.Count();
            worksheet.Range[$"F{row}"].NumberFormat = "_($* #,##0_)";
            if (i == servicios.Count() - 1)
              worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
            else
              worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
            worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
            worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
            worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
            worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
            row++;
            i++;
          }
          worksheet.Range[$"A{row}:E{row}"].Merge();
          worksheet.Range[$"F{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}"].Text = "Valor Promedio de Formula";
          var totalFormula = formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público").Sum(x => x.TotalCompra);
          var cantidadFormulas = formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público").Count();
          worksheet.Range[$"F{row}"].Number = totalFormula / cantidadFormulas;
          worksheet.Range[$"F{row}"].NumberFormat = "_($* #,##0_)";
          row++;
          row++;
          worksheet.Range[$"A{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Color = Color.FromArgb(89, 193, 203);
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Font.Bold = true;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Font.RGBColor = Color.FromArgb(255, 255, 255);
          worksheet.Range[$"A{row}"].Text = "COSTOS Y MOVIMIENTOS DE MEDICAMENTOS";
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:C{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"H{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          row++;
          worksheet.Range[$"A{row}:E{row}"].Merge();
          worksheet.Range[$"F{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}"].Text = "Costo de Compras a Proveedores Durante el Mes";
          worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"F{row}"].Number = (double?)_context.Pedidos.Where(x => x.FechaIngreso >= fechaInicio && x.FechaIngreso < fechaFinal).Sum(x => x.VlrTotal) ?? 0;
          worksheet.Range[$"F{row}"].NumberFormat = "_($* #,##0_)";
          row++;
          worksheet.Range[$"A{row}:E{row}"].Merge();
          worksheet.Range[$"F{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}"].Text = "Costo Total Formulación Durante el Mes";
          worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"F{row}"].Number = formulas.Sum(x => x.TotalCompra);
          worksheet.Range[$"F{row}"].NumberFormat = "_($* #,##0_)";
          row++;
          worksheet.Range[$"A{row}:E{row}"].Merge();
          worksheet.Range[$"F{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}"].Text = "Valor Actual del Inventario al Último Día del Mes";
          worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"F{row}"].Number = _context.InventariosFinMes.Where(x => x.Fecha.Year == fechaInicio.Year && x.Fecha.Month == fechaInicio.Month)
                                                      .Sum(x => (double?)x.Cantidad * x.ValorCompra) ?? 0.0;
          worksheet.Range[$"F{row}"].NumberFormat = "_($* #,##0_)";
          row++;
          worksheet.Range[$"A{row}:E{row}"].Merge();
          worksheet.Range[$"F{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}"].Text = "Valor Consumo Mensual Promedio de Medicamentos";
          worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          DateTime sixMon = fechaInicio.AddMonths(-5);
          var formulasSixMon = _context.Formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" && x.FechaDespacho >= sixMon && x.FechaDespacho < fechaFinal).ToList();
          worksheet.Range[$"F{row}"].Number = formulasSixMon.Sum(x => (double?)x.TotalCompra) ?? 0 / 6;
          worksheet.Range[$"F{row}"].NumberFormat = "_($* #,##0_)";
          row++;
          worksheet.Range[$"A{row}:E{row}"].Merge();
          worksheet.Range[$"F{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}"].Text = "Gastos Servicios";
          worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"F{row}"].Number = _context.Formulas.Include(x => x.Servicio)
                                                      .Where(x => x.Servicio.Nombre.Trim().ToLower() == "gastos servicios" &&
                                                      x.FechaDespacho >= fechaInicio && x.FechaDespacho < fechaFinal).Sum(x => (double?)x.TotalCompra) ?? 0;
          worksheet.Range[$"F{row}"].NumberFormat = "_($* #,##0_)";
          row++;

          worksheet.Range[$"A{row}:E{row}"].Merge();
          worksheet.Range[$"F{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}"].Text = "Costos de Venta";
          worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"F{row}"].Number = _context.Formulas.Include(x => x.Servicio)
                                                      .Where(x => x.Servicio.Nombre.Trim().ToLower() == "venta al público" &&
                                                      x.FechaDespacho >= fechaInicio && x.FechaDespacho < fechaFinal).Sum(x => (double?)x.TotalCompra) ?? 0;
          worksheet.Range[$"F{row}"].NumberFormat = "_($* #,##0_)";
          row++;
          worksheet.Range[$"A{row}:E{row}"].Merge();
          worksheet.Range[$"F{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}"].Text = "Valor Ventas";
          worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"F{row}"].Number = _context.Formulas.Include(x => x.Servicio)
                                                      .Where(x => x.Servicio.Nombre.Trim().ToLower() == "venta al público" &&
                                                      x.FechaDespacho >= fechaInicio && x.FechaDespacho < fechaFinal).Sum(x => (double?)x.TotalVenta) ?? 0;
          worksheet.Range[$"F{row}"].NumberFormat = "_($* #,##0_)";
          row++;
          worksheet.Range[$"A{row}:E{row}"].Merge();
          worksheet.Range[$"F{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}"].Text = "Medicamentos Vencidos al Mes";
          worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"F{row}"].Number = _context.MedicamentosVendicos.Where(x => x.FechaRegistro >= fechaInicio && x.FechaRegistro < fechaFinal).Sum(x => (double?)x.ValorCompra * x.Cantidad) ?? 0;
          worksheet.Range[$"F{row}"].NumberFormat = "_($* #,##0_)";
          row++;
          worksheet.Range[$"A{row}:E{row}"].Merge();
          worksheet.Range[$"F{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}"].Text = "Costo Total Medicamentos Dispensados, Gastados y Vendidos";
          worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"F{row}"].Number = formulas.Sum(x => x.TotalCompra);
          worksheet.Range[$"F{row}"].NumberFormat = "_($* #,##0_)";
          row = row + 2;

          worksheet.Range[$"A{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Color = Color.FromArgb(89, 193, 203);
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Font.Bold = true;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Font.RGBColor = Color.FromArgb(255, 255, 255);
          worksheet.Range[$"A{row}"].Text = "INFORME ARQUEO DE INVENTARIO";
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:C{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"H{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          row++;

          var arqueo = _context.Arqueos.Where(x => x.FechaArqueo >= fechaInicio && x.FechaArqueo < fechaFinal).ToList();

          worksheet.Range[$"A{row}:E{row}"].Merge();
          worksheet.Range[$"F{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}"].Text = "Total Medicamentos Ajustados";
          worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          var medicamentosAjustados = arqueo.Where(x => x.CantidadSistema != x.CantidadFisica).Count();
          worksheet.Range[$"F{row}"].Number = medicamentosAjustados;
          row++;
          worksheet.Range[$"A{row}:E{row}"].Merge();
          worksheet.Range[$"F{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}"].Text = "Total Medicamentos Contados";
          worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          var medicamentosContados = arqueo.Count();
          worksheet.Range[$"F{row}"].Number = medicamentosContados;
          row++;
          worksheet.Range[$"A{row}:E{row}"].Merge();
          worksheet.Range[$"F{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}"].Text = "Confiabilidad del Inventario por Medicamentos";
          worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          var confiabilidadInventario = medicamentosContados == 0 ? 0 : 100 - ((medicamentosAjustados * 100) / medicamentosContados);
          worksheet.Range[$"F{row}"].Number = confiabilidadInventario;
          worksheet.Range[$"F{row}"].NumberFormat = "0.00%";
          row++;
          worksheet.Range[$"A{row}:E{row}"].Merge();
          worksheet.Range[$"F{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}"].Text = "Total Unidades Ajustadas";
          worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          var unidadesAjustadas = arqueo.Sum(x => Math.Abs(x.CantidadFisica - x.CantidadSistema));
          worksheet.Range[$"F{row}"].Number = unidadesAjustadas;
          row++;
          worksheet.Range[$"A{row}:E{row}"].Merge();
          worksheet.Range[$"F{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}"].Text = "Total Unidades Contadas";
          worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          var unidadesContadas = arqueo.Sum(x => x.CantidadFisica);
          worksheet.Range[$"F{row}"].Number = unidadesContadas;
          row++;
          worksheet.Range[$"A{row}:E{row}"].Merge();
          worksheet.Range[$"F{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}"].Text = "Confiabilidad del Inventario por Unidades";
          worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          var confiabilidadUnidades = unidadesContadas == 0 ? 0 : 100 - ((unidadesAjustadas * 100) / unidadesContadas);
          worksheet.Range[$"F{row}"].Number = confiabilidadUnidades;
          worksheet.Range[$"F{row}"].NumberFormat = "0.00%";
          row++;
          worksheet.Range[$"A{row}:E{row}"].Merge();
          worksheet.Range[$"F{row}:H{row}"].Merge();
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"A{row}:E{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A{row}"].Text = "Promedio de Confiabilidad del Inventario";
          worksheet.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheet.Range[$"F{row}:H{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheet.Range[$"F{row}"].Number = (confiabilidadUnidades + confiabilidadInventario) / 2;
          worksheet.Range[$"F{row}"].NumberFormat = "0.00%";

          worksheet.PageSetup.PrintArea = $"$A$1:$H${row}";
          worksheet.PageSetup.Orientation = ExcelPageOrientation.Portrait;
          worksheet.PageSetup.FitToPagesWide = 1;
          worksheet.PageSetup.PaperSize = ExcelPaperSize.PaperLetter;
          worksheet.View = SheetView.PageBreakPreview;
          #endregion

          #region WorkSheetResumen
          worksheetRes.Range["A1:G10000"].CellStyle.Font.FontName = "Arial";
          worksheetRes.Range["A1:G10000"].CellStyle.Font.Size = 11;
          worksheetRes.Range["A1:G10000"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
          worksheetRes.Range["A1:G10000"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;

          worksheetRes.Range["A1:G4"].Merge();
          worksheetRes.Range["A1:G7"].CellStyle.Font.Bold = true;
          worksheetRes.Range["A1:G4"].CellStyle.Color = Color.FromArgb(89, 193, 203);
          worksheetRes.Range["A5:G5"].CellStyle.Color = Color.FromArgb(243, 204, 157);
          worksheetRes.Range["A1:G7"].CellStyle.Font.RGBColor = Color.FromArgb(255, 255, 255);
          worksheetRes.Range["A5"].RowHeight = 6;
          worksheetRes.Range["A1"].Text = $"ESE CENTRO DE SALUD SAN PEDRO - CABRERA \n INFORME ESTADÍSTICO MENSUAL \n SERVICIO FARMACÉUTICO \n {fecha.ToString("MMMM").ToUpper()} DE {fecha.ToString("yyyy")}";

          worksheetRes.Range["A1"].ColumnWidth = 50;
          worksheetRes.Range["B1:G1"].ColumnWidth = 14.14;

          worksheetRes.Range["A7:G7"].CellStyle.Color = Color.FromArgb(89, 193, 203);
          worksheetRes.Range["A7:G7"].CellStyle.WrapText = true;
          worksheetRes.Range["A7"].Text = "DATOS";
          DateTime dMes5 = fechaInicio.AddMonths(-5);
          DateTime dMes4 = fechaInicio.AddMonths(-4);
          DateTime dMes3 = fechaInicio.AddMonths(-3);
          DateTime dMes2 = fechaInicio.AddMonths(-2);
          DateTime dMes1 = fechaInicio.AddMonths(-1);
          worksheetRes.Range["B7"].Text = dMes5.ToString("MMMM").ToUpper();
          worksheetRes.Range["C7"].Text = dMes4.ToString("MMMM").ToUpper();
          worksheetRes.Range["D7"].Text = dMes3.ToString("MMMM").ToUpper();
          worksheetRes.Range["E7"].Text = dMes2.ToString("MMMM").ToUpper();
          worksheetRes.Range["F7"].Text = dMes1.ToString("MMMM").ToUpper();
          worksheetRes.Range["G7"].Text = fecha.ToString("MMMM").ToUpper();
          worksheetRes.Range["A7:G7"].CellStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range["A7:G7"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range["A7"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range["G7"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range["B7:F8"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
          worksheetRes.Range["B7:F8"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          formulas = _context.Formulas
                                 .Include(x => x.Medico)
                                 .Include(x => x.Paciente)
                                 .Include(x => x.Servicio)
                                 .Include(x => x.DetalleFormula)
                                 .Include(x => x.Paciente.Eps).Where(x => x.FechaDespacho >= dMes5 && x.FechaDespacho < fechaFinal).ToList();
          medicos = formulas.Where(x => x.IdMedico.Trim().ToLower() != "otros").GroupBy(m => m.Medico, (key, g) => new { key = key, g = g }).ToList();
          row = 8;
          i = 0;
          int iDatosChar1 = row;
          int fDatosChar1 = 0;
          foreach (var medico in medicos)
          {
            worksheetRes.Range[$"A{row}"].Text = medico.key.Nombres;
            var mes5 = medico.g.Where(x => x.FechaDespacho.Year == dMes5.Year && x.FechaDespacho.Month == dMes5.Month).ToList();
            worksheetRes.Range[$"B{row}"].Number = mes5.Count() == 0 ? 0 : (mes5.Sum(x => x.TotalCompra) / mes5.Count());
            worksheetRes.Range[$"B{row}"].NumberFormat = "_($* #,##0_)";
            var mes4 = medico.g.Where(x => x.FechaDespacho.Year == dMes4.Year && x.FechaDespacho.Month == dMes4.Month).ToList();
            worksheetRes.Range[$"C{row}"].Number = mes4.Count() == 0 ? 0 : (mes4.Sum(x => x.TotalCompra) / mes4.Count());
            worksheetRes.Range[$"C{row}"].NumberFormat = "_($* #,##0_)";
            var mes3 = medico.g.Where(x => x.FechaDespacho.Year == dMes3.Year && x.FechaDespacho.Month == dMes3.Month).ToList();
            worksheetRes.Range[$"D{row}"].Number = mes3.Count() == 0 ? 0 : (mes3.Sum(x => x.TotalCompra) / mes3.Count());
            worksheetRes.Range[$"D{row}"].NumberFormat = "_($* #,##0_)";
            var mes2 = medico.g.Where(x => x.FechaDespacho.Year == dMes2.Year && x.FechaDespacho.Month == dMes2.Month).ToList();
            worksheetRes.Range[$"E{row}"].Number = mes2.Count() == 0 ? 0 : (mes2.Sum(x => x.TotalCompra) / mes2.Count());
            worksheetRes.Range[$"E{row}"].NumberFormat = "_($* #,##0_)";
            var mes1 = medico.g.Where(x => x.FechaDespacho.Year == dMes1.Year && x.FechaDespacho.Month == dMes1.Month).ToList();
            worksheetRes.Range[$"F{row}"].Number = mes1.Count() == 0 ? 0 : (mes1.Sum(x => x.TotalCompra) / mes1.Count());
            worksheetRes.Range[$"F{row}"].NumberFormat = "_($* #,##0_)";
            var mesA = medico.g.Where(x => x.FechaDespacho.Year == fechaInicio.Year && x.FechaDespacho.Month == fechaInicio.Month).ToList();
            worksheetRes.Range[$"G{row}"].Number = mesA.Count() == 0 ? 0 : (mesA.Sum(x => x.TotalCompra) / mesA.Count());
            worksheetRes.Range[$"G{row}"].NumberFormat = "_($* #,##0_)";
            if (i == medicos.Count() - 1)
            {
              worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
              fDatosChar1 = row;
            }
            else
              worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
            worksheetRes.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
            worksheetRes.Range[$"B{row}:F{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
            worksheetRes.Range[$"B{row}:F{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
            worksheetRes.Range[$"A{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
            worksheetRes.Range[$"G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
            row++;
            i++;
          }
          row++;
          worksheetRes.Range[$"A{row}:G{row}"].Merge();
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}"].Text = "FORMULAS POR CONVENIO Y POR SERVICIO";
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Font.Bold = true;
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Color = Color.FromArgb(89, 193, 203);
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Font.RGBColor = Color.FromArgb(255, 255, 255);
          servicios = formulas.GroupBy(m => new { m.Paciente.Eps, m.Servicio }, (key, g) => new { eps = key.Eps, servicio = key.Servicio, g = g }).ToList();
          i = 0;
          row++;
          int iDatosChar8 = row;
          int fDatosChar8 = 0;
          foreach (var servicio in servicios)
          {
            worksheetRes.Range[$"A{row}"].Text = servicio.servicio.Nombre + " " + servicio.eps.Nombre;
            var mes5 = servicio.g.Where(x => x.FechaDespacho.Year == dMes5.Year && x.FechaDespacho.Month == dMes5.Month).ToList();
            worksheetRes.Range[$"B{row}"].Number = mes5.Count();
            var mes4 = servicio.g.Where(x => x.FechaDespacho.Year == dMes4.Year && x.FechaDespacho.Month == dMes4.Month).ToList();
            worksheetRes.Range[$"C{row}"].Number = mes4.Count();
            var mes3 = servicio.g.Where(x => x.FechaDespacho.Year == dMes3.Year && x.FechaDespacho.Month == dMes3.Month).ToList();
            worksheetRes.Range[$"D{row}"].Number = mes3.Count();
            var mes2 = servicio.g.Where(x => x.FechaDespacho.Year == dMes2.Year && x.FechaDespacho.Month == dMes2.Month).ToList();
            worksheetRes.Range[$"E{row}"].Number = mes2.Count();
            var mes1 = servicio.g.Where(x => x.FechaDespacho.Year == dMes1.Year && x.FechaDespacho.Month == dMes1.Month).ToList();
            worksheetRes.Range[$"F{row}"].Number = mes1.Count();
            var mesA = servicio.g.Where(x => x.FechaDespacho.Year == fechaInicio.Year && x.FechaDespacho.Month == fechaInicio.Month).ToList();
            worksheetRes.Range[$"G{row}"].Number = mesA.Count();
            if (i == servicios.Count() - 1)
            {
              worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
              fDatosChar8 = row;
            }
            else
              worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
            worksheetRes.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
            worksheetRes.Range[$"B{row}:F{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
            worksheetRes.Range[$"B{row}:F{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
            worksheetRes.Range[$"A{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
            worksheetRes.Range[$"G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
            row++;
            i++;
          }
          row++;
          worksheetRes.Range[$"A{row}:G{row}"].Merge();
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}"].Text = "COSTOS Y MOVIMIENTOS DE MEDICAMENTOS";
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Font.Bold = true;
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Color = Color.FromArgb(89, 193, 203);
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Font.RGBColor = Color.FromArgb(255, 255, 255);
          row++;
          worksheetRes.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheetRes.Range[$"A{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheetRes.Range[$"B{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
          worksheetRes.Range[$"G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}"].Text = "Total Formulas Despachadas";
          int datosChart4 = row;
          worksheetRes.Range[$"B{row}"].Number = formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" && x.FechaDespacho.Year == dMes5.Year && x.FechaDespacho.Month == dMes5.Month).Count();
          worksheetRes.Range[$"C{row}"].Number = formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" && x.FechaDespacho.Year == dMes4.Year && x.FechaDespacho.Month == dMes4.Month).Count();
          worksheetRes.Range[$"D{row}"].Number = formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" && x.FechaDespacho.Year == dMes3.Year && x.FechaDespacho.Month == dMes3.Month).Count();
          worksheetRes.Range[$"E{row}"].Number = formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" && x.FechaDespacho.Year == dMes2.Year && x.FechaDespacho.Month == dMes2.Month).Count();
          worksheetRes.Range[$"F{row}"].Number = formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" && x.FechaDespacho.Year == dMes1.Year && x.FechaDespacho.Month == dMes1.Month).Count();
          worksheetRes.Range[$"G{row}"].Number = formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" && x.FechaDespacho.Year == fechaInicio.Year && x.FechaDespacho.Month == fechaInicio.Month).Count();
          row++;
          worksheetRes.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheetRes.Range[$"A{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheetRes.Range[$"B{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
          worksheetRes.Range[$"G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}"].Text = "Total Medicamentos Pendientes";
          worksheetRes.Range[$"B{row}"].Number = formulas.Where(x => x.FechaDespacho.Year == dMes5.Year && x.FechaDespacho.Month == dMes5.Month).Sum(x => x.DetalleFormula.Sum(y => y.CantidadPendiente));
          worksheetRes.Range[$"C{row}"].Number = formulas.Where(x => x.FechaDespacho.Year == dMes4.Year && x.FechaDespacho.Month == dMes4.Month).Sum(x => x.DetalleFormula.Sum(y => y.CantidadPendiente));
          worksheetRes.Range[$"D{row}"].Number = formulas.Where(x => x.FechaDespacho.Year == dMes3.Year && x.FechaDespacho.Month == dMes3.Month).Sum(x => x.DetalleFormula.Sum(y => y.CantidadPendiente));
          worksheetRes.Range[$"E{row}"].Number = formulas.Where(x => x.FechaDespacho.Year == dMes2.Year && x.FechaDespacho.Month == dMes2.Month).Sum(x => x.DetalleFormula.Sum(y => y.CantidadPendiente));
          worksheetRes.Range[$"F{row}"].Number = formulas.Where(x => x.FechaDespacho.Year == dMes1.Year && x.FechaDespacho.Month == dMes1.Month).Sum(x => x.DetalleFormula.Sum(y => y.CantidadPendiente));
          worksheetRes.Range[$"G{row}"].Number = formulas.Where(x => x.FechaDespacho.Year == fechaInicio.Year && x.FechaDespacho.Month == fechaInicio.Month).Sum(x => x.DetalleFormula.Sum(y => y.CantidadPendiente));
          row++;
          worksheetRes.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheetRes.Range[$"A{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheetRes.Range[$"B{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
          worksheetRes.Range[$"G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}"].Text = "Promedio Costo Formulación";
          int datosChar2 = row;
          var totalFormulaM5 = formulas.Where(x => x.FechaDespacho.Year == dMes5.Year && x.FechaDespacho.Month == dMes5.Month && x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público").Sum(x => x.TotalCompra);
          var cantidadFormulasM5 = formulas.Where(x => x.FechaDespacho.Year == dMes5.Year && x.FechaDespacho.Month == dMes5.Month && x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público").Count();
          worksheetRes.Range[$"B{row}"].Number = cantidadFormulasM5 == 0 ? 0 : totalFormulaM5 / cantidadFormulasM5;
          worksheetRes.Range[$"B{row}"].NumberFormat = "_($* #,##0_)";
          var totalFormulaM4 = formulas.Where(x => x.FechaDespacho.Year == dMes4.Year && x.FechaDespacho.Month == dMes4.Month && x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público").Sum(x => x.TotalCompra);
          var cantidadFormulasM4 = formulas.Where(x => x.FechaDespacho.Year == dMes4.Year && x.FechaDespacho.Month == dMes4.Month && x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público").Count();
          worksheetRes.Range[$"C{row}"].Number = cantidadFormulasM4 == 0 ? 0 : totalFormulaM4 / cantidadFormulasM4;
          worksheetRes.Range[$"C{row}"].NumberFormat = "_($* #,##0_)";
          var totalFormulaM3 = formulas.Where(x => x.FechaDespacho.Year == dMes3.Year && x.FechaDespacho.Month == dMes3.Month && x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público").Sum(x => x.TotalCompra);
          var cantidadFormulasM3 = formulas.Where(x => x.FechaDespacho.Year == dMes3.Year && x.FechaDespacho.Month == dMes3.Month && x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público").Count();
          worksheetRes.Range[$"D{row}"].Number = cantidadFormulasM3 == 0 ? 0 : totalFormulaM3 / cantidadFormulasM3;
          worksheetRes.Range[$"D{row}"].NumberFormat = "_($* #,##0_)";
          var totalFormulaM2 = formulas.Where(x => x.FechaDespacho.Year == dMes2.Year && x.FechaDespacho.Month == dMes2.Month && x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público").Sum(x => x.TotalCompra);
          var cantidadFormulasM2 = formulas.Where(x => x.FechaDespacho.Year == dMes2.Year && x.FechaDespacho.Month == dMes2.Month && x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público").Count();
          worksheetRes.Range[$"E{row}"].Number = cantidadFormulasM2 == 0 ? 0 : totalFormulaM2 / cantidadFormulasM2;
          worksheetRes.Range[$"E{row}"].NumberFormat = "_($* #,##0_)";
          var totalFormulaM1 = formulas.Where(x => x.FechaDespacho.Year == dMes1.Year && x.FechaDespacho.Month == dMes1.Month && x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público").Sum(x => x.TotalCompra);
          var cantidadFormulasM1 = formulas.Where(x => x.FechaDespacho.Year == dMes1.Year && x.FechaDespacho.Month == dMes1.Month && x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público").Count();
          worksheetRes.Range[$"F{row}"].Number = cantidadFormulasM1 == 0 ? 0 : totalFormulaM1 / cantidadFormulasM1;
          worksheetRes.Range[$"F{row}"].NumberFormat = "_($* #,##0_)";
          var totalFormulaMA = formulas.Where(x => x.FechaDespacho.Year == fechaInicio.Year && x.FechaDespacho.Month == fechaInicio.Month && x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público").Sum(x => x.TotalCompra);
          var cantidadFormulasMA = formulas.Where(x => x.FechaDespacho.Year == fechaInicio.Year && x.FechaDespacho.Month == fechaInicio.Month && x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público").Count();
          worksheetRes.Range[$"G{row}"].Number = cantidadFormulasMA == 0 ? 0 : totalFormulaMA / cantidadFormulasMA;
          worksheetRes.Range[$"G{row}"].NumberFormat = "_($* #,##0_)";
          row++;
          worksheetRes.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheetRes.Range[$"A{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheetRes.Range[$"B{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
          worksheetRes.Range[$"G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}"].Text = "Total Medicamentos Formulados";
          int datosChart3 = row;
          worksheetRes.Range[$"B{row}"].Number = formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" &&
                                                        x.FechaDespacho.Year == dMes5.Year && x.FechaDespacho.Month == dMes5.Month).Sum(x => x.DetalleFormula.Sum(d => d.Cantidad));
          worksheetRes.Range[$"C{row}"].Number = formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" &&
                                                        x.FechaDespacho.Year == dMes4.Year && x.FechaDespacho.Month == dMes4.Month).Sum(x => x.DetalleFormula.Sum(d => d.Cantidad));
          worksheetRes.Range[$"D{row}"].Number = formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" &&
                                                        x.FechaDespacho.Year == dMes3.Year && x.FechaDespacho.Month == dMes3.Month).Sum(x => x.DetalleFormula.Sum(d => d.Cantidad));
          worksheetRes.Range[$"E{row}"].Number = formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" &&
                                                        x.FechaDespacho.Year == dMes2.Year && x.FechaDespacho.Month == dMes2.Month).Sum(x => x.DetalleFormula.Sum(d => d.Cantidad));
          worksheetRes.Range[$"F{row}"].Number = formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" &&
                                                        x.FechaDespacho.Year == dMes1.Year && x.FechaDespacho.Month == dMes1.Month).Sum(x => x.DetalleFormula.Sum(d => d.Cantidad));
          worksheetRes.Range[$"G{row}"].Number = formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" &&
                                                        x.FechaDespacho.Year == fechaInicio.Year && x.FechaDespacho.Month == fechaInicio.Month).Sum(x => x.DetalleFormula.Sum(d => d.Cantidad));
          row++;
          worksheetRes.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheetRes.Range[$"A{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheetRes.Range[$"B{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
          worksheetRes.Range[$"G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}"].Text = "Total Valor Inventario";
          int datosChart5 = row;
          worksheetRes.Range[$"B{row}"].Number = _context.InventariosFinMes.Where(x => x.Fecha.Year == dMes5.Year && x.Fecha.Month == dMes5.Month)
                                                      .Sum(x => (double?)x.Cantidad * x.ValorCompra) ?? 0.0;
          worksheetRes.Range[$"B{row}"].NumberFormat = "_($* #,##0_)";
          worksheetRes.Range[$"C{row}"].Number = _context.InventariosFinMes.Where(x => x.Fecha.Year == dMes4.Year && x.Fecha.Month == dMes4.Month)
                                                      .Sum(x => (double?)x.Cantidad * x.ValorCompra) ?? 0.0;
          worksheetRes.Range[$"C{row}"].NumberFormat = "_($* #,##0_)";
          worksheetRes.Range[$"D{row}"].Number = _context.InventariosFinMes.Where(x => x.Fecha.Year == dMes3.Year && x.Fecha.Month == dMes3.Month)
                                                      .Sum(x => (double?)x.Cantidad * x.ValorCompra) ?? 0.0;
          worksheetRes.Range[$"D{row}"].NumberFormat = "_($* #,##0_)";
          worksheetRes.Range[$"E{row}"].Number = _context.InventariosFinMes.Where(x => x.Fecha.Year == dMes2.Year && x.Fecha.Month == dMes2.Month)
                                                      .Sum(x => (double?)x.Cantidad * x.ValorCompra) ?? 0.0;
          worksheetRes.Range[$"E{row}"].NumberFormat = "_($* #,##0_)";
          worksheetRes.Range[$"F{row}"].Number = _context.InventariosFinMes.Where(x => x.Fecha.Year == dMes1.Year && x.Fecha.Month == dMes1.Month)
                                                      .Sum(x => (double?)x.Cantidad * x.ValorCompra) ?? 0.0;
          worksheetRes.Range[$"F{row}"].NumberFormat = "_($* #,##0_)";
          worksheetRes.Range[$"G{row}"].Number = _context.InventariosFinMes.Where(x => x.Fecha.Year == fechaInicio.Year && x.Fecha.Month == fechaInicio.Month)
                                                      .Sum(x => (double?)x.Cantidad * x.ValorCompra) ?? 0.0;
          worksheetRes.Range[$"G{row}"].NumberFormat = "_($* #,##0_)";
          row++;
          worksheetRes.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheetRes.Range[$"A{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheetRes.Range[$"B{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
          worksheetRes.Range[$"G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}"].Text = "Promedio Formulas Diarias";
          worksheetRes.Range[$"B{row}"].Number = formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" && x.FechaDespacho.Year == dMes5.Year && x.FechaDespacho.Month == dMes5.Month).Count() / 21;
          worksheetRes.Range[$"C{row}"].Number = formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" && x.FechaDespacho.Year == dMes4.Year && x.FechaDespacho.Month == dMes4.Month).Count() / 21;
          worksheetRes.Range[$"D{row}"].Number = formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" && x.FechaDespacho.Year == dMes3.Year && x.FechaDespacho.Month == dMes3.Month).Count() / 21;
          worksheetRes.Range[$"E{row}"].Number = formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" && x.FechaDespacho.Year == dMes2.Year && x.FechaDespacho.Month == dMes2.Month).Count() / 21;
          worksheetRes.Range[$"F{row}"].Number = formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" && x.FechaDespacho.Year == dMes1.Year && x.FechaDespacho.Month == dMes1.Month).Count() / 21;
          worksheetRes.Range[$"G{row}"].Number = formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" && x.FechaDespacho.Year == fechaInicio.Year && x.FechaDespacho.Month == fechaInicio.Month).Count() / 21;
          row++;
          worksheetRes.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheetRes.Range[$"A{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheetRes.Range[$"B{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
          worksheetRes.Range[$"G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}"].Text = "Compras a Proveedores";
          int datosChart6 = row;
          worksheetRes.Range[$"B{row}"].Number = _context.Pedidos.Where(x => x.FechaIngreso.Year == dMes5.Year && x.FechaIngreso.Month == dMes5.Month).Sum(x => (double?)x.VlrTotal) ?? 0;
          worksheetRes.Range[$"B{row}"].NumberFormat = "_($* #,##0_)";
          worksheetRes.Range[$"C{row}"].Number = _context.Pedidos.Where(x => x.FechaIngreso.Year == dMes4.Year && x.FechaIngreso.Month == dMes4.Month).Sum(x => (double?)x.VlrTotal) ?? 0;
          worksheetRes.Range[$"C{row}"].NumberFormat = "_($* #,##0_)";
          worksheetRes.Range[$"D{row}"].Number = _context.Pedidos.Where(x => x.FechaIngreso.Year == dMes3.Year && x.FechaIngreso.Month == dMes3.Month).Sum(x => (double?)x.VlrTotal) ?? 0;
          worksheetRes.Range[$"D{row}"].NumberFormat = "_($* #,##0_)";
          worksheetRes.Range[$"E{row}"].Number = _context.Pedidos.Where(x => x.FechaIngreso.Year == dMes2.Year && x.FechaIngreso.Month == dMes2.Month).Sum(x => (double?)x.VlrTotal) ?? 0;
          worksheetRes.Range[$"E{row}"].NumberFormat = "_($* #,##0_)";
          worksheetRes.Range[$"F{row}"].Number = _context.Pedidos.Where(x => x.FechaIngreso.Year == dMes1.Year && x.FechaIngreso.Month == dMes1.Month).Sum(x => (double?)x.VlrTotal) ?? 0;
          worksheetRes.Range[$"F{row}"].NumberFormat = "_($* #,##0_)";
          worksheetRes.Range[$"G{row}"].Number = _context.Pedidos.Where(x => x.FechaIngreso.Year == fechaInicio.Year && x.FechaIngreso.Month == fechaInicio.Month).Sum(x => (double?)x.VlrTotal) ?? 0;
          worksheetRes.Range[$"G{row}"].NumberFormat = "_($* #,##0_)";
          row++;
          worksheetRes.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheetRes.Range[$"A{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheetRes.Range[$"B{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
          worksheetRes.Range[$"G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}"].Text = "Vencimiento de Medicamentos";
          int datosChart7 = row;
          worksheetRes.Range[$"B{row}"].Number = _context.MedicamentosVendicos.Where(x => x.FechaRegistro.Year == dMes5.Year && x.FechaRegistro.Month == dMes5.Month).Sum(x => (double?)x.ValorCompra * x.Cantidad) ?? 0;
          worksheetRes.Range[$"B{row}"].NumberFormat = "_($* #,##0_)";
          worksheetRes.Range[$"C{row}"].Number = _context.MedicamentosVendicos.Where(x => x.FechaRegistro.Year == dMes4.Year && x.FechaRegistro.Month == dMes4.Month).Sum(x => (double?)x.ValorCompra * x.Cantidad) ?? 0;
          worksheetRes.Range[$"C{row}"].NumberFormat = "_($* #,##0_)";
          worksheetRes.Range[$"D{row}"].Number = _context.MedicamentosVendicos.Where(x => x.FechaRegistro.Year == dMes3.Year && x.FechaRegistro.Month == dMes3.Month).Sum(x => (double?)x.ValorCompra * x.Cantidad) ?? 0;
          worksheetRes.Range[$"D{row}"].NumberFormat = "_($* #,##0_)";
          worksheetRes.Range[$"E{row}"].Number = _context.MedicamentosVendicos.Where(x => x.FechaRegistro.Year == dMes2.Year && x.FechaRegistro.Month == dMes2.Month).Sum(x => (double?)x.ValorCompra * x.Cantidad) ?? 0;
          worksheetRes.Range[$"E{row}"].NumberFormat = "_($* #,##0_)";
          worksheetRes.Range[$"F{row}"].Number = _context.MedicamentosVendicos.Where(x => x.FechaRegistro.Year == dMes1.Year && x.FechaRegistro.Month == dMes1.Month).Sum(x => (double?)x.ValorCompra * x.Cantidad) ?? 0;
          worksheetRes.Range[$"F{row}"].NumberFormat = "_($* #,##0_)";
          worksheetRes.Range[$"G{row}"].Number = _context.MedicamentosVendicos.Where(x => x.FechaRegistro.Year == fechaInicio.Year && x.FechaRegistro.Month == fechaInicio.Month).Sum(x => (double?)x.ValorCompra * x.Cantidad) ?? 0;
          worksheetRes.Range[$"G{row}"].NumberFormat = "_($* #,##0_)";
          row++;
          worksheetRes.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          worksheetRes.Range[$"A{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"B{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
          worksheetRes.Range[$"G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}"].Text = "Promedio Mensual Entrega Medicamentos";
          DateTime sixMon5 = dMes5.AddMonths(-5);
          DateTime finalM5 = dMes5.AddMonths(1);
          var formulasSixMon5 = _context.Formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" && x.FechaDespacho >= sixMon5 && x.FechaDespacho < finalM5).ToList();
          worksheetRes.Range[$"B{row}"].Number = formulasSixMon5.Sum(x => (double?)x.TotalCompra) ?? 0 / 6;
          worksheetRes.Range[$"B{row}"].NumberFormat = "_($* #,##0_)";
          DateTime sixMon4 = dMes4.AddMonths(-5);
          DateTime finalM4 = dMes4.AddMonths(1);
          var formulasSixMon4 = _context.Formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" && x.FechaDespacho >= sixMon4 && x.FechaDespacho < finalM4).ToList();
          worksheetRes.Range[$"C{row}"].Number = formulasSixMon4.Sum(x => (double?)x.TotalCompra) ?? 0 / 6;
          worksheetRes.Range[$"C{row}"].NumberFormat = "_($* #,##0_)";
          DateTime sixMon3 = dMes3.AddMonths(-5);
          DateTime finalM3 = dMes3.AddMonths(1);
          var formulasSixMon3 = _context.Formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" && x.FechaDespacho >= sixMon3 && x.FechaDespacho < finalM3).ToList();
          worksheetRes.Range[$"D{row}"].Number = formulasSixMon3.Sum(x => (double?)x.TotalCompra) ?? 0 / 6;
          worksheetRes.Range[$"D{row}"].NumberFormat = "_($* #,##0_)";
          DateTime sixMon2 = dMes2.AddMonths(-5);
          DateTime finalM2 = dMes2.AddMonths(1);
          var formulasSixMon2 = _context.Formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" && x.FechaDespacho >= sixMon2 && x.FechaDespacho < finalM2).ToList();
          worksheetRes.Range[$"E{row}"].Number = formulasSixMon2.Sum(x => (double?)x.TotalCompra) ?? 0 / 6;
          worksheetRes.Range[$"E{row}"].NumberFormat = "_($* #,##0_)";
          DateTime sixMon1 = dMes1.AddMonths(-5);
          DateTime finalM1 = dMes1.AddMonths(1);
          var formulasSixMon1 = _context.Formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al público" && x.FechaDespacho >= sixMon1 && x.FechaDespacho < finalM1).ToList();
          worksheetRes.Range[$"F{row}"].Number = formulasSixMon1.Sum(x => (double?)x.TotalCompra) ?? 0 / 6;
          worksheetRes.Range[$"F{row}"].NumberFormat = "_($* #,##0_)";
          worksheetRes.Range[$"G{row}"].Number = formulasSixMon.Sum(x => (double?)x.TotalCompra) ?? 0 / 6;
          worksheetRes.Range[$"G{row}"].NumberFormat = "_($* #,##0_)";
          row++;
          worksheetRes.Range[$"A{row}:G{row}"].Merge();
          worksheetRes.Range[$"A{row}"].RowHeight = 37.50;
          worksheetRes.Range[$"A{row}"].Text = "* Este valor incluye los medicamentos vendidos y los gastados en los servicios. \n ** No incluye los medicamentos suministrados por gastos a los servicios ni los medicamentos vendidos";
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}:G{row}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
          worksheetRes.Range[$"A{row}"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
          row++;

          IChartShape chart1 = worksheetRes.Charts.Add();
          //Set chart type
          chart1.ChartType = ExcelChartType.Column_Clustered_3D;

          chart1.Name = "chart1";
          for(i = iDatosChar1; i <= fDatosChar1; i++)
          {
            IChartSerie serie = chart1.Series.Add(worksheetRes.Range[$"A{i}"].Value);
            serie.Values = worksheetRes.Range[$"B{i}:G{i}"];
            serie.CategoryLabels = worksheetRes.Range["B7:G7"];
          }
          chart1.PrimaryCategoryAxis.Title = "MES";
          chart1.PrimaryValueAxis.Title = "COSTO";
          chart1.ChartTitle = "COSTO FORMULA POR MEDICO";
          chart1.HasLegend = true;
          chart1.Legend.Position = ExcelLegendPosition.Right;
          chart1.TopRow = row;
          chart1.LeftColumn = 1;
          chart1.RightColumn = 3;
          chart1.BottomRow = row + 17;

          IChartShape chart2 = worksheetRes.Charts.Add();
          //Set chart type
          chart2.ChartType = ExcelChartType.Column_Clustered_3D;

          chart2.Name = "chart2";
          for (i = 2; i <= 7; i++)
          {
            IChartSerie serie = chart2.Series.Add(worksheetRes.Range[7,i].Value);
            serie.Values = worksheetRes.Range[datosChar2,i];
            serie.EnteredDirectlyCategoryLabels = new object[] { "MESES" };
          }
          chart2.ChartTitle = "COSTO PROMEDIO DE FORMULACIÓN";
          chart2.HasLegend = true;
          chart2.Legend.Position = ExcelLegendPosition.Bottom;
          chart2.TopRow = row;
          chart2.LeftColumn = 3;
          chart2.RightColumn = 8;
          chart2.BottomRow = row + 17;
          row += 18;

          IChartShape chart3 = worksheetRes.Charts.Add();
          //Set chart type
          chart3.ChartType = ExcelChartType.Column_Clustered_3D;

          chart3.Name = "chart3";
          for (i = 2; i <= 7; i++)
          {
            IChartSerie serie = chart3.Series.Add(worksheetRes.Range[7, i].Value);
            serie.Values = worksheetRes.Range[datosChart3, i];
            serie.EnteredDirectlyCategoryLabels = new object[] { "MES" };
          }
          chart3.ChartTitle = "MEDICAMENTOS FORMULADOS EN EL MES";
          chart3.HasLegend = true;
          chart3.Legend.Position = ExcelLegendPosition.Bottom;
          chart3.TopRow = row;
          chart3.LeftColumn = 1;
          chart3.RightColumn = 3;
          chart3.BottomRow = row + 17;

          IChartShape chart4 = worksheetRes.Charts.Add();
          //Set chart type
          chart4.ChartType = ExcelChartType.Column_Clustered_3D;

          chart4.Name = "chart4";
          for (i = 2; i <= 7; i++)
          {
            IChartSerie serie = chart4.Series.Add(worksheetRes.Range[7, i].Value);
            serie.Values = worksheetRes.Range[datosChart4, i];
            serie.EnteredDirectlyCategoryLabels = new object[] { "MES" };
          }
          chart4.ChartTitle = "FORMULAS DESPACHADAS";
          chart4.HasLegend = true;
          chart4.Legend.Position = ExcelLegendPosition.Bottom;
          chart4.TopRow = row;
          chart4.LeftColumn = 3;
          chart4.RightColumn = 8;
          chart4.BottomRow = row + 17;
          row += 18;

          IChartShape chart5 = worksheetRes.Charts.Add();
          //Set chart type
          chart5.ChartType = ExcelChartType.Column_Clustered_3D;

          chart5.Name = "chart5";
          for (i = 2; i <= 7; i++)
          {
            IChartSerie serie = chart5.Series.Add(worksheetRes.Range[7, i].Value);
            serie.Values = worksheetRes.Range[datosChart5, i];
            serie.EnteredDirectlyCategoryLabels = new object[] { "TOTAL VALOR INVENTARIO" };
          }
          chart5.ChartTitle = "VALORACIÓN DEL INVENTARIO";
          chart5.HasLegend = true;
          chart5.Legend.Position = ExcelLegendPosition.Bottom;
          chart5.TopRow = row;
          chart5.LeftColumn = 1;
          chart5.RightColumn = 3;
          chart5.BottomRow = row + 17;

          IChartShape chart6 = worksheetRes.Charts.Add();
          //Set chart type
          chart6.ChartType = ExcelChartType.Column_Clustered_3D;

          chart4.Name = "chart6";
          for (i = 2; i <= 7; i++)
          {
            IChartSerie serie = chart6.Series.Add(worksheetRes.Range[7, i].Value);
            serie.Values = worksheetRes.Range[datosChart6, i];
            serie.EnteredDirectlyCategoryLabels = new object[] { "COMPRAS A PROVEEDORES" };
          }
          chart6.ChartTitle = "COMPRAS A PROVEEDORES";
          chart6.HasLegend = true;
          chart6.Legend.Position = ExcelLegendPosition.Bottom;
          chart6.TopRow = row;
          chart6.LeftColumn = 3;
          chart6.RightColumn = 8;
          chart6.BottomRow = row + 17;
          row += 18;

          IChartShape chart7 = worksheetRes.Charts.Add();
          //Set chart type
          chart7.ChartType = ExcelChartType.Column_Clustered_3D;

          chart7.Name = "chart7";
          IChartSerie serie7 = chart7.Series.Add(worksheetRes.Range[$"A{datosChart7}"].Value);
          serie7.Values = worksheetRes.Range[$"B{datosChart7}:G{datosChart7}"];
          serie7.CategoryLabels = worksheetRes.Range["B7:G7"];
          chart7.ChartTitle = "VENCIMIENTO DE MEDICAMENTOS";
          chart7.HasLegend = false;
          chart7.TopRow = row;
          chart7.LeftColumn = 1;
          chart7.RightColumn = 3;
          chart7.BottomRow = row + 17;

          IChartShape chart8 = worksheetRes.Charts.Add();
          //Set chart type
          chart8.ChartType = ExcelChartType.Column_Clustered_3D;

          chart8.Name = "chart8";
          for (i = iDatosChar8; i <= fDatosChar8; i++)
          {
            IChartSerie serie = chart8.Series.Add(worksheetRes.Range[$"A{i}"].Value);
            serie.Values = worksheetRes.Range[$"B{i}:G{i}"];
            serie.CategoryLabels = worksheetRes.Range["B7:G7"];
          }
          chart8.PrimaryCategoryAxis.Title = "MES";
          chart8.PrimaryValueAxis.Title = "COSTO";
          chart8.ChartTitle = "COSTO FORMULA POR MEDICO";
          chart8.HasLegend = true;
          chart8.Legend.Position = ExcelLegendPosition.Right;
          chart8.TopRow = row;
          chart8.LeftColumn = 3;
          chart8.RightColumn = 8;
          chart8.BottomRow = row + 17;
          row += 16;

          worksheetRes.PageSetup.PrintArea = $"$A$1:$G${row}";
          worksheetRes.PageSetup.Orientation = ExcelPageOrientation.Portrait;
          worksheetRes.PageSetup.FitToPagesWide = 1;
          worksheetRes.PageSetup.PaperSize = ExcelPaperSize.PaperLetter;
          worksheetRes.View = SheetView.PageBreakPreview;
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
