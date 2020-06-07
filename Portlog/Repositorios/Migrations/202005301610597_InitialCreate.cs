namespace Repositorios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Rut = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Rut);
            
            CreateTable(
                "dbo.Importacions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaIngreso = c.DateTime(nullable: false),
                        SalidaPrevista = c.DateTime(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Producto_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Productoes", t => t.Producto_Codigo)
                .Index(t => t.Producto_Codigo);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Peso = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cliente_Rut = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Rut)
                .Index(t => t.Cliente_Rut);
            
            CreateTable(
                "dbo.Salidas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Matricula = c.String(),
                        Direccion = c.String(),
                        FechaSalida = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Ci = c.String(nullable: false, maxLength: 128),
                        Rol = c.String(),
                        Pass = c.String(),
                    })
                .PrimaryKey(t => t.Ci);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Importacions", "Producto_Codigo", "dbo.Productoes");
            DropForeignKey("dbo.Productoes", "Cliente_Rut", "dbo.Clientes");
            DropIndex("dbo.Productoes", new[] { "Cliente_Rut" });
            DropIndex("dbo.Importacions", new[] { "Producto_Codigo" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Salidas");
            DropTable("dbo.Productoes");
            DropTable("dbo.Importacions");
            DropTable("dbo.Clientes");
        }
    }
}
