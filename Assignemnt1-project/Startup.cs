using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignemnt1_project.Startup))]
namespace Assignemnt1_project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
