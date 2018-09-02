using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppGenesis.Backend.Startup))]
namespace AppGenesis.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
