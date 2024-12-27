
using Microsoft.AspNetCore.Http.HttpResults;

using UrlsMania.Server.Common.Handler;
using UrlsMania.Server.Url.Models;

namespace UrlsMania.Server.Url.Endpoints;

public static partial class Endpoints
{
    public static IEndpointRouteBuilder MapUrlEndpoints(this IEndpointRouteBuilder builder)
    {
        var endpoint = builder.MapGroup("url")
            .WithTags(["Url"]);

        endpoint.MapPost("", Create)
            .Accepts<ShortUrlRequest>("application/json")
            .Produces<string>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithOpenApi();

        return endpoint;
    }
    public static async Task<Results<Ok<string>, BadRequest>> Create(ShortUrlRequest request, HttpRequest httpRequest, IHandler<(ShortUrlRequest Request, string UrlBase), string> handler, CancellationToken token)
    {
        var handlerResult = await handler.HandleAsync((request, $"{httpRequest.Scheme}://{httpRequest.Host}"), token);
        return handlerResult.IsSuccess ? TypedResults.Ok(handlerResult.Value) : TypedResults.BadRequest();
    }
}