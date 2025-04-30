namespace RealWorld.Models;

// Model
public class DashboardItem
{
    public int CustomersCount { get; set; }
    public int ProductsCount { get; set; }
    public double AvgPrice { get; set; }
    public SystemStatus SystemStatus { get; set; }
}
