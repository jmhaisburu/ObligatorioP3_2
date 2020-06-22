namespace Repositorios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clienteSalida : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salida", "Usuario_Ci", c => c.String(maxLength: 128));
            CreateIndex("dbo.Salida", "Usuario_Ci");
            AddForeignKey("dbo.Salida", "Usuario_Ci", "dbo.Usuario", "Ci");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salida", "Usuario_Ci", "dbo.Usuario");
            DropIndex("dbo.Salida", new[] { "Usuario_Ci" });
            DropColumn("dbo.Salida", "Usuario_Ci");
        }
    }
}
