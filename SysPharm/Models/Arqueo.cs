using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysPharm.Models
{
  public class Arqueo
  {
    [Key]
    public int Id { get; set; }
    [ForeignKey("Medicamento")]
    public int IdMedicamento { get; set; }
    public int CantidadSistema { get; set; }
    public int CantidadFisica { get; set; }
    public double ValorCompra { get; set; }
    public double ValorVenta { get; set; }
    public DateTime FechaArqueo { get; set; }

    public Medicamento Medicamento { get; set; }
  }
}
