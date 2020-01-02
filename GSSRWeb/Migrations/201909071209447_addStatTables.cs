namespace GSSRWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStatTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserActorVisits",
                c => new
                    {
                        UserActorVisitsId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        ActorIdVisit = c.Int(nullable: false),
                        VisitDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserActorVisitsId);
            
            CreateTable(
                "dbo.UserMovieVisits",
                c => new
                    {
                        UserMovieVisitsId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        MovieIdVisit = c.Int(nullable: false),
                        VisitDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserMovieVisitsId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserMovieVisits");
            DropTable("dbo.UserActorVisits");
        }
    }
}
