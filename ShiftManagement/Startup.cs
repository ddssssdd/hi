using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShiftManagement.Startup))]
namespace ShiftManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
