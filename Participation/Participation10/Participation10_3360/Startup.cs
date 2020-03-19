using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Participation10_3360.Startup))]
namespace Participation10_3360
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
