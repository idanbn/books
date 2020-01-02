namespace GSSRWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixReview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Review", "UserName", c => c.String(nullable: false));
            DropColumn("dbo.Review", "AccountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Review", "AccountId", c => c.Int(nullable: false));
            DropColumn("dbo.Review", "UserName");
        }
    }
}
