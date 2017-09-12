using Microsoft.Owin;
using Owin;
using Hangfire;
using Hangfire.SqlServer;
using Hangfire.Dashboard;
using System;
using WcfClient;

[assembly: OwinStartupAttribute(typeof(ClientWebFramework.Startup))]
namespace ClientWebFramework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ClientConnection client = ClientConnection.GetInstance();
            client.SetupChannels();
            GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection", new SqlServerStorageOptions { QueuePollInterval = TimeSpan.FromSeconds(1) });
            app.UseHangfireServer();
            ConfigureAuth(app);
            var options = new DashboardOptions { Authorization = new[] { new CustomAuthorizationFilter() } };
            app.UseHangfireDashboard("/hangfire", options);
        }
    }

    public class CustomAuthorizationFilter : IDashboardAuthorizationFilter
    {

        public bool Authorize(DashboardContext context)
        {
            // In case you need an OWIN context, use the next line, `OwinContext` class
            // is the part of the `Microsoft.Owin` package.
            var owinContext = new OwinContext(context.GetOwinEnvironment());

            // Allow all authenticated users to see the Dashboard (potentially dangerous).
            return owinContext.Authentication.User.Identity.IsAuthenticated;
        }
    }
}
