namespace Repositorios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class impoEnSalida : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salida", "Importacion_IdImp", c => c.Int());
            CreateIndex("dbo.Salida", "Importacion_IdImp");
            AddForeignKey("dbo.Salida", "Importacion_IdImp", "dbo.Importacion", "IdImp");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salida", "Importacion_IdImp", "dbo.Importacion");
            DropIndex("dbo.Salida", new[] { "Importacion_IdImp" });
            DropColumn("dbo.Salida", "Importacion_IdImp");
        }
    }
}
