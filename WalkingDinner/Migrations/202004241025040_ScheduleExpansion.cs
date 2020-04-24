namespace WalkingDinner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleExpansion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "Title", c => c.String());
            AddColumn("dbo.Schedules", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "Date");
            DropColumn("dbo.Schedules", "Title");
        }
    }
}
