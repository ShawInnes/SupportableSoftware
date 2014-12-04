using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GlimpseDemo.Startup))]
namespace GlimpseDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
