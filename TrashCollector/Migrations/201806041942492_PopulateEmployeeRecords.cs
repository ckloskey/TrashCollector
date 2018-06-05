namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateEmployeeRecords : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Employees(FirstName, LastName, Login, Password) VALUES ('employee', 'employee', 'employee', 'password')");
        }
        
        public override void Down()
        {
        }
    }
}
