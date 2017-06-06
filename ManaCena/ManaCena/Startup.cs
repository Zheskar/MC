using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManaCena.Startup))]
namespace ManaCena
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
