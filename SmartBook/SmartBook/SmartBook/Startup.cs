using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartBook.Startup))]
namespace SmartBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
