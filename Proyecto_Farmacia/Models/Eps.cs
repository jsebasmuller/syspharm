using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Farmacia.Models
{
  public class Eps
  {
    [Key]
    public int Id { get; set; }
    [StringLength(100)]
    public string Nombre { get; set; }
  }
}
