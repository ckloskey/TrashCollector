namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_role_relationship2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "UserRole_Id", newName: "IdentiyRole_Id");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_UserRole_Id", newName: "IX_IdentiyRole_Id");
            AddColumn("dbo.AspNetUsers", "UserRole", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserRole");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_IdentiyRole_Id", newName: "IX_UserRole_Id");
            RenameColumn(table: "dbo.AspNetUsers", name: "IdentiyRole_Id", newName: "UserRole_Id");
        }
    }
}
