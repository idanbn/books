namespace GSSRWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Actor", "ActorIMDBPage", c => c.String(nullable: false));
            DropColumn("dbo.Movie", "MovieRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movie", "MovieRating", c => c.Int(nullable: false));
            AlterColumn("dbo.Actor", "ActorIMDBPage", c => c.String());
        }
    }
}
