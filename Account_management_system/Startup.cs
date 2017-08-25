using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Account_management_system.Startup))]
namespace Account_management_system
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
