using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FiltersTestProject.Startup))]
namespace FiltersTestProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
