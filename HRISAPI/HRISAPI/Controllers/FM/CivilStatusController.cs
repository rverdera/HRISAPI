namespace HRISAPI.Controllers.FM;


[AllowAnonymous]
public class CivilStatusController : BaseController<CivilStatus>
{
    private readonly ICivilStatusRepository _repository;

    public CivilStatusController(ICivilStatusRepository repository) : base(repository)
    {
        _repository = repository;
    }

    [HttpPost("AddNew")]
    public async Task<IActionResult> CreateCivilStatus(CivilStatus civilStatus)
    {
        _repository.CreateCivilStatus(civilStatus);
        
        return Ok(await _repository.SaveChangesAsync());
    }
   

}
