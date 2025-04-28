using RealWorld.Models;

namespace RealWorld.Services;

// Abstract
public interface ICustomerService
{
    Task<List<Customer>> GetAllAsync();
}
