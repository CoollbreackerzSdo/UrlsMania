using UrlsMania.Server.Common.Models;

namespace UrlsMania.Server.Url.Models;

public sealed class ShortUrlEntity : EntityBase, IDefUrl
{
    public required string LongUrl { get; init; }
    public required string ShortUrl { get; init; }
    public required string Code { get; init; }
}