using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoneySaver.Client.Startup))]
namespace MoneySaver.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
