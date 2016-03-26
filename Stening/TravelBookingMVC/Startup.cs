using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelBookingMVC.Startup))]
namespace TravelBookingMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
