using HRISAPI.Models.PDS;

namespace HRISAPI.Controllers.PDS;

public class PersonController : BaseController<PersonModel>
{
    public PersonController(IBaseRepository<PersonModel> repository) : base(repository)
    {

    }
}
