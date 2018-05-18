using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JuegoAdivinarNumero.Startup))]
namespace JuegoAdivinarNumero
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
