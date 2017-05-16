using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.Owin;
using Owin;
using PolyCare.Models;

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
