namespace Proyecto_Farmacia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInventarioFinMes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InventarioFinMes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        NombreMedicamento = c.String(),
                        Cantidad = c.Int(nullable: false),
                        ValorCompra = c.Double(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InventarioFinMes");
        }
    }
}
