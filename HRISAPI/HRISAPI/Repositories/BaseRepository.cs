
namespace HRISAPI.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly HRISDbContext _context;
    private readonly DbSet<T> _entities;

    public BaseRepository(HRISDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _entities = context.Set<T>();
    }
    public void Create(T entity)
    {
        _entities.Add(entity);
    }
    public void Update(T entity)
    {
        _entities.Update(entity);
    }
    public async Task Delete(int id)
    {
        //var entities = await _entities.FindAsync(id);
        //var entities = await GetByIdAsync(id);       
        _entities.Remove(await GetByIdAsync(id));

    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }
    public async Task<T> GetByIdAsync(int id)
    {
        return await _entities.FindAsync(id);
    }
    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
    }
}
