



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
        public async Task<IActionResult> Create([FromBody] T entity)
        {
            _repository.Create(entity);
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

    }
}
