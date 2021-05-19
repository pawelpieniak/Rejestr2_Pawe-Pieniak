using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rejestr_PawełPieniak.Startup))]
namespace Rejestr_PawełPieniak
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
