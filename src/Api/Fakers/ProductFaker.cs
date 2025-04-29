using Bogus;
using RealWorld.Models;

namespace RealWorld.Fakers;

public class ProductFaker : Faker<Product>
{
    public ProductFaker()
    {
        RuleFor(p=>p.Id, f=>f.IndexFaker+ 1);
        RuleFor(p=>p.Code, f=>f.Commerce.Ean13());
        RuleFor(p => p.Name, f => f.Commerce.ProductName());
        RuleFor(p => p.Description, f => f.Lorem.Paragraph());
        RuleFor(p => p.Price, f => f.Finance.Amount(1, 1000));
    }
}