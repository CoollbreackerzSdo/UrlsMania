using EntityFramework.Exceptions.PostgreSQL;

using Serilog;

using UrlsMania.Server.Common.Handler;
using UrlsMania.Server.Common.Middlewares;
using UrlsMania.Server.Url.Context;
using UrlsMania.Server.Url.Handler;
using UrlsMania.Server.Url.Models;
using UrlsMania.Server.Url.Services.Generators;

namespace UrlsMania.Server;

public static class ServiceDiscovery
{
    public static IHostBuilder ConfigureSerilog(this IHostBuilder host)
        => host.UseSerilog((_, logger) => logger.WriteTo.Console());
    public static IServiceCollection AddMiddlewares(this IServiceCollection services)
        => services.AddTransient<ErrorMiddleware>();
    public static IApplicationBuilder MapMiddlewares(this IApplicationBuilder builder)
        => builder.UseMiddleware<ErrorMiddleware>();
    public static IServiceCollection AddGenerators(this IServiceCollection services)
        => services.AddTransient<ITextRandomGenerador, RandomUriCode>();
    public static IHostApplicationBuilder AddContexts(this IHostApplicationBuilder builder)
    {
        // builder.AddNpgsqlDbContext<UriContext>("postgres", null, options => options.UseExceptionProcessor());
        builder.Services.AddDbContext<UriContext>(options => options.UseNpgsql().UseExceptionProcessor());
        builder.Services.AddTransient<IUriRepository, UriRepository>();
        return builder;
    }
    public static void MapMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        scope.ServiceProvider.GetRequiredService<UriContext>().Database.Migrate();
    }
    public static IServiceCollection AddHandler(this IServiceCollection services)
        => services.AddTransient<IHandler<(ShortUrlRequest Request, string UrlBase), string>, CreateNewUriHandler>();
}