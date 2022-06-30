
namespace HRISAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : BaseModel
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
            var entities = await _repository.GetByIdAsync(id);
            if (entities == null)
            {
                return NotFound();
            }
            return Ok(entities);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] T entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _repository.CreateAsync(entity);
            return Ok(await _repository.SaveChangesAsync());
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] T entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _repository.Update(entity);

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
}
