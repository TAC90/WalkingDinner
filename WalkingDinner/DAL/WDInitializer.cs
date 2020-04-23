using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WalkingDinner.Models;

namespace WalkingDinner.DAL
{
    public class WDInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WDContext>
    {
        protected override void Seed(WDContext context)
        {
            
        }
    }
}