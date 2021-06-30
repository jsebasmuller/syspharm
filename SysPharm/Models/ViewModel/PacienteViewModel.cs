using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysPharm.Models.ViewModel
{
  public class PacienteViewModel
  {
    public string Documento { get; set; }
    public string TipoDocumento { get; set; }
    public string Nombres { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
  }
}
