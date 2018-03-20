namespace NewsDatabaseEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigurationOnAuthorTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.News", "AuthorId", "dbo.Authors");
            DropPrimaryKey("dbo.Authors");
            CreateTable(
                "dbo.Covers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Authors", "CoverId", c => c.Int(nullable: false));
            AlterColumn("dbo.Authors", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Authors", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Authors", "Email", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Authors", "Address", c => c.String(maxLength: 500));
            AddPrimaryKey("dbo.Authors", "Id");
            CreateIndex("dbo.Authors", "Id");
            AddForeignKey("dbo.Authors", "Id", "dbo.Covers", "Id");
            AddForeignKey("dbo.News", "AuthorId", "dbo.Authors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Authors", "Id", "dbo.Covers");
            DropIndex("dbo.Authors", new[] { "Id" });
            DropPrimaryKey("dbo.Authors");
            AlterColumn("dbo.Authors", "Address", c => c.String());
            AlterColumn("dbo.Authors", "Email", c => c.String());
            AlterColumn("dbo.Authors", "Name", c => c.String());
            AlterColumn("dbo.Authors", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Authors", "CoverId");
            DropTable("dbo.Covers");
            AddPrimaryKey("dbo.Authors", "Id");
            AddForeignKey("dbo.News", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
        }
    }
}
