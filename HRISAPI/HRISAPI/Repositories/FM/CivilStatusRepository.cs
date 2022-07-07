namespace HRISAPI.Repositories.FM;

public class CivilStatusRepository : BaseRepository<CivilStatus>, ICivilStatusRepository
{
    public CivilStatusRepository(HRISDbContext context) : base(context)
    {
    }
}
