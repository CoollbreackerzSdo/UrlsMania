using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.AddContexts();
builder.AddServiceDefaults();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
            .AddServer("https://localhost:5001")
            .AddServer("http://localhost:5000");
        options
            .WithTheme(ScalarTheme.Moon);
    });
}

app.UseHttpsRedirection();
app.MapDefaultEndpoints();
app.Run();