namespace CarWash.Persistence.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedUserIdFieldToReservationModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "UserId");
        }
    }
}
