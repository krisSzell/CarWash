namespace CarWash.Persistence.Migrations.LoggingDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDetailsFieldToFullLogModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FullLogs", "Details", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FullLogs", "Details");
        }
    }
}
