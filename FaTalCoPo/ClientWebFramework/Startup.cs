using Microsoft.Owin;
using Owin;
using WcfClient;

[assembly: OwinStartupAttribute(typeof(ClientWebFramework.Startup))]
namespace ClientWebFramework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ClientConnection client = ClientConnection.GetInstance();
            client.SetupChannels();
        }
    }
}
