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
            var people = new List<Person>
            {
                new Person{PersonID=1,FirstName="Bruce",LastName="Wayne",ZipCode="12345",Address="Wayne Manor 1",City="Gotham",TelephoneNumber="123 456 7890"},
                new Person{PersonID=2,FirstName="Barry",LastName="Allen",ZipCode="12345",Address="Some Appartment 1",City="Star City",TelephoneNumber="123 456 7890"},
                new Person{PersonID=3,FirstName="Diana",LastName="Prince",ZipCode="12345",Address="Clay Home 1",City="Themyscira",TelephoneNumber="123 456 7890"},
                new Person{PersonID=4,FirstName="Clark",LastName="Kent",ZipCode="12345",Address="Kent Farm 1",City="Smallville",TelephoneNumber="123 456 7890"},
                new Person{PersonID=5,FirstName="Lois",LastName="Lane",ZipCode="12345",Address="Kent Farm 1",City="Smalville",TelephoneNumber="123 456 7890"},
                new Person{PersonID=6,FirstName="Selina",LastName="Kyle",ZipCode="12345",Address="Wayne Manor 1",City="Gotham",TelephoneNumber="123 456 7890"},
                new Person{PersonID=7,FirstName="Iris",LastName="West",ZipCode="12345",Address="Some Appartment 1",City="Star City",TelephoneNumber="123 456 7890"},
                new Person{PersonID=8,FirstName="Steve",LastName="Trevor",ZipCode="12345",Address="Clay Home 1",City="Themyscira",TelephoneNumber="123 456 7890"},
            };
            var couples = new List<Couple>
            {
                new Couple{CoupleID=1,Person1=people[0],Person2=people[5]},
                new Couple{CoupleID=2,Person1=people[1],Person2=people[6]},
                new Couple{CoupleID=3,Person1=people[2],Person2=people[7]},
                new Couple{CoupleID=4,Person1=people[3],Person2=people[4]},
            };
            var schedules = new List<Schedule>
            {
                new Schedule{ScheduleID=1, Organizer=people[0], Date=new DateTime(2020,5,10), Title="Birthday Extravaganza", MaxCouples=8, GroupSize=4},
                new Schedule{ScheduleID=2, Organizer=people[0], Date=new DateTime(2020,5,14), Title="Funeral Extravaganza", MaxCouples=12, GroupSize=3},
                new Schedule{ScheduleID=3, Organizer=people[0], Date=new DateTime(2020,5,30), Title="Clown Extravaganza", MaxCouples=4, GroupSize=2},
            };
            context.People.AddOrUpdate(people.ToArray());
            context.Couples.AddOrUpdate(couples.ToArray());
            context.Schedules.AddOrUpdate(schedules.ToArray());
            context.SaveChanges();
        }
    }
}
