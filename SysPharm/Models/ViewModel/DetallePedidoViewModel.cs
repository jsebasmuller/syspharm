using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysPharm.Models.ViewModel
{
  public class DetallePedidoViewModel
  {
    public string Medicamento { get; set; }
    public string Lote { get; set; }
    public string RegSanitario { get; set; }
    public string CUM { get; set; }
    public int Cantidad { get; set; }
    public double VlrCompra { get; set; }
    public double VlrVenta { get; set; }
  }
}
