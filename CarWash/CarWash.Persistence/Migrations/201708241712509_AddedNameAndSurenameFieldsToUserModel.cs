namespace CarWash.Persistence.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedNameAndSurenameFieldsToUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "Sureame", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Sureame");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
