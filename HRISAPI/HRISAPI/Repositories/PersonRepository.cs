namespace HRISAPI.Repositories;

public class PersonRepository : BaseRepository<PersonModel>, IPersonRepository
{
    public PersonRepository(HRISDbContext context) : base(context)
    {

    }
}
