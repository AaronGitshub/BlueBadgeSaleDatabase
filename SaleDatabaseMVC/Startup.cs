using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SaleDatabaseMVC.Startup))]
namespace SaleDatabaseMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
