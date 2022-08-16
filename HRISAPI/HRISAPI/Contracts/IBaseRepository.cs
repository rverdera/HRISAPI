namespace HRISAPI.Contracts;

public interface IBaseRepository<T>
{
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(int id);
    Task Create(T entity);
    void Update(T entity);
    Task TagAsDeleted(int id);
    Task Delete(int id);


    Task<bool> SaveChangesAsync();
}
