using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Stening.Startup))]
namespace Stening
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
