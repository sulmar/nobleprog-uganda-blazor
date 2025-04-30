using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs;

public class DashboardHub(ILogger<DashboardHub> logger) : Hub
{
    public override Task OnConnectedAsync()
    {
        logger.LogInformation("Client connected: {ConnectionId}", Context.ConnectionId);

        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        logger.LogInformation("Client disconnected: {ConnectionId}", Context.ConnectionId);

        return base.OnDisconnectedAsync(exception);
    }

}
