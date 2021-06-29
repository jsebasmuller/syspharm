using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Farmacia.Models
{
  public class Medicamento
  {
    [Key]
    public string Id { get; set; }
    public DateTime FechaPedido { get; set; }
    public DateTime FechaIngreso { get; set; }
    public string RegSanitario { get; set; }
    public string Lote { get; set; }
  }
}
