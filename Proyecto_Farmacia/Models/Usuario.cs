using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Farmacia.Models
{
  public class Usuario
  {
    [Key]
    public string Documento { get; set; }
    [ForeignKey("TipoDocumento")]
    public int IdTipoDocumento { get; set; }
    [StringLength(250)]
    public string Nombres { get; set; }
    [StringLength(100)]
    public string Direccion { get; set; }
    [StringLength(10)]
    public string Telefono { get; set; }


    #region Propiedades de Navegación
    public TipoDocumento TipoDocumento { get; set; }
    #endregion
  }
}
