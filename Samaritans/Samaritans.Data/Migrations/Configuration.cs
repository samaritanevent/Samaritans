namespace Samaritans.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Web.Management;

    internal sealed class Configuration : DbMigrationsConfiguration<Samaritans.Data.Entities.DoGooderDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Entities.DoGooderDb context)
        {
            SqlServices.Install("DoGooderDb", SqlFeatures.Membership, "Integrated Security=True");
            SqlServices.Install("DoGooderDb", SqlFeatures.RoleManager, "Integrated Security=True");

            //  This method will be called after migrating to the latest version.

        }
    }
}
