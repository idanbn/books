namespace GSSRWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actor",
                c => new
                    {
                        ActorId = c.Int(nullable: false, identity: true),
                        ActorName = c.String(nullable: false, maxLength: 100),
                        PlaceOfBirth = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        ActorIMDBPage = c.String(),
                    })
                .PrimaryKey(t => t.ActorId);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        MovieName = c.String(nullable: false, maxLength: 100),
                        YearOfPublish = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                        MovieRating = c.Int(nullable: false),
                        MovieDuration = c.Int(nullable: false),
                        YoutubeId = c.String(),
                        Summary = c.String(nullable: false, maxLength: 2000),
                        PictureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId)
                .ForeignKey("dbo.Genre", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Picture", t => t.PictureId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.PictureId);
            
            CreateTable(
                "dbo.Director",
                c => new
                    {
                        DirectorId = c.Int(nullable: false, identity: true),
                        DirectorName = c.String(nullable: false, maxLength: 100),
                        PlaceOfBirth = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DirectorId);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Picture",
                c => new
                    {
                        PictureId = c.Int(nullable: false, identity: true),
                        PictureName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PictureId);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        ReviewText = c.String(nullable: false, maxLength: 400),
                        ReviewRating = c.Int(nullable: false),
                        ReviewDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Writer",
                c => new
                    {
                        WriterId = c.Int(nullable: false, identity: true),
                        WriterName = c.String(nullable: false, maxLength: 100),
                        PlaceOfBirth = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.WriterId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MovieActor",
                c => new
                    {
                        Movie_MovieId = c.Int(nullable: false),
                        Actor_ActorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_MovieId, t.Actor_ActorId })
                .ForeignKey("dbo.Movie", t => t.Movie_MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Actor", t => t.Actor_ActorId, cascadeDelete: true)
                .Index(t => t.Movie_MovieId)
                .Index(t => t.Actor_ActorId);
            
            CreateTable(
                "dbo.DirectorMovie",
                c => new
                    {
                        Director_DirectorId = c.Int(nullable: false),
                        Movie_MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Director_DirectorId, t.Movie_MovieId })
                .ForeignKey("dbo.Director", t => t.Director_DirectorId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.Movie_MovieId, cascadeDelete: true)
                .Index(t => t.Director_DirectorId)
                .Index(t => t.Movie_MovieId);
            
            CreateTable(
                "dbo.WriterMovie",
                c => new
                    {
                        Writer_WriterId = c.Int(nullable: false),
                        Movie_MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Writer_WriterId, t.Movie_MovieId })
                .ForeignKey("dbo.Writer", t => t.Writer_WriterId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.Movie_MovieId, cascadeDelete: true)
                .Index(t => t.Writer_WriterId)
                .Index(t => t.Movie_MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.WriterMovie", "Movie_MovieId", "dbo.Movie");
            DropForeignKey("dbo.WriterMovie", "Writer_WriterId", "dbo.Writer");
            DropForeignKey("dbo.Review", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.Movie", "PictureId", "dbo.Picture");
            DropForeignKey("dbo.Movie", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.DirectorMovie", "Movie_MovieId", "dbo.Movie");
            DropForeignKey("dbo.DirectorMovie", "Director_DirectorId", "dbo.Director");
            DropForeignKey("dbo.MovieActor", "Actor_ActorId", "dbo.Actor");
            DropForeignKey("dbo.MovieActor", "Movie_MovieId", "dbo.Movie");
            DropIndex("dbo.WriterMovie", new[] { "Movie_MovieId" });
            DropIndex("dbo.WriterMovie", new[] { "Writer_WriterId" });
            DropIndex("dbo.DirectorMovie", new[] { "Movie_MovieId" });
            DropIndex("dbo.DirectorMovie", new[] { "Director_DirectorId" });
            DropIndex("dbo.MovieActor", new[] { "Actor_ActorId" });
            DropIndex("dbo.MovieActor", new[] { "Movie_MovieId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Review", new[] { "MovieId" });
            DropIndex("dbo.Movie", new[] { "PictureId" });
            DropIndex("dbo.Movie", new[] { "GenreId" });
            DropTable("dbo.WriterMovie");
            DropTable("dbo.DirectorMovie");
            DropTable("dbo.MovieActor");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Writer");
            DropTable("dbo.Review");
            DropTable("dbo.Picture");
            DropTable("dbo.Genre");
            DropTable("dbo.Director");
            DropTable("dbo.Movie");
            DropTable("dbo.Actor");
        }
    }
}
