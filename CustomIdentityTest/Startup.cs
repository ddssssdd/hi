using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomIdentityTest.Startup))]
namespace CustomIdentityTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
