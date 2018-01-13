using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SCFOWebsite.Startup))]
namespace SCFOWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
