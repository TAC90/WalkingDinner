namespace WalkingDinner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scheduleupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "Program", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "Program");
        }
    }
}
