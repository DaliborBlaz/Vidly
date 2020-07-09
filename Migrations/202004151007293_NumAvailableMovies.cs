namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumAvailableMovies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        RentalId = c.Int(nullable: false, identity: true),
                        DateReturned = c.DateTime(nullable: false),
                        DateRented = c.DateTime(nullable: false),
                        Customers_CustomerId = c.Int(nullable: false),
                        Movies_MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RentalId)
                .ForeignKey("dbo.Customers", t => t.Customers_CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movies_MovieId, cascadeDelete: true)
                .Index(t => t.Customers_CustomerId)
                .Index(t => t.Movies_MovieId);
            
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Int(nullable: false));
            Sql("UPDATE Movies SET NumberAvailable=NumberInStock");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Movies_MovieId", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "Customers_CustomerId", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Movies_MovieId" });
            DropIndex("dbo.Rentals", new[] { "Customers_CustomerId" });
            DropColumn("dbo.Movies", "NumberAvailable");
            DropTable("dbo.Rentals");
        }
    }
}
