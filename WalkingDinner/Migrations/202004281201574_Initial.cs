namespace WalkingDinner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        ParticipantID = c.Int(nullable: false, identity: true),
                        Solo = c.Boolean(nullable: false),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        FirstNamePartner = c.String(),
                        MiddleNamePartner = c.String(),
                        LastNamePartner = c.String(),
                        ZipCode = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        TelephoneNumber = c.String(nullable: false),
                        DietComments = c.String(),
                    })
                .PrimaryKey(t => t.ParticipantID);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleID = c.Int(nullable: false, identity: true),
                        Active = c.Boolean(nullable: false),
                        Title = c.String(nullable: false),
                        Date = c.DateTime(),
                        GroupSize = c.Int(nullable: false),
                        MaxParticipants = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleID);
            
            CreateTable(
                "dbo.ScheduleParticipants",
                c => new
                    {
                        Schedule_ScheduleID = c.Int(nullable: false),
                        Participant_ParticipantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Schedule_ScheduleID, t.Participant_ParticipantID })
                .ForeignKey("dbo.Schedules", t => t.Schedule_ScheduleID, cascadeDelete: true)
                .ForeignKey("dbo.Participants", t => t.Participant_ParticipantID, cascadeDelete: true)
                .Index(t => t.Schedule_ScheduleID)
                .Index(t => t.Participant_ParticipantID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduleParticipants", "Participant_ParticipantID", "dbo.Participants");
            DropForeignKey("dbo.ScheduleParticipants", "Schedule_ScheduleID", "dbo.Schedules");
            DropIndex("dbo.ScheduleParticipants", new[] { "Participant_ParticipantID" });
            DropIndex("dbo.ScheduleParticipants", new[] { "Schedule_ScheduleID" });
            DropTable("dbo.ScheduleParticipants");
            DropTable("dbo.Schedules");
            DropTable("dbo.Participants");
        }
    }
}
