using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FlightBooking.Startup))]
namespace FlightBooking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
