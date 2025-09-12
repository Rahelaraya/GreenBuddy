using Application.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareTasksController : ControllerBase
    {
        private readonly ICareTasksRepository _careTasksRepository;
        public CareTasksController(ICareTasksRepository careTasksRepository)
        {
            _careTasksRepository = careTasksRepository;
        }

        [HttpGet]
       public async Task<IActionResult> Get()
        {
            var careTasks = await _careTasksRepository.GetAllAsync();
            return Ok(careTasks);
        }

        // GET api/<CareTasksController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var careTask = await _careTasksRepository.GetByIdAsync(id);
            if (careTask == null) return NotFound();
            return Ok(careTask);
        }

        // POST api/<CareTasksController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Application.DTO.CareTasksDto careTasksDto)
        {
            if (careTasksDto == null) return BadRequest();
            await _careTasksRepository.AddAsync(careTasksDto);
            return CreatedAtAction(nameof(Get), new { id = careTasksDto.Id }, careTasksDto);
        }

        // PUT api/<CareTasksController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Application.DTO.CareTasksDto careTasksDto)
        {
            if (careTasksDto == null || careTasksDto.Id != id) return BadRequest("ID mismatch");
            var existingCareTask = await _careTasksRepository.GetByIdAsync(id);
            if (existingCareTask == null) return NotFound();
            await _careTasksRepository.UpdateAsync(careTasksDto);
            return NoContent();
        }

        // DELETE api/<CareTasksController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingCareTask = await _careTasksRepository.GetByIdAsync(id);
            if (existingCareTask == null) return NotFound();
            await _careTasksRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
