using System.Text;

namespace UrlsMania.Server.Url.Services.Generators;

public sealed class RandomUriCode() : ITextRandomGenerador
{
    public string Generate()
    {
        var code = new StringBuilder();

        for (int i = 0; i < MaxLength; i++)
        {
            code.Append(char.ConvertFromUtf32(_machesGenerator.Next(97, 122)));
        }

        return code.ToString();
    }
    private readonly Random _machesGenerator = new();
    public int MaxLength
    {
        get => field;
        init => field = value > 1 ? value : 10;
    }
}