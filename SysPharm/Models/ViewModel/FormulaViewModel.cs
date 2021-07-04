using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysPharm.Models.ViewModel
{
  public class FormulaViewModel
  {
    public string Id { get; set; }
    public DateTime FechaFormula { get; set; }
    public DateTime FechaDespacho { get; set; }
    public string IdMedico { get; set; }
    public string NombreMedico { get; set; }
    public string IdPaciente { get; set; }
    public string NombrePaciente { get; set; }
    public string Servicio { get; set; }
    public int TotalMedicamentos { get; set; }
    public double TotalCompra { get; set; }
    public double TotalVenta { get; set; }
  }
}
