using HRISAPI.Contracts.PDS;
using HRISAPI.Models.PDS;

namespace HRISAPI.Repositories.PDS;

public class PersonRepository : BaseRepository<PersonModel>, IPersonRepository
{
    public PersonRepository(HRISDbContext context) : base(context)
    {

    }
}
