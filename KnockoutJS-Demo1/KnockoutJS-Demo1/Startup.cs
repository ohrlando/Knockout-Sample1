using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KnockoutJS_Demo1.Startup))]
namespace KnockoutJS_Demo1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
