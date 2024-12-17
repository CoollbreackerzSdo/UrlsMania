namespace UrlsMania.Server.Url.Models;

public interface IDefUrl
{
    string LongUrl { get; }
    string ShortUrl { get; }
    string Code { get; }
}