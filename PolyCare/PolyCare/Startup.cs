using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PolyCare.Startup))]
namespace PolyCare
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
