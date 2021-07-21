using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysPharm.Models.ViewModel
{
  public class MedicamentoVencidoViewModel
  {
    public string Medicamento { get; set; }
    public int Cantidad { get; set; }
    public double VlrCompra { get; set; }
    public DateTime FechaRegistro { get; set; }
  }
}
