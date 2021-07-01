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
using System.Data.Entity;
using Proyecto_Farmacia.Models.ViewModel;
using System.IO;
using SysPharm.Helpers;

namespace SysPharm.Controllers
{
  public class EPSController
  {
    private readonly Context _context;

    public EPSController(Context context)
    {
      _context = context;
    }

    public ResponseViewModel RegisterEPS(Eps eps)
    {
      var response = new ResponseViewModel();
      _context.Eps.Add(eps);
      try
      {
        _context.SaveChanges();
        response.Respuesta = true;
        response.Mensaje = "¡EPS Creada Satisfactoriamente!";
      }catch(Exception e)
      {
        response.Respuesta = false;
        response.Mensaje = e.Message;
      }
      return response;
    }

    public ResponseViewModel UpdateEPS(Eps eps)
    {
      var response = new ResponseViewModel();
      var epsDB = _context.Eps.Where(x => x.Id == eps.Id).FirstOrDefault();
      if(epsDB == null)
      {
        response.Respuesta = false;
        response.Mensaje = "EPS no encontrada";
        return response;
      }
      epsDB.Nombre = eps.Nombre;
      try
      {
        _context.SaveChanges();
        response.Respuesta = true;
        response.Mensaje = "¡EPS Modificada Satisfactoriamente!";
      }catch(Exception e)
      {
        response.Mensaje = e.Message;
        response.Respuesta = false;
      }
      return response;
    }

    public ResponseViewModel DeleteEPS(int idEps)
    {
      var response = new ResponseViewModel();
      var epsDB = _context.Eps.Where(x => x.Id == idEps).FirstOrDefault();
      if (epsDB != null)
      {
        _context.Eps.Remove(epsDB);
        try
        {
          _context.SaveChanges();
          response.Respuesta = true;
          response.Mensaje = "¡EPS Eliminada!";
        }catch(Exception e)
        {
          response.Mensaje = e.Message;
          response.Respuesta = false;
          return response;
        }
        return response;
      }
      response.Mensaje = "EPS no encontrada";
      response.Respuesta = false;
      return response;
    }

    public List<Eps> GetEps()
    {
      return _context.Eps.ToList();
    }
  }
}
