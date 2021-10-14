using CitiesBlazorProgressive.Server.Data;
using CitiesBlazorProgressive.Server.Hubs;
using CitiesBlazorProgressive.Server.Services;
using CitiesBlazorProgressive.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesBlazorProgressive.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        CitiesService _citiesService;
        private readonly ILogger<CitiesController> _logger;

        public CitiesController(CitiesService citiesService, ILogger<CitiesController> logger)
        {
            _citiesService = citiesService;
            _logger = logger;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _citiesService.GetCitiesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var city = await _citiesService.GetCityAsync(id);

            if(city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpGet("MaxId")]
        public async Task<IActionResult> GetMaxId()
        {
            return Ok(await _citiesService.GetMaxId());
        }

        [HttpPost]
        public async Task<IActionResult> Post(City city)
        {
            await  _citiesService.InsertCityAsync(city);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(City city)
        {
            await _citiesService.UpdateCityAsync(city);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _citiesService.DeleteCityAsync(id);
            return Ok();
        }
    }
}
