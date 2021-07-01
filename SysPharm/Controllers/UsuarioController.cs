using SysPharm.Models.ViewModel;
using SysPharm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Drawing;
using Syncfusion.XlsIO;
using SysPharm.Models.ViewModel;
using System.IO;
using SysPharm.Helpers;
using System.Data.Entity;

namespace SysPharm.Controllers
{
  public class UsuarioController
  {
    private readonly Context _context;

    public UsuarioController(Context context)
    {
      _context = context;
    }

    public bool Login(string password) {
      var ingreso = _context.Ingresos.Where(x => x.Password == password && x.IsActive).FirstOrDefault();
      if (ingreso != null)
        return true;
      else
        return false;
    }

    public ResponseViewModel RegisterUser(Usuario user)
    {
      var response = new ResponseViewModel();
      _context.Usuarios.Add(user);
      try
      {
        _context.SaveChanges();
        response.Respuesta = true;
        response.Mensaje = "¡Usuario Creado Satisfactoriamente!";
      }catch(Exception e)
      {
        response.Respuesta = false;
        response.Mensaje = e.Message;
      }
      return response;
    }

    public ResponseViewModel UpdateUser(Usuario user)
    {
      var response = new ResponseViewModel();
      var userDB = _context.Usuarios.Where(x => x.Documento == user.Documento).FirstOrDefault();
      if(userDB == null)
      {
        response.Respuesta = false;
        response.Mensaje = "Usuario no encontrado";
        return response;
      }
      userDB.Documento = user.Documento;
      userDB.IdTipoDocumento = user.IdTipoDocumento;
      userDB.IdEps = user.IdEps;
      userDB.Nombres = user.Nombres;
      userDB.Telefono = user.Telefono;
      userDB.TipoUsuario = user.TipoUsuario;
      userDB.Direccion = user.Direccion;
      try
      {
        _context.SaveChanges();
        response.Respuesta = true;
        response.Mensaje = "¡Usuario Modificado Satisfactoriamente!";
      }catch(Exception e)
      {
        response.Mensaje = e.Message;
        response.Respuesta = false;
      }
      return response;
    }

    public ResponseViewModel DeleteUser(string documento)
    {
      var response = new ResponseViewModel();
      var userDB = _context.Usuarios.Where(x => x.Documento == documento).FirstOrDefault();
      if (userDB != null)
      {
        _context.Usuarios.Remove(userDB);
        try
        {
          _context.SaveChanges();
          response.Respuesta = true;
          response.Mensaje = "¡Usuario Eliminado!";
        }catch(Exception e)
        {
          response.Mensaje = e.Message;
          response.Respuesta = false;
          return response;
        }
        return response;
      }
      response.Mensaje = "Usuario no encontrado";
      response.Respuesta = false;
      return response;
    }

    public List<PacienteViewModel> GetPacientes()
    {
      return _context.Usuarios.Where(x => x.TipoUsuario.ToLower() == "paciente")
                              .Include(x => x.TipoDocumento)
                              .Include(x => x.Eps)
                              .Select(x => new PacienteViewModel
                              {
                                Documento = x.Documento,
                                TipoDocumento = x.TipoDocumento.Nombre,
                                Nombres = x.Nombres,
                                Direccion = x.Direccion,
                                Telefono = x.Telefono,
                                EPS = x.Eps.Nombre
                              }).ToList();
    }

    public List<PacienteViewModel> GetMedicos()
    {
      return _context.Usuarios.Where(x => x.TipoUsuario.ToLower() == "medico")
                              .Include(x => x.TipoDocumento)
                              .Include(x => x.Eps)
                              .Select(x => new PacienteViewModel
                              {
                                Documento = x.Documento,
                                TipoDocumento = x.TipoDocumento.Nombre,
                                Nombres = x.Nombres,
                                Direccion = x.Direccion,
                                Telefono = x.Telefono,
                                EPS = x.Eps.Nombre
                              }).ToList();
    }

    public List<TipoDocumento> GetTipoDocumentos()
    {
      return _context.TiposDocumento.ToList();
    }

    public ResponseViewModel DescargarPlantilla(string path)
    {
      ResponseViewModel response = new ResponseViewModel();
      try
      {
        System.IO.File.Copy(System.IO.Path.Combine(Application.StartupPath, "PlantillaUsuarios.xlsx"), path, true);
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

    private string ValidateUsers(string path)
    {
      try
      {
        ExcelEngine excelEngine = new ExcelEngine();
        IWorkbook workbook = excelEngine.Excel.Workbooks.Open(path);
        IWorksheet worksheet = workbook.Worksheets[0];
        StringBuilder sb = new StringBuilder();
        var stringError = "";

        if (worksheet.Name != "Usuarios")
        {
          return "La plantilla cargada no es la correcta, el nombre de la hoja debe ser Usuarios";
        }

        int row = 2;
        while (worksheet.Range[$"A{row}"].Value != "")
        {
          worksheet.Range[$"A{row}"].IsNumber("Documento", ref stringError);
          var documentoExcel = worksheet.Range[$"A{row}"].Value;
          var doc = _context.Usuarios.Where(x => x.Documento == documentoExcel).FirstOrDefault();
          if(doc != null)
          {
            stringError = $"El documento número {worksheet.Range[$"A{row}"].Value} ya se encuetra registrado";
          }

          if (string.IsNullOrEmpty(worksheet.Range[$"B{row}"].Value) && string.IsNullOrWhiteSpace(worksheet.Range[$"B{row}"].Value))
          {
            stringError += (string.IsNullOrEmpty(stringError) ? "" : ", ") + "Debe seleccionar un tipo de documento";
          }

          if (string.IsNullOrEmpty(worksheet.Range[$"C{row}"].Value) && string.IsNullOrWhiteSpace(worksheet.Range[$"C{row}"].Value))
          {
            stringError += (string.IsNullOrEmpty(stringError) ? "" : ", ") + "Debe ingresar el nombre y apellido del usuario";
          }

          if (string.IsNullOrEmpty(worksheet.Range[$"D{row}"].Value) && string.IsNullOrWhiteSpace(worksheet.Range[$"D{row}"].Value))
          {
            stringError += (string.IsNullOrEmpty(stringError) ? "" : ", ") + "Debe ingresar la dirección del usuario";
          }

          worksheet.Range[$"E{row}"].IsNumber("Teléfono", ref stringError);
          if (string.IsNullOrEmpty(worksheet.Range[$"E{row}"].Value) && string.IsNullOrWhiteSpace(worksheet.Range[$"E{row}"].Value))
          {
            stringError += (string.IsNullOrEmpty(stringError) ? "" : ", ") + "Debe ingresar el teléfono del usuario";
          }

          if (string.IsNullOrEmpty(worksheet.Range[$"F{row}"].Value) && string.IsNullOrWhiteSpace(worksheet.Range[$"F{row}"].Value))
          {
            stringError += (string.IsNullOrEmpty(stringError) ? "" : ", ") + "Debe seleccionar un tipo de usuario";
          }

          if (string.IsNullOrEmpty(worksheet.Range[$"G{row}"].Value) && string.IsNullOrWhiteSpace(worksheet.Range[$"G{row}"].Value))
          {
            stringError += (string.IsNullOrEmpty(stringError) ? "" : ", ") + "Debe seleccionar un tipo de usuario";
          }

          var stringEps = worksheet.Range[$"G{row}"].Value;
          var Eps = _context.Eps.Where(x => x.Nombre.Trim().ToLower() == stringEps.Trim().ToLower()).FirstOrDefault();
          if (Eps == null)
          {
            stringError = $"La EPS {worksheet.Range[$"G{row}"].Value} no se encuentra en la base de datos";
          }

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
        string error = ValidateUsers(path);
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
          var tipoDoc = worksheet.Range[$"B{row}"].Value.Trim().ToUpper();
          var idTipoDoc = _context.TiposDocumento.Where(a => a.Nombre.Trim().ToUpper() == tipoDoc).FirstOrDefault().Id;
          var usuario = new Usuario();
          usuario.Documento = worksheet.Range[$"A{row}"].Value;
          usuario.IdTipoDocumento = idTipoDoc;
          usuario.Nombres = worksheet.Range[$"C{row}"].Value.Trim();
          usuario.Direccion = worksheet.Range[$"D{row}"].Value.Trim();
          usuario.Telefono = worksheet.Range[$"E{row}"].Value.Trim();
          usuario.TipoUsuario = worksheet.Range[$"F{row}"].Value.Trim();
          var stringEps = worksheet.Range[$"G{row}"].Value;
          var eps = _context.Eps.Where(x => x.Nombre.Trim().ToLower() == stringEps.Trim().ToLower()).FirstOrDefault();
          usuario.IdEps = eps.Id;
          _context.Usuarios.Add(usuario);
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
