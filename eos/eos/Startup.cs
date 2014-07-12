using eos.Models.Data;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eos.Startup))]
namespace eos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
