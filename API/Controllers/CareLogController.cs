using Application.DTO;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareLogController : ControllerBase
    {
        private readonly ICareLogRepository _ICareLogRepository;
        public CareLogController(ICareLogRepository careLogRepository)
        {
            _ICareLogRepository = careLogRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CareLogDto>>> GetAll()
        {
            var CareLog = await _ICareLogRepository.GetAllAsync();
            return Ok(CareLog);


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CareLogDto>> GetById(int id)
        {
            var careLog = await _ICareLogRepository.GetByIdAsync(id);
            if (careLog == null) return NotFound();
            
                
            
            return Ok(careLog);
        }

        
        [HttpPost]
        public async Task<ActionResult> Careate([FromBody] CareLogDto careLog)
        {
            if ( careLog == null)
            {
                return BadRequest("Service data is null.");
            }
            await _ICareLogRepository.AddAsync(careLog);
            return CreatedAtAction(nameof(GetById), new { id = careLog.Id }, careLog);

     
        }

        // PUT api/<CareLogController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] CareLogDto careLog)
        {
            if (id != careLog.Id ) return BadRequest("CareLog data is invalid.");
          
            var existingCareLog = await _ICareLogRepository.GetByIdAsync(id);
            if (existingCareLog == null)
            {
                return NotFound();
            }
            await _ICareLogRepository.UpdateAsync(careLog);
            return NoContent();
        }

        // DELETE api/<CareLogController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingCareLog = await _ICareLogRepository.GetByIdAsync(id);
            if (existingCareLog == null)
            {
                return NotFound();
            }
            await _ICareLogRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
