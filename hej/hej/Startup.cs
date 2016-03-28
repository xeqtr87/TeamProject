using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hej.Startup))]
namespace hej
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
