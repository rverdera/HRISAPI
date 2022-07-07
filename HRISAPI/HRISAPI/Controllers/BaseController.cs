namespace HRISAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController<T> : ControllerBase
{
    private readonly IBaseRepository<T> _repository;

    public BaseController(IBaseRepository<T> repository)
    {
        _repository = repository;
    }

    [HttpGet("GetAllAsync")]
    public async Task<ActionResult<IEnumerable<T>>> GetAllAsync()
    {
        return Ok(await _repository.GetAllAsync());
    }

    [HttpGet("GetByIdAsync/{id}")]
    public async Task<ActionResult<T>> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return NotFound();
        }
        return Ok(entity);
    }

    [HttpPost("CreateAsync")]
    public async Task<IActionResult> CreateAsync([FromBody] T entity)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _repository.CreateAsync(entity);
        return Ok(await _repository.SaveChangesAsync());
    }

    [HttpPut("UpdateAsync/{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] T entity)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _repository.UpdateAsync(id,entity);
        return Ok(await _repository.SaveChangesAsync());
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
        return Ok(await _repository.SaveChangesAsync());
    }

    [HttpPut("TagIsDeleted/{id}")]
    public async Task<IActionResult> TagIsDeletedAsync(int id)
    {                 
        await _repository.TagIsDeleted(id);
        return Ok(await _repository.SaveChangesAsync());
    }

}
