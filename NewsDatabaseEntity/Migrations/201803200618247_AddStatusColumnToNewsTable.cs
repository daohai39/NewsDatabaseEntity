namespace NewsDatabaseEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusColumnToNewsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "Status");
        }
    }
}
