namespace Repositorios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class borrarParametro : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Parametro");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Parametro",
                c => new
                    {
                        Nombre = c.String(nullable: false, maxLength: 128),
                        Valor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Nombre);
            
        }
    }
}
