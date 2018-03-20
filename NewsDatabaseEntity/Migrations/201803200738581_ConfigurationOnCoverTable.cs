namespace NewsDatabaseEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigurationOnCoverTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Covers", "Path", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Covers", "Path", c => c.String());
        }
    }
}
