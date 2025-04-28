using Bogus;
using RealWorld.Fakers;
using RealWorld.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<Faker<Customer>, CustomerFaker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/customers", (Faker<Customer> faker) =>
{
    // Generate a list of 100 fake customers
    var customers = faker.Generate(100);

    return Results.Ok(customers);
});


app.Run();

