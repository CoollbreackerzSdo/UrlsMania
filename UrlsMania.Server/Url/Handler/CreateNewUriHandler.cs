
using UrlsMania.Server.Common.Handler;
using UrlsMania.Server.Url.Context;
using UrlsMania.Server.Url.Models;
using UrlsMania.Server.Url.Services.Generators;

namespace UrlsMania.Server.Url.Handler;

public sealed class CreateNewUriHandler(IUriRepository repository, ITextRandomGenerador generador) : IHandler<(ShortUrlRequest Request, string UrlBase), string>
{
    public async Task<Result<string>> HandleAsync((ShortUrlRequest Request, string UrlBase) request, CancellationToken token = default)
    {
        var code = generador.Generate();
        while (repository.Any(x => x.Code.StartsWith(code)))
        {
            code = generador.Generate();
        }
        var newUrl = $"{request.UrlBase}/{code}";
        var model = new ShortUrlEntity()
        {
            LongUrl = request.Request.Url,
            ShortUrl = newUrl,
            Code = code.ToString()
        };
        await repository.AddAsync(model, token);
        await repository.SaveChangesAsync(token);
        return Result.Created(newUrl);
    }
}