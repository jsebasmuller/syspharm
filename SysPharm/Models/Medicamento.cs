using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysPharm.Models
{
  public class Medicamento
  {
    [Key]
    public int Id { get; set; }
    [StringLength(500)]
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public double VlrCompra { get; set; }
    public double VlrVenta { get; set; }

    #region Propiedades de navegación
    public List<DetalleFormula> DetallesFormula { get; set; }
    public List<DetallePedido> DetallesPedido { get; set; }
    #endregion
  }
}
