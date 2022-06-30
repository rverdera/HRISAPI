
namespace HRISAPI.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
{
    protected readonly HRISDbContext _context;
    private readonly DbSet<T> _entities;

    public BaseRepository(HRISDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _entities = context.Set<T>();
    }
    public async Task CreateAsync(T entity)
    {
        await _entities.AddAsync(entity);
    }
    public void Update(T entity)
    {
        _entities.Update(entity);
    }
    public async Task DeleteAsync(int id)
    {
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
    public async Task TagIsDeleted(int id)
    {
        var entities = await GetByIdAsync(id);
        entities.IsDel = false;
    }
    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
    }

    
}
