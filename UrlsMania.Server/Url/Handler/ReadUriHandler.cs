using UrlsMania.Server.Common.Handler;
using UrlsMania.Server.Url.Context;

namespace UrlsMania.Server.Url.Handler;

public class ReadUriHandler(IUriRepository repository) : IHandler<string, string>
{
    public Result<string> Handle(string request)
        => repository.GetByCode(request) is string value ? value : Result.NoContent();
    public Task<Result<string>> HandleAsync(string request, CancellationToken token = default)
        => Task.FromResult<Result<string>>(repository.GetByCode(request) is string value ? value : Result.NoContent());
}