using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Samaritans.Startup))]
namespace Samaritans
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
