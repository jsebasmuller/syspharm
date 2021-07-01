using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysPharm.Models
{
  public class Usuario
  {
    [Key]
    public string Documento { get; set; }
    [ForeignKey("TipoDocumento")]
    public int IdTipoDocumento { get; set; }
    [ForeignKey("Eps")]
    public int IdEps { get; set; }
    [StringLength(250)]
    public string Nombres { get; set; }
    [StringLength(100)]
    public string Direccion { get; set; }
    [StringLength(10)]
    public string Telefono { get; set; }
    [StringLength(50)]
    public string TipoUsuario { get; set; }


    #region Propiedades de Navegación
    public TipoDocumento TipoDocumento { get; set; }
    public Eps Eps { get; set; }
    #endregion
  }
}
