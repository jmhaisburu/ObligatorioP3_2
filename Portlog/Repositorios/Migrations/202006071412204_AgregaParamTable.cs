namespace Repositorios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregaParamTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parametroes",
                c => new
                    {
                        Nombre = c.String(nullable: false, maxLength: 128),
                        Valor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Nombre);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Parametroes");
        }
    }
}
