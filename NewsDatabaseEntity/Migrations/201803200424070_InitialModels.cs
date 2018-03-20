namespace NewsDatabaseEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MultiMedias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        FilePath = c.String(),
                        FileSize = c.Double(nullable: false),
                        FileType = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        NewsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.News", t => t.NewsId, cascadeDelete: true)
                .Index(t => t.NewsId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Slug = c.String(),
                        Content = c.String(),
                        AuthorId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagNews",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        News_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.News_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.News", t => t.News_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.News_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagNews", "News_Id", "dbo.News");
            DropForeignKey("dbo.TagNews", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.MultiMedias", "NewsId", "dbo.News");
            DropForeignKey("dbo.News", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.News", "AuthorId", "dbo.Authors");
            DropIndex("dbo.TagNews", new[] { "News_Id" });
            DropIndex("dbo.TagNews", new[] { "Tag_Id" });
            DropIndex("dbo.News", new[] { "CategoryId" });
            DropIndex("dbo.News", new[] { "AuthorId" });
            DropIndex("dbo.MultiMedias", new[] { "NewsId" });
            DropTable("dbo.TagNews");
            DropTable("dbo.Tags");
            DropTable("dbo.News");
            DropTable("dbo.MultiMedias");
            DropTable("dbo.Categories");
            DropTable("dbo.Authors");
        }
    }
}
