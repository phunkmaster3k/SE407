using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InClassWork.Startup))]
namespace InClassWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
