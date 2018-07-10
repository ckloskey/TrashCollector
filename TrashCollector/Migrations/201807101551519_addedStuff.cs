namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedStuff : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "NextPickup", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "NextPickup", c => c.String());
        }
    }
}
