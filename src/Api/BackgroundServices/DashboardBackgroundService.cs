using Api.Hubs;
using Microsoft.AspNetCore.SignalR;
using RealWorld.Models;

namespace Api.BackgroundServices;

public class DashboardBackgroundService : BackgroundService
{
    private readonly ILogger<DashboardBackgroundService> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly IHubContext<DashboardHub> _hubContext;

    public DashboardBackgroundService(
        ILogger<DashboardBackgroundService> logger, 
        IServiceProvider serviceProvider, 
        IHubContext<DashboardHub> hubContext)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        _hubContext = hubContext;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    // Perform your background task here

                    var info = new DashboardItem
                    {
                        CustomersCount = Random.Shared.Next(1, 100),
                        ProductsCount = Random.Shared.Next(50, 200),
                        AvgPrice = Random.Shared.Next(100, 200),
                        SystemStatus = (SystemStatus) Random.Shared.Next(0, 2)
                    };


                    // Bad practice
                    // _logger.LogInformation($"Background {info.ProductsCount}.");

                    // Good practice
                    _logger.LogInformation("CustomersCount: {CustomersCount} ProductsCount: {ProductsCount} AvgPrice: {AvgPrice} SystemStatus: {SystemStatus}", info.CustomersCount, info.ProductsCount, info.AvgPrice, info.SystemStatus );

                    // TODO: send the information to the dashboard by SignalR
                    await _hubContext.Clients.All.SendAsync("UpdateDashboard", info, stoppingToken);

                    await _hubContext.Clients.Group("blue").SendAsync("UpdateDashboard", info, stoppingToken);


                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while executing the background service.");
            }

            // Simulate a delay for the sake of the example
            await Task.Delay(5000, stoppingToken);

        }
    }
}
