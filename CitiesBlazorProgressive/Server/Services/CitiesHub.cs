using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesBlazorProgressive.Services
{
    public static class UserHandler
    {
        public static HashSet<string> ConnectedIds = new HashSet<string>();
    }

    public class CitiesHub : Hub<ICitiesHub>
    {
        public override async Task OnConnectedAsync()
        {
            UserHandler.ConnectedIds.Add(Context.ConnectionId);

            var msg = $"{Context.ConnectionId} joined the hub (Instance:{this.GetHashCode()})  clients-cnt:{UserHandler.ConnectedIds.Count}";
            await Clients.All.CityHubMessage(msg).ConfigureAwait(false);

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);

            var msg = $"{Context.ConnectionId} left the hub (Instance:{this.GetHashCode()})  clients-cnt:{UserHandler.ConnectedIds.Count}";
            await Clients.All.CityHubMessage(msg);

            await base.OnDisconnectedAsync(exception);
        }
    }
}
