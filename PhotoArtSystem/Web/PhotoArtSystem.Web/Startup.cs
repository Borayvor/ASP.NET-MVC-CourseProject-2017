using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PhotoArtSystem.Web.Startup))]
namespace PhotoArtSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
