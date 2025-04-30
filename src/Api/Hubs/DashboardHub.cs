using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs;

public class DashboardHub(ILogger<DashboardHub> logger) : Hub
{
    public override async Task OnConnectedAsync()
    {
        logger.LogInformation("Client connected: {ConnectionId}", Context.ConnectionId);

        // hint: you can use the user claims to create groups
        // var groupName = Context.User.Claims.SingleOrDefault(p => p.Type == "group").Value;
        // await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        logger.LogInformation("Client disconnected: {ConnectionId}", Context.ConnectionId);

        return base.OnDisconnectedAsync(exception);
    }

}
