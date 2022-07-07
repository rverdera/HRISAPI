namespace HRISAPI.Contracts;

public interface IBaseRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(object id);   
    Task CreateAsync(T entity);
    Task UpdateAsync(object id, object entity);
    Task TagIsDeleted(object id);
    Task DeleteAsync(object id);


    Task<bool> SaveChangesAsync();
}
