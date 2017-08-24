namespace CarWash.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedScheduleModelAndOneToManyWithReservations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleId);
            
            AddColumn("dbo.Reservations", "Schedule_ScheduleId", c => c.Int());
            CreateIndex("dbo.Reservations", "Schedule_ScheduleId");
            AddForeignKey("dbo.Reservations", "Schedule_ScheduleId", "dbo.Schedules", "ScheduleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "Schedule_ScheduleId", "dbo.Schedules");
            DropIndex("dbo.Reservations", new[] { "Schedule_ScheduleId" });
            DropColumn("dbo.Reservations", "Schedule_ScheduleId");
            DropTable("dbo.Schedules");
        }
    }
}
