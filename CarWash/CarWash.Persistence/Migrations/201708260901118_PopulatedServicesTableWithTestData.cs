namespace CarWash.Persistence.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulatedServicesTableWithTestData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Services (Name,Price,DurationInMinutes) VALUES ('Br¹zowy', '10', '15')");
            Sql("INSERT INTO Services (Name,Price,DurationInMinutes) VALUES ('Srebrny', '15', '30')");
            Sql("INSERT INTO Services (Name,Price,DurationInMinutes) VALUES ('Z³oty', '20', '30')");
            Sql("INSERT INTO Services (Name,Price,DurationInMinutes) VALUES ('Platynowy', '30', '45')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Services WHERE Name = 'Br¹zowy'");
            Sql("DELETE FROM Services WHERE Name = 'Srebrny'");
            Sql("DELETE FROM Services WHERE Name = 'Z³oty'");
            Sql("DELETE FROM Services WHERE Name = 'Platynowy'");
        }
    }
}
