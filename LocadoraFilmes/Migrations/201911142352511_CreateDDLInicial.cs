namespace LocadoraFilmes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDDLInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Filme",
                c => new
                    {
                        FilmeID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                        GeneroID = c.Int(nullable: false),
                        Locacao_LocacaoID = c.Int(),
                    })
                .PrimaryKey(t => t.FilmeID)
                .ForeignKey("dbo.Genero", t => t.GeneroID, cascadeDelete: true)
                .ForeignKey("dbo.Locacao", t => t.Locacao_LocacaoID)
                .Index(t => t.GeneroID)
                .Index(t => t.Locacao_LocacaoID);
            
            CreateTable(
                "dbo.Genero",
                c => new
                    {
                        GeneroID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GeneroID);
            
            CreateTable(
                "dbo.Locacao",
                c => new
                    {
                        LocacaoID = c.Int(nullable: false, identity: true),
                        CPF = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LocacaoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Filme", "Locacao_LocacaoID", "dbo.Locacao");
            DropForeignKey("dbo.Filme", "GeneroID", "dbo.Genero");
            DropIndex("dbo.Filme", new[] { "Locacao_LocacaoID" });
            DropIndex("dbo.Filme", new[] { "GeneroID" });
            DropTable("dbo.Locacao");
            DropTable("dbo.Genero");
            DropTable("dbo.Filme");
        }
    }
}
