using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShirtsOffYourBack.Startup))]
namespace ShirtsOffYourBack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
