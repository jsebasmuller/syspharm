namespace SysPharm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Eps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Formula",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FechaFormula = c.DateTime(nullable: false),
                        FechaDespacho = c.DateTime(nullable: false),
                        IdMedico = c.String(maxLength: 128),
                        IdPaciente = c.String(maxLength: 128),
                        IdServicio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.IdMedico)
                .ForeignKey("dbo.Usuario", t => t.IdPaciente)
                .ForeignKey("dbo.Servicio", t => t.IdServicio, cascadeDelete: true)
                .Index(t => t.IdMedico)
                .Index(t => t.IdPaciente)
                .Index(t => t.IdServicio);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Documento = c.String(nullable: false, maxLength: 128),
                        IdTipoDocumento = c.Int(nullable: false),
                        Nombres = c.String(maxLength: 250),
                        Direccion = c.String(maxLength: 100),
                        Telefono = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Documento)
                .ForeignKey("dbo.TipoDocumento", t => t.IdTipoDocumento, cascadeDelete: true)
                .Index(t => t.IdTipoDocumento);
            
            CreateTable(
                "dbo.TipoDocumento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Servicio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingreso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Medicamento",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FechaPedido = c.DateTime(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false),
                        RegSanitario = c.String(),
                        Lote = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Proveedor = c.String(maxLength: 250),
                        FechaPedido = c.DateTime(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Formula", "IdServicio", "dbo.Servicio");
            DropForeignKey("dbo.Formula", "IdPaciente", "dbo.Usuario");
            DropForeignKey("dbo.Formula", "IdMedico", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "IdTipoDocumento", "dbo.TipoDocumento");
            DropIndex("dbo.Usuario", new[] { "IdTipoDocumento" });
            DropIndex("dbo.Formula", new[] { "IdServicio" });
            DropIndex("dbo.Formula", new[] { "IdPaciente" });
            DropIndex("dbo.Formula", new[] { "IdMedico" });
            DropTable("dbo.Pedido");
            DropTable("dbo.Medicamento");
            DropTable("dbo.Ingreso");
            DropTable("dbo.Servicio");
            DropTable("dbo.TipoDocumento");
            DropTable("dbo.Usuario");
            DropTable("dbo.Formula");
            DropTable("dbo.Eps");
        }
    }
}
