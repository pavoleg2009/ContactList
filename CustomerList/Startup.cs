using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomerList.Startup))]
namespace CustomerList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
