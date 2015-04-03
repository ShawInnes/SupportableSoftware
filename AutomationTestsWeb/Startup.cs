using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutomationTestsWeb.Startup))]
namespace AutomationTestsWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
