using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AmazonDeals.Startup))]
namespace AmazonDeals
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
