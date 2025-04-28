using RealWorld.Models;
using System.Net.Http.Json;

namespace RealWorld.Services;

// Abstract
public interface ICustomerService
{
    Task<List<Customer>> GetAllAsync();
}

// Concrete
public class ApiCustomerService : ICustomerService
{
    private HttpClient Client;

    public ApiCustomerService(HttpClient client)
    {
        Client = client;
    }

    public Task<List<Customer>> GetAllAsync()
    {
        return Client.GetFromJsonAsync<List<Customer>>("api/customers");
    }
}
