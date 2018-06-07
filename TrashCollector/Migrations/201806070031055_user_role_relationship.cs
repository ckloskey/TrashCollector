namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_role_relationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserRole_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "UserRole_Id");
            AddForeignKey("dbo.AspNetUsers", "UserRole_Id", "dbo.AspNetRoles", "Id");
            DropColumn("dbo.AspNetUsers", "UserRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserRole", c => c.String());
            DropForeignKey("dbo.AspNetUsers", "UserRole_Id", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUsers", new[] { "UserRole_Id" });
            DropColumn("dbo.AspNetUsers", "UserRole_Id");
        }
    }
}
