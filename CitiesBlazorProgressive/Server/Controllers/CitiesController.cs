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

        /// <summary>
        /// Get list of all cities
        /// </summary>
        /// <returns></returns>
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

        public async Task<IActionResult> PostCity(City city)
        {
            await  _citiesService.InsertCityAsync(city);
            return Ok();
        }
    }
}
