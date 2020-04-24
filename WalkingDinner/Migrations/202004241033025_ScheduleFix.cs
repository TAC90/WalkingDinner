namespace WalkingDinner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "Organizer_PersonID", c => c.Int(nullable: false));
            AlterColumn("dbo.Schedules", "Title", c => c.String(nullable: false));
            CreateIndex("dbo.Schedules", "Organizer_PersonID");
            AddForeignKey("dbo.Schedules", "Organizer_PersonID", "dbo.People", "PersonID", cascadeDelete: true);
            DropColumn("dbo.Schedules", "GatherAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "GatherAddress", c => c.String());
            DropForeignKey("dbo.Schedules", "Organizer_PersonID", "dbo.People");
            DropIndex("dbo.Schedules", new[] { "Organizer_PersonID" });
            AlterColumn("dbo.Schedules", "Title", c => c.String());
            DropColumn("dbo.Schedules", "Organizer_PersonID");
        }
    }
}
