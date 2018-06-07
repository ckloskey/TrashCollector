namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refreshMigrations1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "IdentiyRole_Id", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUsers", new[] { "IdentiyRole_Id" });
            DropColumn("dbo.AspNetUsers", "IdentiyRole_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "IdentiyRole_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "IdentiyRole_Id");
            AddForeignKey("dbo.AspNetUsers", "IdentiyRole_Id", "dbo.AspNetRoles", "Id");
        }
    }
}
