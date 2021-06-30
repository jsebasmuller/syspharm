namespace SysPharm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTipoUsuarioInUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "TipoUsuario", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "TipoUsuario");
        }
    }
}
