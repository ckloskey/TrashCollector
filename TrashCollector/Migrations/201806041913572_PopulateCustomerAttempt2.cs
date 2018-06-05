namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomerAttempt2 : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Customers DROP COLUMN LastPickupConfirmed");
            Sql("INSERT INTO Customers(FirstName, LastName, Address, Login, Password, ZipCode, PickupDay, AccountBalance) VALUES ('Craig', 'Kloskey', '123 Main St', 'cklos', 'password', 53202, 1, 0)");
        }
        
        public override void Down()
        {
        }
    }
}
