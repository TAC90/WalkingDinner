using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WalkingDinner.Models;

namespace WalkingDinner.DAL
{
    public class WDContext : DbContext
    {
        public WDContext() : base("name=WDDBConnection")
        {
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Couple> Couples { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}