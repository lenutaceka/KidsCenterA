using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KidsCenterA.Startup))]
namespace KidsCenterA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
