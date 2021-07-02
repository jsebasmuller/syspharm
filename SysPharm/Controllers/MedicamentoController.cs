using Syncfusion.XlsIO;
using SysPharm.Helpers;
using SysPharm.Models;
using SysPharm.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysPharm.Controllers
{
  public class MedicamentoController
  {
    private readonly Context _context;

    public MedicamentoController(Context context)
    {
      _context = context;
    }

    public bool Login(string password)
    {
      var ingreso = _context.Ingresos.Where(x => x.Password == password && x.IsActive).FirstOrDefault();
      if (ingreso != null)
        return true;
      else
        return false;
    }

    public ResponseViewModel RegisterMedicamento(Medicamento medicamento)
    {
      var response = new ResponseViewModel();
      medicamento.Cantidad = 0;
      _context.Medicamentos.Add(medicamento);
      try
      {
        _context.SaveChanges();
        response.Respuesta = true;
        response.Mensaje = "¡Medicamento Creado Satisfactoriamente!";
      }
      catch (Exception e)
      {
        response.Respuesta = false;
        response.Mensaje = e.Message;
      }
      return response;
    }

    public ResponseViewModel UpdateMedicamento(Medicamento medicamento)
    {
      var response = new ResponseViewModel();
      var medicamentoDB = _context.Medicamentos.Where(x => x.Id == medicamento.Id).FirstOrDefault();
      if (medicamentoDB == null)
      {
        response.Respuesta = false;
        response.Mensaje = "Medicamento no encontrado";
        return response;
      }
      medicamentoDB.Nombre = medicamento.Nombre;
      medicamentoDB.VlrCompra = medicamento.VlrCompra;
      medicamentoDB.VlrVenta = medicamento.VlrVenta;
      try
      {
        _context.SaveChanges();
        response.Respuesta = true;
        response.Mensaje = "¡Medicamento Modificado Satisfactoriamente!";
      }
      catch (Exception e)
      {
        response.Mensaje = e.Message;
        response.Respuesta = false;
      }
      return response;
    }

    public ResponseViewModel DeleteMedicamento(int id)
    {
      var response = new ResponseViewModel();
      var medicamentoDB = _context.Medicamentos.Where(x => x.Id == id).FirstOrDefault();
      if (medicamentoDB != null)
      {
        _context.Medicamentos.Remove(medicamentoDB);
        try
        {
          _context.SaveChanges();
          response.Respuesta = true;
          response.Mensaje = "¡Medicamento Eliminado!";
        }
        catch (Exception e)
        {
          response.Mensaje = e.Message;
          response.Respuesta = false;
          return response;
        }
        return response;
      }
      response.Mensaje = "Medicamento no encontrado";
      response.Respuesta = false;
      return response;
    }

    public List<Medicamento> GetMedicamentos()
    {
      return _context.Medicamentos.ToList();
    }

    public ResponseViewModel DescargarPlantilla(string path)
    {
      ResponseViewModel response = new ResponseViewModel();
      try
      {
        System.IO.File.Copy(System.IO.Path.Combine(Application.StartupPath, "PlantillaMedicamentos.xlsx"), path, true);
        response.Respuesta = true;
        response.Mensaje = "Plantilla Descargada Satisfactoriamente";
      }
      catch (Exception exc)
      {
        response.Respuesta = false;
        response.Mensaje = "Error al Descargar la Plantilla";
        return response;
      }
      return response;
    }

    private string ValidateMedicamentos(string path)
    {
      try
      {
        ExcelEngine excelEngine = new ExcelEngine();
        IWorkbook workbook = excelEngine.Excel.Workbooks.Open(path);
        IWorksheet worksheet = workbook.Worksheets[0];
        StringBuilder sb = new StringBuilder();
        var stringError = "";

        if (worksheet.Name != "Medicamentos")
        {
          return "La plantilla cargada no es la correcta, el nombre de la hoja debe ser Medicamentos";
        }

        int row = 2;
        while (worksheet.Range[$"A{row}"].Value != "")
        {
          var nomMed = worksheet.Range[$"A{row}"].Value;
          var med = _context.Medicamentos.Where(x => x.Nombre.Trim().ToLower() == nomMed.Trim().ToLower()).FirstOrDefault();
          if (med != null)
          {
            stringError = $"El medicamento {worksheet.Range[$"A{row}"].Value} ya se encuetra registrado";
          }

          if (string.IsNullOrEmpty(worksheet.Range[$"B{row}"].Value) && string.IsNullOrWhiteSpace(worksheet.Range[$"B{row}"].Value))
          {
            stringError += (string.IsNullOrEmpty(stringError) ? "" : ", ") + "Debe ingresar el valor de compra del medicamento";
          }
          worksheet.Range[$"B{row}"].IsNumber("Valor de Compra", ref stringError);

          if (string.IsNullOrEmpty(worksheet.Range[$"C{row}"].Value) && string.IsNullOrWhiteSpace(worksheet.Range[$"C{row}"].Value))
          {
            stringError += (string.IsNullOrEmpty(stringError) ? "" : ", ") + "Debe ingresar el valor de venta del medicamento";
          }
          worksheet.Range[$"C{row}"].IsNumber("Valor de Venta", ref stringError);

          if (!string.IsNullOrEmpty(stringError))
          {
            sb.AppendLine($"Linea {row}: {stringError}");
          }
          stringError = "";
          row++;
        }
        return sb.ToString();
      }
      catch (Exception exc)
      {
        return exc.Message;
      }
    }

    public ResponseViewModel BulkLoadUsuarios(string path)
    {
      ResponseViewModel response = new ResponseViewModel();
      try
      {
        string error = ValidateMedicamentos(path);
        if (error != "")
        {
          response.Respuesta = false;
          response.Mensaje = error;
          return response;
        }
        ExcelEngine excelEngine = new ExcelEngine();
        IWorkbook workbook = excelEngine.Excel.Workbooks.Open(path);
        IWorksheet worksheet = workbook.Worksheets[0];
        var row = 2;
        int count = 0;
        while (worksheet.Range[$"A{row}"].Value != "")
        {
          var medicamento = new Medicamento();
          medicamento.Nombre = worksheet.Range[$"A{row}"].Value;
          medicamento.VlrCompra = worksheet.Range[$"B{row}"].Number;
          medicamento.VlrVenta = worksheet.Range[$"C{row}"].Number;
          medicamento.Cantidad = 0;
          _context.Medicamentos.Add(medicamento);
          if (count == 100)
          {
            _context.SaveChangesAsync();
            count = 0;
          }
          row++;
          count++;
        }
        _context.SaveChangesAsync();
        response.Respuesta = true;
        response.Mensaje = "La carga masiva ha sido registrada correctamente";
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
