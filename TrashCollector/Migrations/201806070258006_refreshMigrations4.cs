namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refreshMigrations4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.AspNetUsers", new[] { "Customer_Id" });
            AddColumn("dbo.Customers", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "User_Id");
            AddForeignKey("dbo.Customers", "User_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "Customer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Customer_Id", c => c.Int());
            DropForeignKey("dbo.Customers", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "User_Id" });
            DropColumn("dbo.Customers", "User_Id");
            CreateIndex("dbo.AspNetUsers", "Customer_Id");
            AddForeignKey("dbo.AspNetUsers", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
