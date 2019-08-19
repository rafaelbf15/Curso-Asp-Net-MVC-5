using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Curso.Mvc.Ui.Site.Startup))]
namespace Curso.Mvc.Ui.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
