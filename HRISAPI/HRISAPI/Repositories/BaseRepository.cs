
namespace HRISAPI.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
{
    protected readonly HRISDbContext _context;
    protected readonly DbSet<T> _table;

    public BaseRepository(HRISDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _table = context.Set<T>();       
    }

    public async Task Create(T entity)
    {
        await _table.AddAsync(entity);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _table.ToListAsync();
    }

    public async Task<T?> GetById(int id)
    {     
        return await _table.FindAsync(id);
    }

    public void Update(T entity)
    {
        _table.Update(entity);
    }

    public async Task Delete(int id)
    {
        var _entity = await GetById(id);
        if (_entity != null)
        {
            _table.Remove(_entity);
        }
    }

    public async Task TagAsDeleted(int id)
    {
        var entities = await GetById(id);
        if(entities != null)
            entities.IsDel = true;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
    }
}
