using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ipuc.Backend.Startup))]
namespace Ipuc.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
