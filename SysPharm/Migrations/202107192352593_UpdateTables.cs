namespace Proyecto_Farmacia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arqueo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdMedicamento = c.Int(nullable: false),
                        CantidadSistema = c.Int(nullable: false),
                        CantidadFisica = c.Int(nullable: false),
                        ValorCompra = c.Double(nullable: false),
                        ValorVenta = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicamento", t => t.IdMedicamento, cascadeDelete: true)
                .Index(t => t.IdMedicamento);
            
            CreateTable(
                "dbo.MedicamentoVencido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdMedicamento = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        ValorCompra = c.Double(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicamento", t => t.IdMedicamento, cascadeDelete: true)
                .Index(t => t.IdMedicamento);
            
            AddColumn("dbo.InventarioFinMes", "IdMedicamento", c => c.Int(nullable: false));
            CreateIndex("dbo.InventarioFinMes", "IdMedicamento");
            AddForeignKey("dbo.InventarioFinMes", "IdMedicamento", "dbo.Medicamento", "Id", cascadeDelete: true);
            DropColumn("dbo.InventarioFinMes", "NombreMedicamento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InventarioFinMes", "NombreMedicamento", c => c.String());
            DropForeignKey("dbo.MedicamentoVencido", "IdMedicamento", "dbo.Medicamento");
            DropForeignKey("dbo.InventarioFinMes", "IdMedicamento", "dbo.Medicamento");
            DropForeignKey("dbo.Arqueo", "IdMedicamento", "dbo.Medicamento");
            DropIndex("dbo.MedicamentoVencido", new[] { "IdMedicamento" });
            DropIndex("dbo.InventarioFinMes", new[] { "IdMedicamento" });
            DropIndex("dbo.Arqueo", new[] { "IdMedicamento" });
            DropColumn("dbo.InventarioFinMes", "IdMedicamento");
            DropTable("dbo.MedicamentoVencido");
            DropTable("dbo.Arqueo");
        }
    }
}
