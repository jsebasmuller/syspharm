using SysPharm.Models;
using SysPharm.Models.ViewModel;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
  }
}
