namespace HRISAPI.Repositories.FM;

public class BloodTypeRepository : BaseRepository<BloodTypeModel>, IBloodTypeRepository
{
    public BloodTypeRepository(HRISDbContext context) : base(context)
    {
    }
}
