namespace RealWorld.Services;

// Generic Interface = Template for interface 
public interface IEntityService<T>
{
    Task<List<T>> GetAllAsync();
}
