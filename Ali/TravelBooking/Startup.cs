using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelBooking.Startup))]
namespace TravelBooking
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
