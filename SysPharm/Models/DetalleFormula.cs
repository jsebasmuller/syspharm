using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysPharm.Models
{
  public class DetalleFormula
  {
    [Key]
    public int Id { get; set; }
    [ForeignKey("Formula")]
    public string IdFormula { get; set; }
    [ForeignKey("Medicamento")]
    public int IdMedicamento { get; set; }
    public int CantidadFormula { get; set; }
    public int Cantidad { get; set; }
    public int CantidadPendiente { get; set; }
    public double PrecioCompra { get; set; }
    public double PrecioVenta { get; set; }

    #region Propiedades de Navegación
    public Formula Formula { get; set; }
    public Medicamento Medicamento { get; set; }
    #endregion
  }
}
