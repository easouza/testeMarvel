namespace testeBuscaMarvel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personagems",
                c => new
                    {
                        idPersonagem = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Historias = c.String(),
                        Imagem = c.String(),
                    })
                .PrimaryKey(t => t.idPersonagem);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Personagems");
        }
    }
}
