namespace HRISAPI.Contracts;

public interface IBaseRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);   
    void Create(T entity);
    void Update(T entity);
    Task Delete(int id);
    Task<bool> SaveChangesAsync();

}
