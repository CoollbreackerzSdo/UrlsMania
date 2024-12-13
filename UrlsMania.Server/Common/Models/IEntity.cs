namespace UrlsMania.Server.Common.Models;

public interface IEntity<T>
    where T : notnull, IComparable<T>
{
    T Key { get; }
}