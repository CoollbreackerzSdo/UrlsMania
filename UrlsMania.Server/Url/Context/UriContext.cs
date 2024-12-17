using UrlsMania.Server.Url.Models;

namespace UrlsMania.Server.Url.Context;

public sealed class UriContext(DbContextOptions<UriContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UriConfiguration());
    }
    public DbSet<ShortUrlEntity> ShortUrls { get; init; } = null!;
}