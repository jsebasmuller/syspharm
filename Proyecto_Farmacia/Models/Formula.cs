using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Farmacia.Models
{
  public class Formula
  {
    [Key]
    public string Id { get; set; }
    public DateTime FechaFormula { get; set; }
    public DateTime FechaDespacho { get; set; }
    [ForeignKey("Medico")]
    public string IdMedico { get; set; }
    [ForeignKey("Paciente")]
    public string IdPaciente { get; set; }
    [ForeignKey("Servicio")]
    public int IdServicio { get; set; }
       
    #region Propiedades de Navegación
    public Usuario Medico { get; set; }
    public Usuario Paciente { get; set; }
    public Servicio Servicio { get; set; }
    #endregion
  }
}
