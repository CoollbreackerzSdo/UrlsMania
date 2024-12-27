using Scalar.AspNetCore;

using UrlsMania.Server.Url.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Host.ConfigureSerilog();
builder.Services.AddOpenApi();
builder.Services.AddHandler();
builder.Services.AddMiddlewares();
builder.Services.AddGenerators();
builder.AddContexts();
builder.AddServiceDefaults();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapMigrations();
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
app.MapMiddlewares();
app.MapDefaultEndpoints();
app.MapUrlEndpoints();
app.Run();