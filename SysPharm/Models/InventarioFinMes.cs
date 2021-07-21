using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysPharm.Models
{
  public class InventarioFinMes
  {
    [Key]
    public string Id { get; set; }
    [ForeignKey("Medicamento")]
    public int IdMedicamento { get; set; }
    public int Cantidad { get; set; }
    public double ValorCompra { get; set; }
    public DateTime Fecha { get; set; }

    public Medicamento Medicamento { get; set; }
  }
}
