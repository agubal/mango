using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mango.Site.Startup))]
namespace Mango.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
