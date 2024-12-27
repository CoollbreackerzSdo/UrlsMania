using Microsoft.EntityFrameworkCore.Metadata.Builders;

using UrlsMania.Server.Common.Models;

namespace UrlsMania.Server.Common.Context;

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T>
    where T : EntityBase
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(x => x.Key)
            .HasConversion(x => x.Value, x => x)
            .HasColumnName("id");
            
        builder.HasKey(x => x.Key);
    }
}