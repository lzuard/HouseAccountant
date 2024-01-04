using Data.Models.Base;

namespace Data.Repositories.Base;

public interface IDbRepository<T> where T: class, IEntity, new()
{
    IQueryable<T> Items { get; }
    
    T Get(Guid id);
    
    Task<T> GetAsync(Guid id, CancellationToken token=default);
    
    void Add(T entity);
    
    void AddRange(IEnumerable<T> entities);
    
    void Update(T entity);
    
    void Delete(Guid id);

    void Delete(T entity);
    
    public void SaveChanges();

}