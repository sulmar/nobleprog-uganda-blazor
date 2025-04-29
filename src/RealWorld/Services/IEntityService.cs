namespace RealWorld.Services;

// Generic Types

// Generic Interface = Template for interface 
public interface IEntityService<T>
{
    Task<List<T>> GetAllAsync();
}
