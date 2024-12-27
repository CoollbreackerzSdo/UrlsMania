namespace UrlsMania.Server.Common.Models;

public record struct EntityKey<T>(T Value) : IComparable<EntityKey<T>>
    where T : notnull, IComparable<T>
{
    public T Value { get; init; } = Value;
    public readonly int CompareTo(EntityKey<T> other) => Value.CompareTo(other!.Value);
    public static implicit operator T(EntityKey<T> key) => key.Value;
    public static implicit operator EntityKey<T>(T value) => new(value);
}