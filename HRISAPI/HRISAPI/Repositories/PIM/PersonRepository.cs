namespace HRISAPI.Repositories.PDS;

public class PersonRepository : BaseRepository<Person>, IPersonRepository
{
    public PersonRepository(HRISDbContext context) : base(context)
    {

    }
    
}
