using System.Diagnostics.CodeAnalysis;

namespace UrlsMania.Server.Url.Models;

public record struct ShortUrlRequest
{
    [SetsRequiredMembers]
    public ShortUrlRequest(string url) => Url = url;
    public required string Url { get; init; }
}