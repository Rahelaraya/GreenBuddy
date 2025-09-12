using Application.DTO;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
       private readonly IPlantsRepository _plantsRepository;
        public PlantsController(IPlantsRepository plantsRepository)
        {
            _plantsRepository = plantsRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var plants = await _plantsRepository.GetAllAsync();
            return Ok(plants);
        }

        // GET api/<PlantsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var plant = await _plantsRepository.GetByIdAsync(id);
            if (plant == null)
            {
                return NotFound();
            }
            return Ok(plant);
        }
        // POST api/<PlantsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PlantsDto plantDto)
        {
            if (plantDto == null)
            {
                return BadRequest("Your request data is null.");
            }
            await _plantsRepository.AddAsync(plantDto);
            return CreatedAtAction(nameof(Get), new { id = plantDto.Id }, plantDto);
        }

        // PUT api/<PlantsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PlantsDto plantDto)
        {
            if (plantDto == null || plantDto.Id != id)
            {
                return BadRequest("Invalid plant data.");
            }
            var Plant = await _plantsRepository.GetByIdAsync(id);
            if (Plant == null)
            {
                return NotFound();
            }
            await _plantsRepository.UpdateAsync(plantDto);
            return NoContent();
        }

        // DELETE api/<PlantsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Plant = await _plantsRepository.GetByIdAsync(id);
            if (Plant == null)
            {
                return NotFound();
            }
            await _plantsRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
