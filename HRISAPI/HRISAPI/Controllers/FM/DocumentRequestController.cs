
namespace HRISAPI.Controllers.FM
{

    public class DocumentRequestController : BaseController<BloodType>
    {
        public DocumentRequestController(IBaseRepository<BloodType> repository) : base(repository)
        {

        }
    }
}
