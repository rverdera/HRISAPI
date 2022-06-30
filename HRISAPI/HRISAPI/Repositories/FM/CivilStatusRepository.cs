namespace HRISAPI.Repositories.FM;

public class CivilStatusRepository : BaseRepository<CivilStatusModel>, ICivilStatusRepository
{
    public CivilStatusRepository(HRISDbContext context) : base(context)
    {
    }
}
