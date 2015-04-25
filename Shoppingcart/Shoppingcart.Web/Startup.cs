using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shoppingcart.Web.Startup))]
namespace Shoppingcart.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
