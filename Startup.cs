using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ungdunghocthongminh.Startup))]
namespace ungdunghocthongminh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
