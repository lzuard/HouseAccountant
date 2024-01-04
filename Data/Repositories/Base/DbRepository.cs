using Data.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Data.Repositories.Base;

public class DbRepository<T>: IDbRepository<T> where T: class, IEntity, new()
{
    private readonly DataBaseContext _context;
    
    private readonly DbSet<T> _set;

    public virtual IQueryable<T> Items => _set;

    public DbRepository(DataBaseContext context)
    {
        _context = context;
        _set = _context.Set<T>();
    }

    public T Get(Guid id) => Items.SingleOrDefault(item => item.Id == id);

    public async Task<T> GetAsync(Guid id, CancellationToken token = default) =>
        await Items.SingleOrDefaultAsync(item => item.Id == id).ConfigureAwait(false);

    public void Add(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        _context.Entry(entity).State = EntityState.Added;
    }

    public void AddRange(IEnumerable<T> entities)
    {
        ArgumentNullException.ThrowIfNull(entities);
        _context.AddRange(entities);
    }

    public void Update(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        var oldEntity = Get(entity.Id);
        _context.Entry(oldEntity).CurrentValues.SetValues(entity);
        //_context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(Guid id)
    {
        var entity = Get(id);
        Delete(entity);
    }

    public void Delete(T entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
    }
    
    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}