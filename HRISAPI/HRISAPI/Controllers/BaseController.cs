namespace HRISAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

[Authorize]
public class BaseController<T> : ControllerBase
{
    private readonly IBaseRepository<T> _repository;

    public BaseController(IBaseRepository<T> repository)
    {
        _repository = repository;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<T>>> GetAll()
    {
        return Ok(await _repository.GetAll());
    }

    [HttpGet("GetById/{id}")]
    public async Task<ActionResult<T>> GetById(int id)
    {
        var entity = await _repository.GetById(id);
        if (entity == null)
        {
            return NotFound();
        }
        return Ok(entity);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] T entity)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _repository.Create(entity);
        return Ok(await _repository.SaveChangesAsync());
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] T entity)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _repository.Update(entity);
        return Ok(await _repository.SaveChangesAsync());
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.Delete(id);
        return Ok(await _repository.SaveChangesAsync());
    }

    [HttpPut("TagAsDeleted/{id}")]
    public async Task<IActionResult> TagAsDeleted(int id)
    {
        await _repository.TagAsDeleted(id);
        return Ok(await _repository.SaveChangesAsync());
    }
}
