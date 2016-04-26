using Microsoft.Owin;
using Owin;
using Railway.Web;

[assembly: OwinStartup(typeof(Startup))]
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
