namespace UrlsMania.Server.Common.Models;

public record EntityKey<T>(T Value) : IComparable<EntityKey<T>>
    where T : notnull, IComparable<T>
{
    public int CompareTo(EntityKey<T>? other) => Value.CompareTo(other!.Value);
    public static implicit operator T(EntityKey<T> key) => key.Value;
    public static implicit operator EntityKey<T>(T value) => new(value);
}