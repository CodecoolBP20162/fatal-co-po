using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClientWebFramework.Startup))]
namespace ClientWebFramework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
