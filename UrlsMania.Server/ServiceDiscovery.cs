using EntityFramework.Exceptions.PostgreSQL;

using Serilog;

using UrlsMania.Server.Common.Middlewares;
using UrlsMania.Server.Url.Context;
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
        => services.AddTransient<ITextRandomGenerador, RandomTextGenerator>();
    public static IHostApplicationBuilder AddContexts(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<UriContext>("postgres", null, options => options.UseExceptionProcessor());
        // builder.Services.AddDbContext<UriContext>(options => options.UseNpgsql().UseExceptionProcessor());
        return builder;
    }
}