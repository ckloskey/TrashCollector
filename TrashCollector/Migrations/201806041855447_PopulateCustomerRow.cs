namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomerRow : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customer(Id, FirstName, LastName, Address, Login, Password, ZipCode, PickUpDay, AccountBalance) VALUES(1, Craig, Kloskey, 123 Main st, cklos, password, 1, 0)");
        }
        
        public override void Down()
        {
        }
    }
}
