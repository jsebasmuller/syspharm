﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Farmacia.Models
{
  public class TipoDocumento
  {
    [Key]
    public int Id { get; set; }
    [StringLength(50)]
    public string Nombre { get; set; }
  }
}
