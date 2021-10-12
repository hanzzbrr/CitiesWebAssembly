using CitiesBlazorProgressive.Services;
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
        private readonly DataContext _context;
        private readonly ILogger<CitiesController> _logger;

        public CitiesController(DataContext context, ILogger<CitiesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Get list of all cities
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<City> Get()
        {
            return _context.Cities;
        }

        [HttpGet("{id}", Name = "Get")]
        public City Get(int id)
        {
            return _context.Cities.FirstOrDefault(c => c.ID == id);
        }

        [HttpPost]
        [Produces("application/json")]
        public void Post([FromBody] City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] City city)
        {
            _context.Cities.Update(city);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _context.Cities.FirstOrDefault(c => c.ID == id);
            if(item != null)
            {
                _context.Cities.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
