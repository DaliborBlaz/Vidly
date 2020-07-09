namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateOfBirth3Customer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
