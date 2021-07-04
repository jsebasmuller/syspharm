namespace Proyecto_Farmacia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCantidadFormula : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetalleFormula", "CantidadFormula", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DetalleFormula", "CantidadFormula");
        }
    }
}
