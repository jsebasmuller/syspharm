using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysPharm.Models.ViewModel
{
  public class ArqueoViewModel
  {
    public string Medicamento { get; set; }
    public int CantidadInventario { get; set; }
    public int CantidadFisico { get; set; }
    public int Diferencia { get; set; }
  }
}
