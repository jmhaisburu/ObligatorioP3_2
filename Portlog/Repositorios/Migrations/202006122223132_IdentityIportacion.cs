namespace Repositorios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityIportacion : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Importacion");
            AlterColumn("dbo.Importacion", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Importacion", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Importacion");
            AlterColumn("dbo.Importacion", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Importacion", "Id");
        }
    }
}
