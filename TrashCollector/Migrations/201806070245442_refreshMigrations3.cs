namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refreshMigrations3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Customer_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Customer_Id");
            AddForeignKey("dbo.AspNetUsers", "Customer_Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.AspNetUsers", new[] { "Customer_Id" });
            DropColumn("dbo.AspNetUsers", "Customer_Id");
        }
    }
}
