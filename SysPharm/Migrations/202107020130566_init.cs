namespace Proyecto_Farmacia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetalleFormula",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdFormula = c.String(maxLength: 128),
                        IdMedicamento = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioCompra = c.Double(nullable: false),
                        PrecioVenta = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Formula", t => t.IdFormula)
                .ForeignKey("dbo.Medicamento", t => t.IdMedicamento, cascadeDelete: true)
                .Index(t => t.IdFormula)
                .Index(t => t.IdMedicamento);
            
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
                        TotalMedicamentos = c.Int(nullable: false),
                        TotalCompra = c.Double(nullable: false),
                        TotalVenta = c.Double(nullable: false),
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
                        IdEps = c.Int(nullable: false),
                        Nombres = c.String(maxLength: 250),
                        Direccion = c.String(maxLength: 100),
                        Telefono = c.String(maxLength: 10),
                        TipoUsuario = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Documento)
                .ForeignKey("dbo.Eps", t => t.IdEps, cascadeDelete: true)
                .ForeignKey("dbo.TipoDocumento", t => t.IdTipoDocumento, cascadeDelete: true)
                .Index(t => t.IdTipoDocumento)
                .Index(t => t.IdEps);
            
            CreateTable(
                "dbo.Eps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Medicamento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 500),
                        Cantidad = c.Int(nullable: false),
                        VlrCompra = c.Double(nullable: false),
                        VlrVenta = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetallePedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdMedicamento = c.Int(nullable: false),
                        IdPedido = c.String(maxLength: 128),
                        Lote = c.String(maxLength: 50),
                        RegSanitario = c.String(maxLength: 50),
                        CUM = c.String(maxLength: 50),
                        Cantidad = c.Int(nullable: false),
                        VlrCompra = c.Double(nullable: false),
                        VlrVenta = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicamento", t => t.IdMedicamento, cascadeDelete: true)
                .ForeignKey("dbo.Pedido", t => t.IdPedido)
                .Index(t => t.IdMedicamento)
                .Index(t => t.IdPedido);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Proveedor = c.String(maxLength: 250),
                        FechaPedido = c.DateTime(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false),
                        VlrTotal = c.Double(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalleFormula", "IdMedicamento", "dbo.Medicamento");
            DropForeignKey("dbo.DetallePedido", "IdPedido", "dbo.Pedido");
            DropForeignKey("dbo.DetallePedido", "IdMedicamento", "dbo.Medicamento");
            DropForeignKey("dbo.DetalleFormula", "IdFormula", "dbo.Formula");
            DropForeignKey("dbo.Formula", "IdServicio", "dbo.Servicio");
            DropForeignKey("dbo.Formula", "IdPaciente", "dbo.Usuario");
            DropForeignKey("dbo.Formula", "IdMedico", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "IdTipoDocumento", "dbo.TipoDocumento");
            DropForeignKey("dbo.Usuario", "IdEps", "dbo.Eps");
            DropIndex("dbo.DetallePedido", new[] { "IdPedido" });
            DropIndex("dbo.DetallePedido", new[] { "IdMedicamento" });
            DropIndex("dbo.Usuario", new[] { "IdEps" });
            DropIndex("dbo.Usuario", new[] { "IdTipoDocumento" });
            DropIndex("dbo.Formula", new[] { "IdServicio" });
            DropIndex("dbo.Formula", new[] { "IdPaciente" });
            DropIndex("dbo.Formula", new[] { "IdMedico" });
            DropIndex("dbo.DetalleFormula", new[] { "IdMedicamento" });
            DropIndex("dbo.DetalleFormula", new[] { "IdFormula" });
            DropTable("dbo.Ingreso");
            DropTable("dbo.Pedido");
            DropTable("dbo.DetallePedido");
            DropTable("dbo.Medicamento");
            DropTable("dbo.Servicio");
            DropTable("dbo.TipoDocumento");
            DropTable("dbo.Eps");
            DropTable("dbo.Usuario");
            DropTable("dbo.Formula");
            DropTable("dbo.DetalleFormula");
        }
    }
}
