using Microsoft.Data.SqlClient;

namespace HRISAPI.Repositories.FM;

public class CivilStatusRepository : BaseRepository<CivilStatus>, ICivilStatusRepository
{
    public CivilStatusRepository(HRISDbContext context) : base(context)
    {

    }

    public void CreateCivilStatus(CivilStatus civilStatus)
    {
        var param = new SqlParameter[]
            {
                new SqlParameter("@Description",civilStatus.Description),
                new SqlParameter("@UserStamp",civilStatus.UserStamp),
                new SqlParameter("@IsActive",civilStatus.IsActive)
            };

        _context.Database.ExecuteSqlRaw("[dbo].[CivilStatusGetByID] @Description,@UserStamp,@IsActive", param);        
    }
}
