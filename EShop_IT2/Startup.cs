using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EShop_IT2.Startup))]
namespace EShop_IT2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           
        }

     
    }
}
