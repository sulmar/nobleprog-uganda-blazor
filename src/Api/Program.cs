using Bogus;
using RealWorld.Fakers;
using RealWorld.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<Faker<Customer>, CustomerFaker>();
builder.Services.AddSingleton<Faker<Product>, ProductFaker>();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy=>
{
    policy.WithOrigins("https://localhost:7032")
        .AllowAnyHeader()
        .AllowAnyMethod();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.MapGet("api/customers", async (Faker<Customer> faker) =>
{
    await Task.Delay(1000); // Simulate a delay for the sake of the example

    // Generate a list of 100 fake customers
    var customers = faker.Generate(100);

    return Results.Ok(customers);
});

app.MapGet("api/products", async(Faker<Product> faker) =>
{
    await Task.Delay(1000); // Simulate a delay for the sake of the example
    // Generate a list of 100 fake products
    var products = faker.Generate(100);
    return Results.Ok(products);
});


app.Run();

