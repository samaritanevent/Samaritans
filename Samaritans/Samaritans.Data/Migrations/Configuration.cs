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
                new Event { OrganizerId= userId, Name="Block Cleanup", MaxAttendance=10, MinAttendance=4, Purpose="Clean up Lakewood Park Pavilion", EventDate = DateTime.Now.AddDays(1)},
                new Event { OrganizerId= userId, Name="Build fences", MaxAttendance=10, MinAttendance=5, Purpose="Build fences around Tremon Montessori School", EventDate = DateTime.Now.AddDays(2)},
                new Event { OrganizerId= userId, Name="Litter Pick up", MaxAttendance=12, MinAttendance=5, Purpose="Rocky River Marina litter pick-up", EventDate = DateTime.Now.AddDays(3) },
                new Event { OrganizerId= userId, Name="Street Clean", MaxAttendance=15, MinAttendance=10, Purpose="Ohio City Festival post-fest street clean", EventDate = DateTime.Now.AddDays(7)},
                new Event { OrganizerId= userId, Name="5k WRun", MaxAttendance=10, MinAttendance=3, Purpose="5K Walk/Run in Lakewood- hand out water to marchers!", EventDate = DateTime.Now.AddDays(13) },
                new Event { OrganizerId= userId, Name="Plant Community Garden", MaxAttendance=8, MinAttendance=3, Purpose="Plant Community Garden- W 32nd & Penn Ohio City",EventDate = DateTime.Now.AddDays(10) }
            };

            context.Events.AddOrUpdate(prop => prop.Id, eventList.ToArray());
            context.SaveChanges();
        }
    }
}
