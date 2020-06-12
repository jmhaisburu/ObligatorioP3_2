namespace Repositorios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Rut = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Rut);
            
            CreateTable(
                "dbo.Importacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaIngreso = c.DateTime(nullable: false),
                        SalidaPrevista = c.DateTime(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Producto_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Producto", t => t.Producto_Codigo)
                .Index(t => t.Producto_Codigo);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        Codigo = c.Int(nullable: false),
                        Nombre = c.String(),
                        Peso = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cliente_Rut = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Cliente", t => t.Cliente_Rut)
                .Index(t => t.Cliente_Rut);
            
            CreateTable(
                "dbo.Parametro",
                c => new
                    {
                        Nombre = c.String(nullable: false, maxLength: 128),
                        Valor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Nombre);
            
            CreateTable(
                "dbo.Salida",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Matricula = c.String(),
                        Direccion = c.String(),
                        FechaSalida = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
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
            DropForeignKey("dbo.Importacion", "Producto_Codigo", "dbo.Producto");
            DropForeignKey("dbo.Producto", "Cliente_Rut", "dbo.Cliente");
            DropIndex("dbo.Producto", new[] { "Cliente_Rut" });
            DropIndex("dbo.Importacion", new[] { "Producto_Codigo" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Salida");
            DropTable("dbo.Parametro");
            DropTable("dbo.Producto");
            DropTable("dbo.Importacion");
            DropTable("dbo.Cliente");
        }
    }
}
