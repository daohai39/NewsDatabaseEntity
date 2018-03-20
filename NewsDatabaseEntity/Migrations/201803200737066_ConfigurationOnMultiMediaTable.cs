namespace NewsDatabaseEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigurationOnMultiMediaTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MultiMedias", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.MultiMedias", "FilePath", c => c.String(nullable: false));
            AlterColumn("dbo.MultiMedias", "FileType", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MultiMedias", "FileType", c => c.String());
            AlterColumn("dbo.MultiMedias", "FilePath", c => c.String());
            AlterColumn("dbo.MultiMedias", "Name", c => c.String());
        }
    }
}
