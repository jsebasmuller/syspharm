using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysPharm.Models.ViewModel
{
  public class DetalleFormulaViewModel
  {
    public string Medicamento { get; set; }
    public int CantidadFormula { get; set; }
    public int Cantidad { get; set; }
    public int CantidadPendiente { get; set; }
    public double VlrU { get; set; }
    public double VlrT { get; set; }
  }
}
