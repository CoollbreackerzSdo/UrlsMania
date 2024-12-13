using Serilog;

using UrlsMania.Server.Common.Middlewares;

namespace UrlsMania.Server;

public static class ServiceDiscovery
{
    public static IHostBuilder ConfigureSerilog(this IHostBuilder host)
        => host.UseSerilog((_, logger) => logger.WriteTo.Console());
    public static IServiceCollection AddMiddlewares(this IServiceCollection services)
        => services.AddTransient<ErrorMiddleware>();
    public static IApplicationBuilder MapMiddlewares(this IApplicationBuilder builder)
        => builder.UseMiddleware<ErrorMiddleware>();
}