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
          IWorkbook workbook = application.Workbooks.Create(1);
          IWorksheet worksheet = workbook.Worksheets[0];
          worksheet.Name = $"INFORME MES {fecha.ToString("MMMM").ToUpper()}";

          worksheet.IsGridLinesVisible = false;

          IPictureShape shapeIconSP = worksheet.Pictures.AddPicture(1, 1, System.IO.Path.Combine(Application.StartupPath, "IconoSysPharm.png"));
          shapeIconSP.Top = 5;
          shapeIconSP.Left = 63;

          shapeIconSP.Height = 70;
          shapeIconSP.Width = 91;

          IPictureShape shapeESE = worksheet.Pictures.AddPicture(1, 1, System.IO.Path.Combine(Application.StartupPath, "IconoESE.png"));
          shapeESE.Top = 5;
          shapeESE.Left = 402;

          shapeESE.Height = 70;
          shapeESE.Width = 189;
          //worksheetResumen.PageSetup.PrintTitleColumns = "$A:$H";
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
          worksheet.Range[$"F{row}"].Number = formulas.Where(x => x.Servicio.Nombre.Trim().ToLower() != "gastos servicios" && x.Servicio.Nombre.Trim().ToLower() != "venta al publico")
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
          worksheet.Range[$"F{row}"].Number = _context.Pedidos.Where(x => x.FechaIngreso >= fechaInicio && x.FechaIngreso < fechaFinal).Sum(x => x.VlrTotal);
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
          var formulasSixMon = _context.Formulas.Where(x => x.FechaDespacho >= sixMon && x.FechaDespacho < fechaFinal).ToList();
          worksheet.Range[$"F{row}"].Number = formulasSixMon.Sum(x => x.TotalCompra) / 6;
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
          worksheet.Range[$"F{row}"].Number = (confiabilidadUnidades + confiabilidadInventario)/2;
          worksheet.Range[$"F{row}"].NumberFormat = "0.00%";

          worksheet.PageSetup.PrintArea = $"$A$1:$H${row}";
          worksheet.PageSetup.Orientation = ExcelPageOrientation.Portrait;
          worksheet.PageSetup.FitToPagesWide = 1;
          worksheet.PageSetup.PaperSize = ExcelPaperSize.PaperLetter;
          worksheet.View = SheetView.PageBreakPreview;

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
