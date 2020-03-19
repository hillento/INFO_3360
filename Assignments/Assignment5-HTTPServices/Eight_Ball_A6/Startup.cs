using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Eight_Ball_A6.Startup))]
namespace Eight_Ball_A6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
