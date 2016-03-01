using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PM25.Startup))]
namespace PM25
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
