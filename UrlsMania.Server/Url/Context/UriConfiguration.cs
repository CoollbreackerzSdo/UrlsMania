using Microsoft.EntityFrameworkCore.Metadata.Builders;

using UrlsMania.Server.Common.Context;
using UrlsMania.Server.Url.Models;

namespace UrlsMania.Server.Url.Context;

public sealed class UriConfiguration : BaseEntityConfiguration<ShortUrlEntity>
{
    public override void Configure(EntityTypeBuilder<ShortUrlEntity> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Code)
            .HasColumnName("code");

        builder.HasIndex(x => x.Code)
            .IsUnique();

        builder.Property(x => x.LongUrl)
            .HasColumnName("long_url");

        builder.Property(x => x.ShortUrl)
            .HasColumnName("short_url");
    }
}