namespace Repositorios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idImp : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Importacion");
            AddColumn("dbo.Importacion", "IdImp", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Importacion", "IdImp");
            DropColumn("dbo.Importacion", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Importacion", "Id", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Importacion");
            DropColumn("dbo.Importacion", "IdImp");
            AddPrimaryKey("dbo.Importacion", "Id");
        }
    }
}
