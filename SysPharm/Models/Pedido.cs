using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysPharm.Models
{
  public class Pedido
  {
    [Key]
    public string Id { get; set; }
    [StringLength(10)]
    public string NumeroFactura { get; set; }
    [StringLength(250)]
    public string Proveedor { get; set; }
    public DateTime FechaPedido { get; set; }
    public DateTime FechaIngreso { get; set; }
    public double VlrTotal { get; set; }

    #region Propiedades de navegación
    public List<DetallePedido> DetallesPedido { get; set; }
    #endregion
  }
}
