namespace NewsDatabaseEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigurationOnNewsTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TagNews", newName: "NewsTags");
            DropForeignKey("dbo.News", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.News", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Authors", "Id", "dbo.Covers");
            DropIndex("dbo.Authors", new[] { "Id" });
            RenameColumn(table: "dbo.NewsTags", name: "Tag_Id", newName: "TagId");
            RenameColumn(table: "dbo.NewsTags", name: "News_Id", newName: "NewsId");
            RenameIndex(table: "dbo.NewsTags", name: "IX_News_Id", newName: "IX_NewsId");
            RenameIndex(table: "dbo.NewsTags", name: "IX_Tag_Id", newName: "IX_TagId");
            DropPrimaryKey("dbo.Authors");
            DropPrimaryKey("dbo.Covers");
            DropPrimaryKey("dbo.NewsTags");
            AlterColumn("dbo.Authors", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Covers", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.News", "Title", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.News", "Slug", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.News", "Content", c => c.String(nullable: false, maxLength: 2000));
            AddPrimaryKey("dbo.Authors", "Id");
            AddPrimaryKey("dbo.Covers", "Id");
            AddPrimaryKey("dbo.NewsTags", new[] { "NewsId", "TagId" });
            CreateIndex("dbo.Covers", "Id");
            AddForeignKey("dbo.News", "CategoryId", "dbo.Categories", "Id");
            AddForeignKey("dbo.Covers", "Id", "dbo.Authors", "Id");
            AddForeignKey("dbo.News", "AuthorId", "dbo.Authors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Covers", "Id", "dbo.Authors");
            DropForeignKey("dbo.News", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Covers", new[] { "Id" });
            DropPrimaryKey("dbo.NewsTags");
            DropPrimaryKey("dbo.Covers");
            DropPrimaryKey("dbo.Authors");
            AlterColumn("dbo.News", "Content", c => c.String());
            AlterColumn("dbo.News", "Slug", c => c.String());
            AlterColumn("dbo.News", "Title", c => c.String());
            AlterColumn("dbo.Covers", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Authors", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.NewsTags", new[] { "Tag_Id", "News_Id" });
            AddPrimaryKey("dbo.Covers", "Id");
            AddPrimaryKey("dbo.Authors", "Id");
            RenameIndex(table: "dbo.NewsTags", name: "IX_TagId", newName: "IX_Tag_Id");
            RenameIndex(table: "dbo.NewsTags", name: "IX_NewsId", newName: "IX_News_Id");
            RenameColumn(table: "dbo.NewsTags", name: "NewsId", newName: "News_Id");
            RenameColumn(table: "dbo.NewsTags", name: "TagId", newName: "Tag_Id");
            CreateIndex("dbo.Authors", "Id");
            AddForeignKey("dbo.Authors", "Id", "dbo.Covers", "Id");
            AddForeignKey("dbo.News", "AuthorId", "dbo.Authors", "Id");
            AddForeignKey("dbo.News", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.NewsTags", newName: "TagNews");
        }
    }
}
