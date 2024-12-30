
using UrlsMania.Server.Common.Context;
using UrlsMania.Server.Url.Models;

namespace UrlsMania.Server.Url.Context;

public interface IUriRepository : IRepository<ShortUrlEntity>
{
    Task<ShortUrlEntity?> FirstAsync(string code, CancellationToken token = default);
    string? GetByCode(string request);
}

public sealed class UriRepository(UriContext context) : Repository<ShortUrlEntity, UriContext>(context), IUriRepository
{
    public Task<ShortUrlEntity?> FirstAsync(string code, CancellationToken token = default)
        => _table.FirstOrDefaultAsync(x => x.Code.StartsWith(code), token);
    public string? GetByCode(string request)
        => _table.FirstOrDefault(x => x.Code.StartsWith(request))?.LongUrl;
}