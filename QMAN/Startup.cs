using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QMAN.Startup))]
namespace QMAN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
