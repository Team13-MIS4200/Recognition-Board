using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Recognition_Board.Startup))]
namespace Recognition_Board
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
