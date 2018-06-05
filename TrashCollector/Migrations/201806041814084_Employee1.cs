namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
            AlterColumn("dbo.Customers", "LastName", c => c.String());
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
            AlterColumn("dbo.Employees", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "LastName", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "FirstName", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "LastName", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "FirstName", c => c.Int(nullable: false));
        }
    }
}
