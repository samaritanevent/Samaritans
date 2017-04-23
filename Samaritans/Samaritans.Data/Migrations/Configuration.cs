using Samaritans.Data.Entities;
using System.Collections.Generic;

namespace Samaritans.Data.Migrations
{
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
                new Event { OrganizerId = userId, },
                new Event { }
            };
        }
    }
}
