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
using PagedList;
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

    public Medicamento GetMedicamento(int id)
    {
      var medicamento = _context.Medicamentos.Where(x => x.Id == id).FirstOrDefault();
      if (medicamento == null)
      {
        return null;
      }
      return medicamento;
    }

    public Medicamento GetMedicamento(string nombre)
    {
      var medicamento = _context.Medicamentos.Where(x => x.Nombre.Trim().ToLower() == nombre.Trim().ToLower()).FirstOrDefault();
      if (medicamento == null)
      {
        return null;
      }
      return medicamento;
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

    public IPagedList<Medicamento> GetMedicamentosPag(int? pagina)
    {
      int pageNumber = pagina ?? 1;
      return _context.Medicamentos.OrderBy(x => x.Nombre).ToPagedList(pageNumber, 13);
    }

    public IPagedList<Medicamento> BuscadorPag(string txtBuscar, int pagina)
    {
      var lista = _context.Medicamentos.Where(x => x.Cantidad.ToString().Contains(txtBuscar.Trim()) ||
                                            x.Nombre.Trim().ToLower().Contains(txtBuscar.Trim().ToLower()) ||
                                            x.VlrCompra.ToString().Trim().Contains(txtBuscar.Trim()) ||
                                            x.VlrVenta.ToString().Trim().ToLower().Contains(txtBuscar.Trim().ToLower())).OrderBy(x => x.Nombre).ToPagedList(pagina, 13);
      return lista;
    }

    public List<Medicamento> GetMedicamentos()
    {
      return _context.Medicamentos.OrderBy(x => x.Nombre).ToList();
    }

    public ResponseViewModel RegisterMedicamentoVencido(List<MedicamentoVencido> listMedVen)
    {
      var response = new ResponseViewModel();
      try
      {
        int count = 0;
        foreach (var medVen in listMedVen)
        {
          _context.MedicamentosVendicos.Add(medVen);
          var medicamento = _context.Medicamentos.Where(x => x.Id == medVen.IdMedicamento).FirstOrDefault();
          medicamento.Cantidad = medicamento.Cantidad - medVen.Cantidad;
          if (count == 100)
          {
            _context.SaveChanges();
            count = 0;
          }
          count++;
        }
        _context.SaveChanges();
        response.Respuesta = true;
        response.Mensaje = "Medicamentos vencidos registrados con exito";
      }
      catch (Exception e)
      {
        response.Respuesta = false;
        response.Mensaje = e.Message;
        return response;
      }
      return response;
    }

    public ResponseViewModel Arqueo(List<ArqueoViewModel> lista)
    {
      ResponseViewModel response = new ResponseViewModel();
      try
      {
        int count = 0;
        foreach(var arqueo in lista)
        {
          var medicamento = _context.Medicamentos.Where(x => x.Nombre == arqueo.Medicamento).FirstOrDefault();
          Arqueo arq = new Arqueo();
          arq.IdMedicamento = medicamento.Id;
          arq.ValorCompra = medicamento.VlrCompra;
          arq.ValorVenta = medicamento.VlrVenta;
          arq.CantidadFisica = arqueo.CantidadFisico;
          arq.CantidadSistema = arqueo.CantidadInventario;
          arq.FechaArqueo = DateTime.Now;
          medicamento.Cantidad = arq.CantidadFisica;
          _context.Arqueos.Add(arq);
          if (count == 100)
          {
            _context.SaveChanges();
            count = 0;
          }
          count++;
        }
        _context.SaveChanges();
        response.Respuesta = true;
        response.Mensaje = "Arqueo de inventario ajustado correctamente";
      }
      catch (Exception e)
      {
        response.Respuesta = false;
        response.Mensaje = e.Message;
        return response;
      }
      return response;
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

    public bool InventarioFinMes()
    {
      try
      {
        var exist = _context.InventariosFinMes.Where(x => x.Fecha.Year == DateTime.Now.Year && x.Fecha.Month == DateTime.Now.Month && x.Fecha.Day == DateTime.Now.Day).FirstOrDefault();
        if(exist != null)
        {
          return true;
        }
        var medicamentos = _context.Medicamentos.Select(x => new InventarioFinMes()
        {
          Cantidad = x.Cantidad,
          IdMedicamento = x.Id,
          ValorCompra = x.VlrCompra,
          Fecha = DateTime.Now
        }).ToList();
        int count = 0;
        foreach(var inventario in medicamentos)
        {
          _context.InventariosFinMes.Add(inventario);
          if(count == 100)
          {
            _context.SaveChanges();
            count = 0;
          }
          count++;
        }
        _context.SaveChanges();
        return true;
      }
      catch (Exception e)
      {
        return false;
      }
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
            _context.SaveChanges();
            count = 0;
          }
          row++;
          count++;
        }
        _context.SaveChanges();
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
