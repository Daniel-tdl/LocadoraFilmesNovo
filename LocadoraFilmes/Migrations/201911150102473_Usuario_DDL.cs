namespace LocadoraFilmes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Usuario_DDL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 200),
                        Senha = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioID)
                .Index(t => t.Nome, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Usuario", new[] { "Nome" });
            DropTable("dbo.Usuario");
        }
    }
}
