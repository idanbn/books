namespace GSSRWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addActorLocation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActorLocation",
                c => new
                    {
                        ActorLocationId = c.Int(nullable: false, identity: true),
                        ActorId = c.Int(nullable: false),
                        Lat = c.Double(nullable: false),
                        Long = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ActorLocationId)
                .ForeignKey("dbo.Actor", t => t.ActorId, cascadeDelete: true)
                .Index(t => t.ActorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActorLocation", "ActorId", "dbo.Actor");
            DropIndex("dbo.ActorLocation", new[] { "ActorId" });
            DropTable("dbo.ActorLocation");
        }
    }
}
