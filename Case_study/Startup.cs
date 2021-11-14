using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Case_study.Startup))]
namespace Case_study
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
