namespace SysPharm.Models
{
  using System;
  using System.Data.Entity;
  using System.Data.Entity.ModelConfiguration.Conventions;
  using System.Linq;

  public class Context : DbContext
  {
    public Context()
        : base(@"data source=25.78.148.250;initial catalog=syspharm;User ID=sa;Password=Sanpedro2021+;")
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
    public DbSet<InventarioFinMes> InventariosFinMes { get; set; }
    public DbSet<Arqueo> Arqueos { get; set; }
    public DbSet<MedicamentoVencido> MedicamentosVendicos { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }
  }
}