using ETicaretApi.SignalR.Hubs;
using ETicaretAPI.Application.Abstractions.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.SignalR.HubService
{
    public class OrderHubService : IOrderHubService
    {
        readonly IHubContext<OrderHub> _hubContext;

        public OrderHubService(IHubContext<OrderHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task OrderAddedMesageAsync(string message) =>
          await _hubContext.Clients.All.SendAsync(ReceiveFunctionNames.OrderAddedMessage, message);

    }
}
