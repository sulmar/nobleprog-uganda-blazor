using RealWorld.Models;
using System.Net.Http.Json;

namespace RealWorld.Services;

// Concrete
public class ApiCustomerService(HttpClient Client) : ICustomerService
{
    public Task<List<Customer>> GetAllAsync() => Client.GetFromJsonAsync<List<Customer>>("api/customers");   
}
