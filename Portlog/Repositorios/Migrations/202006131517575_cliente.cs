namespace Repositorios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cliente : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Producto", "Cliente_Rut", "dbo.Cliente");
            DropIndex("dbo.Producto", new[] { "Cliente_Rut" });
            DropPrimaryKey("dbo.Cliente");
            AlterColumn("dbo.Cliente", "Rut", c => c.String(nullable: false, maxLength: 12));
            AlterColumn("dbo.Cliente", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Producto", "Cliente_Rut", c => c.String(maxLength: 12));
            AddPrimaryKey("dbo.Cliente", "Rut");
            CreateIndex("dbo.Producto", "Cliente_Rut");
            AddForeignKey("dbo.Producto", "Cliente_Rut", "dbo.Cliente", "Rut");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Producto", "Cliente_Rut", "dbo.Cliente");
            DropIndex("dbo.Producto", new[] { "Cliente_Rut" });
            DropPrimaryKey("dbo.Cliente");
            AlterColumn("dbo.Producto", "Cliente_Rut", c => c.String(maxLength: 128));
            AlterColumn("dbo.Cliente", "Nombre", c => c.String());
            AlterColumn("dbo.Cliente", "Rut", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Cliente", "Rut");
            CreateIndex("dbo.Producto", "Cliente_Rut");
            AddForeignKey("dbo.Producto", "Cliente_Rut", "dbo.Cliente", "Rut");
        }
    }
}
