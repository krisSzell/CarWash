namespace CarWash.Persistence.Migrations.LoggingDbContext
{
    using System.Data.Entity.Migrations;

    public partial class AddedFullLogModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FullLogs",
                c => new
                    {
                        FullLogId = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(nullable: false),
                        UserResponsible = c.String(),
                        OperationMade = c.String(),
                    })
                .PrimaryKey(t => t.FullLogId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FullLogs");
        }
    }
}
