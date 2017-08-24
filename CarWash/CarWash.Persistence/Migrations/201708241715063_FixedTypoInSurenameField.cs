namespace CarWash.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedTypoInSurenameField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Surename", c => c.String());
            DropColumn("dbo.AspNetUsers", "Sureame");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Sureame", c => c.String());
            DropColumn("dbo.AspNetUsers", "Surename");
        }
    }
}
