using CitiesBlazorProgressive.Server.Services;
using CitiesBlazorProgressive.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;

namespace CitiesBlazorProgressive.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        IRepositoryAsync _repo;
        private readonly ILogger<CitiesController> _logger;

        public CitiesController(IRepositoryAsync repo, ILogger<CitiesController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var result = await _repo.GetAsync();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var city = await _repo.GetAsync(id);

            if(city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpGet("MaxId")]
        public async Task<IActionResult> GetMaxId()
        {
            return Ok((await _repo.GetAsync()).Max(x => x.ID));
        }

        [HttpPost]
        public async Task<IActionResult> Post(City city) => await _repo.InsertAsync(city) == true ? Ok() : BadRequest();

        [HttpPut]
        public async Task<IActionResult> Put(City city) => await _repo.UpdateAsync(city) == true ? Ok() : BadRequest();

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => await _repo.DeleteAsync(id) == true ? Ok() : BadRequest();        
    }
}
