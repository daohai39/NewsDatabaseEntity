namespace NewsDatabaseEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStatusColumnToByteInNewsTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "Status", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "Status", c => c.String());
        }
    }
}
