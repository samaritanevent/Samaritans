using Samaritans.Data.Entities;
using System.Collections.Generic;

namespace Samaritans.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Management;

    internal sealed class Configuration : DbMigrationsConfiguration<Samaritans.Data.Entities.DoGooderDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(Entities.DoGooderDb context)
        {
            SqlServices.Install("DoGooderDb", SqlFeatures.Membership, "Integrated Security=True");
            SqlServices.Install("DoGooderDb", SqlFeatures.RoleManager, "Integrated Security=True");

            var userId = context.AspNetUsers.FirstOrDefault()?.Id;

            if (string.IsNullOrEmpty(userId))
            {
                return;
            }

            //  This method will be called after migrating to the latest version.
            var eventList = new List<Event>
            {
                new Event { OrganizerId = userId, Name="Lindsey Lowe", MaxAttendance=10, MinAttendance=4, Purpose="Clean up Lakewood Park Pavilion", EventDate = DateTime.ParseExact("05-05-2017 08:00", "dd-MM-yyyy HH:mm", null) },
                new Event { OrganizerId=userId, Name="Allen Yu", MaxAttendance=10, MinAttendance=5, Purpose="Build fences around Tremon Montessori School", EventDate = DateTime.ParseExact("04-27-2017 10:00", "dd-MM-yyyy HH:mm", null)   },
                new Event { OrganizerId=userId, Name="Andrew Diamond", MaxAttendance=12, MinAttendance=5, Purpose="Rocky River Marina litter pick-up", EventDate = DateTime.ParseExact("04-29-2017 14:00", "dd-MM-yyyy HH:mm", null) },
                new Event { OrganizerId=userId, Name="Josh Graber", MaxAttendance=15, MinAttendance=10, Purpose="Ohio City Festival post-fest street clean", EventDate = DateTime.ParseExact("04-29-2017 12:00", "dd-MM-yyyy HH:mm", null) },
                new Event { OrganizerId=userId, Name="Lily Krichels", MaxAttendance=10, MinAttendance=3, Purpose="5K Walk/Run in Lakewood- hand out water to marchers!", EventDate = DateTime.ParseExact("04-30-2017 13:00", "dd-MM-yyyy HH:mm", null) },
                new Event { OrganizerId=userId, Name="Sean Martz", MaxAttendance=8, MinAttendance=3, Purpose="Plant Community Garden- W 32nd & Penn Ohio City",EventDate = DateTime.ParseExact("05-06-2017 12:00", "dd-MM-yyyy HH:mm", null) }
            };
            eventList.ForEach(e => context.Events.AddOrUpdate( prop=> prop.Id, e));
            context.SaveChanges();
        }
    }
}
