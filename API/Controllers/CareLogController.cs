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
        // GET: api/<CareLogController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CareLogDto>>> GetAll()
        {
            var CareLog = await _ICareLogRepository.GetAllAsync();
            return Ok(CareLog);


        }

        // GET api/<CareLogController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CareLogController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CareLogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CareLogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
