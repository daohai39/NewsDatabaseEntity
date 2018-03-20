namespace NewsDatabaseEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigurationOnCategoryTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String());
        }
    }
}
