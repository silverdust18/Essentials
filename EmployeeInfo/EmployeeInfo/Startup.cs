using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeInfo.Startup))]
namespace EmployeeInfo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
