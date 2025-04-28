using Bogus;
using RealWorld.Models;

namespace RealWorld.Fakers;

// dotnet add package Bogus
public class CustomerFaker : Faker<Customer>
{
    public CustomerFaker()
    {
        RuleFor(p=>p.Id, f => f.IndexFaker + 1); // Start from 1 instead of 0
        RuleFor(p=> p.FirstName, f => f.Person.FirstName);
        RuleFor(p => p.LastName, f => f.Person.LastName);
        RuleFor(p => p.Email, f => f.Internet.Email(f.Person.FirstName, f.Person.LastName));
    }
}
