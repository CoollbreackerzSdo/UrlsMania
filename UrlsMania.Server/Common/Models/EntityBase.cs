namespace UrlsMania.Server.Common.Models;

public abstract class EntityBase : IEntity<EntityKey<Guid>>
{
    public EntityKey<Guid> Key { get; init; } = Guid.CreateVersion7();
}