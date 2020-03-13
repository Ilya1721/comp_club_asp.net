using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ComputerClub.Startup))]
namespace ComputerClub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
