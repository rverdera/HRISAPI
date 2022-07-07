namespace HRISAPI.Repositories.FM;

public class BloodTypeRepository : BaseRepository<BloodType>, IBloodTypeRepository
{
    public BloodTypeRepository(HRISDbContext context) : base(context)
    {

    }
}
