namespace WalkingDinner.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WalkingDinner.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WalkingDinner.DAL.WDContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WalkingDinner.DAL.WDContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var participants = new List<Participant>
            {
                new Participant{ParticipantID=1,FirstName="Bruce",LastName="Wayne",ZipCode="12345",Address="Wayne Manor 1",City="Gotham",TelephoneNumber="123 456 7890", 
                FirstNamePartner="Selina",LastNamePartner="Kyle"},
                new Participant{ParticipantID=2,FirstName="Barry",LastName="Allen",ZipCode="12345",Address="Some Appartment 1",City="Star City",TelephoneNumber="123 456 7890",
                FirstNamePartner="Iris",LastNamePartner="West"},
                new Participant{ParticipantID=3,FirstName="Diana",LastName="Prince",ZipCode="12345",Address="Clay Home 1",City="Themyscira",TelephoneNumber="123 456 7890",
                FirstNamePartner="Steve",LastNamePartner="Trevor"},
                new Participant{ParticipantID=4,FirstName="Clark",LastName="Kent",ZipCode="12345",Address="Kent Farm 1",City="Smallville",TelephoneNumber="123 456 7890",
                FirstNamePartner="Lois",LastNamePartner="Lane"},
            };
            var schedules = new List<Schedule>
            {
                new Schedule{ScheduleID=1, Active = true, Date=new DateTime(2020,5,10), Title="Birthday Extravaganza", MaxParticipants=4, GroupSize=2, Participants = new List<Participant>()},
                new Schedule{ScheduleID=2, Active = false, Date=new DateTime(2020,5,14), Title="Funeral Extravaganza", MaxParticipants=8, GroupSize=2, Participants = new List<Participant>()},
                new Schedule{ScheduleID=3, Active = true, Date=new DateTime(2020,5,30), Title="Clown Extravaganza", MaxParticipants=12, GroupSize=3, Participants = new List<Participant>()},
            };
            foreach(Participant p in participants)
            {
                schedules[0].Participants.Add(p);
                schedules[1].Participants.Add(p);
                schedules[2].Participants.Add(p);
            }
            //schedules.ForEach(s => context.Schedules.AddOrUpdate(p => p.ScheduleID, s));
            context.Participants.AddOrUpdate(participants.ToArray());
            context.Schedules.AddOrUpdate(schedules.ToArray());
            context.SaveChanges();
        }
    }
}
