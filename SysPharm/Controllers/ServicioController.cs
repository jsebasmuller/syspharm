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
using SysPharm.Models.ViewModel;
using System.IO;
using SysPharm.Helpers;

namespace SysPharm.Controllers
{
  public class ServicioController
  {
    private readonly Context _context;

    public ServicioController(Context context)
    {
      _context = context;
    }

    public ResponseViewModel RegisterServicio(Servicio servicio)
    {
      var response = new ResponseViewModel();
      _context.Servicios.Add(servicio);
      try
      {
        _context.SaveChanges();
        response.Respuesta = true;
        response.Mensaje = "¡Servicio Creado Satisfactoriamente!";
      }catch(Exception e)
      {
        response.Respuesta = false;
        response.Mensaje = e.Message;
      }
      return response;
    }

    public ResponseViewModel UpdateServicio(Servicio servicio)
    {
      var response = new ResponseViewModel();
      var servicioDB = _context.Servicios.Where(x => x.Id == servicio.Id).FirstOrDefault();
      if(servicioDB == null)
      {
        response.Respuesta = false;
        response.Mensaje = "Servicio no encontrada";
        return response;
      }
      servicioDB.Nombre = servicio.Nombre;
      try
      {
        _context.SaveChanges();
        response.Respuesta = true;
        response.Mensaje = "¡Servicio Modificado Satisfactoriamente!";
      }catch(Exception e)
      {
        response.Mensaje = e.Message;
        response.Respuesta = false;
      }
      return response;
    }

    public ResponseViewModel DeleteServicio(int idServicio)
    {
      var response = new ResponseViewModel();
      var servicioDB = _context.Servicios.Where(x => x.Id == idServicio).FirstOrDefault();
      if (servicioDB != null)
      {
        _context.Servicios.Remove(servicioDB);
        try
        {
          _context.SaveChanges();
          response.Respuesta = true;
          response.Mensaje = "¡Servicio Eliminado!";
        }catch(Exception e)
        {
          response.Mensaje = e.Message;
          response.Respuesta = false;
          return response;
        }
        return response;
      }
      response.Mensaje = "Servicio no encontrado";
      response.Respuesta = false;
      return response;
    }

    public List<Servicio> GetServicios()
    {
      return _context.Servicios.ToList();
    }
  }
}
