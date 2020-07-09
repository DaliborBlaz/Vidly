namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES('Action')");
            Sql("INSERT INTO Genres (Name) VALUES('Thriller')");
            Sql("INSERT INTO Genres (Name) VALUES('Famuly')");
            Sql("INSERT INTO Genres (Name) VALUES('Romance')");
            Sql("INSERT INTO Genres (Name) VALUES('Comdey')");


        }

        public override void Down()
        {
        }
    }
}
