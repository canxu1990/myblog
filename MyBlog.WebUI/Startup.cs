using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyBlog.WebUI.Startup))]
namespace MyBlog.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
