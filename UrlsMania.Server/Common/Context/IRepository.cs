using System.Linq.Expressions;

using UrlsMania.Server.Common.Models;

namespace UrlsMania.Server.Common.Context;

public interface IRepository<T> : IDisposable
{
    Task AddAsync(T model, CancellationToken token = default);
    void Add(T model);
    Task<T?> FindAsync<TKey>(TKey key, CancellationToken token = default);
    Task<T?> SingleAsync(Expression<Func<T, bool>> expression, CancellationToken token = default);
    Task SaveChangesAsync(CancellationToken token = default);
    void SaveChanges();
}

public abstract class Repository<T, TContext> : IRepository<T>
    where T : EntityBase
    where TContext : DbContext
{
    public Repository(TContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }
    public virtual async Task AddAsync(T model, CancellationToken token) => await _table.AddAsync(model, token);
    public virtual Task<T?> SingleAsync(Expression<Func<T, bool>> expression, CancellationToken token) => _table.SingleOrDefaultAsync(expression, token);
    public async Task<T?> FindAsync<TKey>(TKey key, CancellationToken token)
        => key switch
        {
            EntityKey<Guid> value => await _table.FindAsync([value], cancellationToken: token),
            _ => null
        };
    public Task SaveChangesAsync(CancellationToken token = default)
        => _context.SaveChangesAsync(token);
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                // TODO: eliminar el estado administrado (objetos administrados)
                _context.Dispose();
            }

            // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
            // TODO: establecer los campos grandes como NULL
            _disposedValue = true;
        }
    }

    // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
    // ~Repository()
    // {
    //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
    public void Add(T model) => _table.Add(model);
    public void SaveChanges() => _context.SaveChanges();
    private readonly protected TContext _context;
    private readonly protected DbSet<T> _table;
    private bool _disposedValue;
}