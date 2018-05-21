namespace testeBuscaMarvel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HistoricoBuscas",
                c => new
                    {
                        IdHistoricoBusca = c.Int(nullable: false, identity: true),
                        personagemBuscado = c.String(),
                        HoraDaBusca = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdHistoricoBusca);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HistoricoBuscas");
        }
    }
}
