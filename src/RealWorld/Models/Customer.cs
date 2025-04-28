namespace RealWorld.Models;


public abstract class Base
{

}

public abstract class EntityBase : Base
{
    public int Id { get; set; }
}

public class Customer : EntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
