namespace HRISAPI.Contracts;

public interface IBaseRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);   
    Task CreateAsync(T entity);
    void Update(T entity);
    Task TagIsDeleted(int id);
    Task DeleteAsync(int id);


    Task<bool> SaveChangesAsync();    
}
