using HRISAPI.Models.PDS;

namespace HRISAPI.Controllers.PDS;

public class PersonController : BaseController<Person>
{
    public PersonController(IBaseRepository<Person> repository) : base(repository)
    {
        
    }
    
}
