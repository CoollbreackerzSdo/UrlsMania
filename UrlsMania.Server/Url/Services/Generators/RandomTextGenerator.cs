using System.Text;

namespace UrlsMania.Server.Url.Services.Generators;

public sealed class RandomTextGenerator() : ITextRandomGenerador
{
    public string Generate()
    {
        StringBuilder text = new();
        ReadOnlySpan<char> template = Guid.CreateVersion7().ToString();
        foreach (var index in template.Split('-'))
        {
            text.Append(template[index]);
        }
        return text.ToString();
    }
    public int MaxLength
    {
        get => field;
        init => field = value > 1 ? value : 10;
    }
}