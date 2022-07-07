
namespace HRISAPI.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
{
    protected readonly HRISDbContext _context;
    private readonly DbSet<T> _table;

    public BaseRepository(HRISDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _table = context.Set<T>();
    }

    public async Task CreateAsync(T entity)
    {
        await _table.AddAsync(entity);       
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _table.ToListAsync();
    }

    public async Task<T> GetByIdAsync(object id)
    {
        return await _table.FindAsync(id);
    }

    public async Task UpdateAsync(object id, object entity)
    {
        var table = await GetByIdAsync(id);
        if (table != null)
        {
            _context.Entry(table).CurrentValues.SetValues(entity);      
        }
    }

    public async Task DeleteAsync(object id)
    {
        var _entity = await GetByIdAsync(id);
        if (_entity != null)
        {
            _table.Remove(_entity);           
        }      
    }
      
    public async Task TagIsDeleted(object id)
    {
        var entities = await GetByIdAsync(id);
        entities.IsDel = true;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
    }


}
