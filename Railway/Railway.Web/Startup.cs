using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Railway.Web.Startup))]
namespace Railway.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
