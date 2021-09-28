using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysPharm.Models
{
  public class DetallePedido
  {
    [Key]
    public int Id { get; set; }
    [ForeignKey("Medicamento")]
    public int IdMedicamento { get; set; }
    [ForeignKey("Pedido")]
    public string IdPedido { get; set; }
    [StringLength(50)]
    public string Lote { get; set; }
    [StringLength(50)]
    public string RegSanitario { get; set; }
    [StringLength(50)]
    public string CUM { get; set; }
    public int Cantidad { get; set; }
    public double VlrCompra { get; set; }
    public double VlrVenta { get; set; }
    public DateTime FechaVencimiento { get; set; }
    [StringLength(10)]
    public string ConcentracionPrincipioActivo { get; set; }
    [StringLength(5)]
    public string ClasificacionRiesgo { get; set; }

    #region Propiedades de navegación
    public Medicamento Medicamento { get; set; }
    public Pedido Pedido { get; set; }
    #endregion
  }
}
