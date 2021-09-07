using SysPharm.Models;
using SysPharm.Models.ViewModel;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Syncfusion.XlsIO;
using System.Drawing;

namespace SysPharm.Controllers
{
  public class FormulaController
  {
    private readonly Context _context;

    public FormulaController(Context context)
    {
      _context = context;
    }

    public ResponseViewModel RegisterFormula(Formula formula)
    {
      var response = new ResponseViewModel();
      _context.Formulas.Add(formula);
      try
      {
        _context.SaveChanges();
        foreach (var detalleFormula in formula.DetalleFormula)
        {
          var medicamentoDb = _context.Medicamentos.Where(m => m.Id == detalleFormula.IdMedicamento).FirstOrDefault();
          medicamentoDb.Cantidad -= detalleFormula.Cantidad;
          _context.SaveChanges();
        }
        response.Respuesta = true;
        response.Mensaje = "¡Formula registrada satisfactoriamente!";
      }
      catch (Exception e)
      {
        response.Respuesta = false;
        response.Mensaje = e.Message;
        return response;
      }
      return response;
    }

    public List<FormulaViewModel> GetFormulas()
    {
      return _context.Formulas
                     .Include(x => x.Medico)
                     .Include(x => x.Paciente)
                     .Include(x => x.Servicio)
                     .Select(x => new FormulaViewModel()
                     {
                       Id = x.Id,
                       FechaDespacho = x.FechaDespacho,
                       FechaFormula = x.FechaFormula,
                       IdMedico = x.IdMedico,
                       NombreMedico = x.Medico.Nombres,
                       IdPaciente = x.IdPaciente,
                       NombrePaciente = x.Paciente.Nombres,
                       Servicio = x.Servicio.Nombre,
                       TotalCompra = x.TotalCompra,
                       TotalVenta = x.TotalVenta,
                       TotalMedicamentos = x.TotalMedicamentos     
                     })
                     .OrderByDescending(x => x.Id).ToList();
    }

    public IPagedList<FormulaViewModel> GetFormulasPag(int? pagina)
    {
      int pageNumber = pagina ?? 1;
      return _context.Formulas.Include(x => x.Medico)
                              .Include(x => x.Paciente)
                              .Include(x => x.Servicio)
                              .Select(x => new FormulaViewModel()
                              {
                                Id = x.Id,
                                FechaDespacho = x.FechaDespacho,
                                FechaFormula = x.FechaFormula,
                                IdMedico = x.IdMedico,
                                NombreMedico = x.Medico.Nombres,
                                IdPaciente = x.IdPaciente,
                                NombrePaciente = x.Paciente.Nombres,
                                Servicio = x.Servicio.Nombre,
                                TotalCompra = x.TotalCompra,
                                TotalVenta = x.TotalVenta,
                                TotalMedicamentos = x.TotalMedicamentos
                              }).OrderByDescending(x => x.Id).ToPagedList(pageNumber, 13);
    }

    public IPagedList<FormulaViewModel> BuscadorPag(string txtBuscar, int? pagina)
    {
      int pageNumber = pagina ?? 1;
      return _context.Formulas.Include(x => x.Medico)
                              .Include(x => x.Paciente)
                              .Include(x => x.Servicio)
                              .Select(x => new FormulaViewModel()
                              {
                                Id = x.Id,
                                FechaDespacho = x.FechaDespacho,
                                FechaFormula = x.FechaFormula,
                                IdMedico = x.IdMedico,
                                NombreMedico = x.Medico.Nombres,
                                IdPaciente = x.IdPaciente,
                                NombrePaciente = x.Paciente.Nombres,
                                Servicio = x.Servicio.Nombre,
                                TotalCompra = x.TotalCompra,
                                TotalVenta = x.TotalVenta,
                                TotalMedicamentos = x.TotalMedicamentos
                              }).Where(x => x.Id.Contains(txtBuscar.Trim()) ||
                                            x.FechaDespacho.ToString().Contains(txtBuscar.Trim()) ||
                                            x.FechaFormula.ToString().Contains(txtBuscar.Trim()) ||
                                            x.IdMedico.Contains(txtBuscar.Trim()) || 
                                            x.NombreMedico.Trim().ToLower().Contains(txtBuscar.Trim().ToLower()) ||
                                            x.IdPaciente.Contains(txtBuscar.Trim()) ||
                                            x.NombrePaciente.Trim().ToLower().Contains(txtBuscar.Trim().ToLower()) ||
                                            x.Servicio.Trim().ToLower().Contains(txtBuscar.Trim().ToLower()) ||
                                            x.TotalCompra.ToString().Trim().Contains(txtBuscar.Trim()) ||
                                            x.TotalVenta.ToString().Trim().Contains(txtBuscar.Trim())).OrderByDescending(x => x.Id).ToPagedList(pageNumber, 13);
    }

    public string GetNextId(DateTime fechaAct)
    {
      DateTime fechaInicio = new DateTime(fechaAct.Year, fechaAct.Month, 1);
      DateTime fechaFinal = fechaInicio.AddMonths(1);
      var lastAnt = _context.Formulas.Where(a => a.FechaDespacho >= fechaInicio && a.FechaDespacho < fechaFinal)
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
          var formulas = _context.DetallesFormula
                                  .Include(dp => dp.Formula)
                                  .Include(dp => dp.Formula.Paciente)
                                  .Include(dp => dp.Formula.Servicio)
                                  .Include(dp => dp.Medicamento)
                                  .Where(dp => dp.Formula.FechaDespacho.Year == fecha.Year && dp.Formula.FechaDespacho.Month == fecha.Month)
                                  .OrderByDescending(dp => dp.IdFormula).ToList();

          //Create a workbook
          IWorkbook workbook = application.Workbooks.Create(1);
          IWorksheet worksheet = workbook.Worksheets[0];
          worksheet.Name = $"FORMULAS MES {fecha.ToString("MMMM").ToUpper()}";
          int row = 2;
          worksheet.IsGridLinesVisible = false;

          #region WorkSheetMes
          worksheet.Range["A1:J10000"].CellStyle.Font.FontName = "Arial";
          worksheet.Range["A1:J10000"].CellStyle.Font.Size = 11;
          worksheet.Range["A1:J10000"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
          worksheet.Range["A1:J10000"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;
          worksheet.Range["A1:J1"].CellStyle.Color = Color.FromArgb(89, 193, 203);
          worksheet.Range["A1:J1"].CellStyle.Font.Bold = true;
          worksheet.Range["A1:J1"].CellStyle.Font.RGBColor = Color.FromArgb(255, 255, 255);
          worksheet.Range["A1"].Text = "NÚMERO FORMULA";
          worksheet.Range["A1"].ColumnWidth = 10.71;
          worksheet.Range["B1"].Text = "FECHA";
          worksheet.Range["B1"].ColumnWidth = 14.43;
          worksheet.Range["C1"].Text = "DOCUMENTO";
          worksheet.Range["C1"].ColumnWidth = 13;
          worksheet.Range["D1"].Text = "NOMBRE DE USUARIO";
          worksheet.Range["D1"].ColumnWidth = 36;
          worksheet.Range["E1"].Text = "SERVICIO";
          worksheet.Range["E1"].ColumnWidth = 16.43;
          worksheet.Range["F1"].Text = "REGISTRO MEDICO";
          worksheet.Range["F1"].ColumnWidth = 12.29; ;
          worksheet.Range["G1"].Text = "MEDICAMENTO";
          worksheet.Range["G1"].ColumnWidth = 36.86;
          worksheet.Range["H1"].Text = "CANTIDAD";
          worksheet.Range["H1"].ColumnWidth = 11;
          worksheet.Range["I1"].Text = "PRECIO UNITARIO";
          worksheet.Range["I1"].ColumnWidth = 10.43;
          worksheet.Range["J1"].Text = "VALOR TOTAL";
          worksheet.Range["J1"].ColumnWidth = 10;
          foreach (var detalle in formulas)
          {
            worksheet.Range[$"A{row}"].Text = detalle.Formula.Id;
            worksheet.Range[$"B{row}"].Text = detalle.Formula.FechaDespacho.ToString("dd/MM/yyyy");
            worksheet.Range[$"C{row}"].Text = detalle.Formula.IdPaciente;
            worksheet.Range[$"D{row}"].Text = detalle.Formula.Paciente.Nombres;
            worksheet.Range[$"E{row}"].Text = detalle.Formula.Servicio.Nombre;
            worksheet.Range[$"F{row}"].Text = detalle.Formula.IdMedico;
            worksheet.Range[$"G{row}"].Text = detalle.Medicamento.Nombre;
            worksheet.Range[$"H{row}"].Number = detalle.Cantidad;
            worksheet.Range[$"I{row}"].NumberFormat = "_($* #,##0_)";
            worksheet.Range[$"I{row}"].Number = detalle.PrecioCompra;
            worksheet.Range[$"J{row}"].NumberFormat = "_($* #,##0_)";
            worksheet.Range[$"J{row}"].Number = detalle.PrecioCompra * detalle.Cantidad;
            row++;
          }
          worksheet.PageSetup.PrintArea = $"$A$1:$J${row - 1}";
          worksheet.Range[$"A1:J{row - 1}"].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A1:J{row - 1}"].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A1:J{row - 1}"].CellStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A1:J{row - 1}"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
          worksheet.Range[$"A2:J{(row == 2 ? row : row - 1)}"].CellStyle.Font.RGBColor = Color.FromArgb(0, 0, 0);
          worksheet.Range[$"A1:J{row - 1}"].CellStyle.WrapText = true;
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
