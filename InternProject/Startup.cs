using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InternProject.Startup))]
namespace InternProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
