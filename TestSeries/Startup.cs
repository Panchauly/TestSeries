using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestSeries.Startup))]
namespace TestSeries
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
