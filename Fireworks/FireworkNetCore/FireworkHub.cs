using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Firework
{
    // [HubName("fireworkHub")]    
    public class FireworkHub : Hub<IFireworkHub>
    {
        public FireworkHub()
        {

        }


        public async Task Add(int type, double x, double y, string color, int tail)
        {
            await Clients.All.Add(type, x, y, color, tail);                    
        }
    }
}