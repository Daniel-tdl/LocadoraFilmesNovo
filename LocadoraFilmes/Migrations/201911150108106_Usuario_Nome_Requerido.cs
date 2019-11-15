namespace LocadoraFilmes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Usuario_Nome_Requerido : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Usuario", new[] { "Nome" });
            AlterColumn("dbo.Usuario", "Nome", c => c.String(nullable: false, maxLength: 200));
            CreateIndex("dbo.Usuario", "Nome", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Usuario", new[] { "Nome" });
            AlterColumn("dbo.Usuario", "Nome", c => c.String(maxLength: 200));
            CreateIndex("dbo.Usuario", "Nome", unique: true);
        }
    }
}
