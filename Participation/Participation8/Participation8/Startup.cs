using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Participation8.Startup))]
namespace Participation8
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
