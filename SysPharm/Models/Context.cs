namespace SysPharm.Models
{
  using System;
  using System.Data.Entity;
  using System.Data.Entity.ModelConfiguration.Conventions;
  using System.Linq;

  public class Context : DbContext
  {
    public Context()
        : base("syspharm")
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Medicamento> Medicamentos { get; set; }
    public DbSet<Eps> Eps { get; set; }
    public DbSet<Formula> Formulas { get; set; }
    public DbSet<DetalleFormula> DetallesFormula { get; set; }
    public DbSet<DetallePedido> DetallesPedido { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Servicio> Servicios { get; set; }
    public DbSet<TipoDocumento> TiposDocumento { get; set; }
    public DbSet<Ingreso> Ingresos { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }
  }
}