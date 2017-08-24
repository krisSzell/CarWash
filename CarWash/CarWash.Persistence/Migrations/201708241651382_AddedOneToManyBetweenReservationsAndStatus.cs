namespace CarWash.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOneToManyBetweenReservationsAndStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsAccepted = c.Boolean(nullable: false),
                        IsArchived = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Reservations", "Status_Id", c => c.Int());
            CreateIndex("dbo.Reservations", "Status_Id");
            AddForeignKey("dbo.Reservations", "Status_Id", "dbo.Status", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "Status_Id", "dbo.Status");
            DropIndex("dbo.Reservations", new[] { "Status_Id" });
            DropColumn("dbo.Reservations", "Status_Id");
            DropTable("dbo.Status");
        }
    }
}
