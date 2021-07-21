namespace Proyecto_Farmacia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Arqueo", "FechaArqueo", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Arqueo", "FechaArqueo");
        }
    }
}
