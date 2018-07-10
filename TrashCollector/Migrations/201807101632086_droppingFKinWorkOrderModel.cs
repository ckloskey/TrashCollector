namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class droppingFKinWorkOrderModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkOrders", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.WorkOrders", new[] { "EmployeeId" });
            DropColumn("dbo.WorkOrders", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkOrders", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.WorkOrders", "EmployeeId");
            AddForeignKey("dbo.WorkOrders", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}
