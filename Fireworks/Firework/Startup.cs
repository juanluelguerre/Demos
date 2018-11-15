using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Firework.Startup))]

namespace Firework
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.DependencyResolver.UseRedis("fireworkscodefest.redis.cache.windows.net", 6379, "3lK2v7A0EHKGnPu5szhkREOc99uT1AooxNJoW+omSRA=", "Fireworks");
            app.MapSignalR();
        }
    }
}
