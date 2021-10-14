using CitiesBlazorProgressive.Server.Data;
using CitiesBlazorProgressive.Server.Hubs;
using CitiesBlazorProgressive.Shared;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesBlazorProgressive.Server.Services
{
    public class CitiesRepository : IRepositoryAsync
    {        

        private readonly DataContext _dbContext;
        private readonly IHubContext<CitiesHub, ICitiesHub> _hubContext;

        public List<City> Cities => _dbContext.Cities.ToList();

        public CitiesRepository(DataContext dbContext, IHubContext<CitiesHub, ICitiesHub> hubContext)
        {
            _dbContext = dbContext;
            _hubContext = hubContext;
        }

        public async Task<IEnumerable<City>> GetAsync()
        {
            return await _dbContext.Cities.ToListAsync();
        }

        public async Task<City> GetAsync(int id)
        {
            return await _dbContext.Cities.FirstOrDefaultAsync(c => c.ID == id);
        }

        public async Task<bool> InsertAsync(City city)
        {
            await _dbContext.Cities.AddAsync(city);
            await _dbContext.SaveChangesAsync();
            await _hubContext.Clients.All.SendCities(_dbContext.Cities);
            return true;
        }

        public async Task<bool> UpdateAsync(City city)
        {
            _dbContext.Cities.Update(city);
            await _dbContext.SaveChangesAsync();
            await _hubContext.Clients.All.SendCities(_dbContext.Cities);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            City city = await _dbContext.Cities.FirstOrDefaultAsync(c => c.ID == id);
            _dbContext.Attach(city);
            _dbContext.Remove(city);
            await _dbContext.SaveChangesAsync();
            await _hubContext.Clients.All.SendCities(_dbContext.Cities);
            return true;
        }

        public async Task<bool> DeleteAsync(City city)
        {
            _dbContext.Remove(city);
            await _dbContext.SaveChangesAsync();
            await _hubContext.Clients.All.SendCities(_dbContext.Cities);
            return true;
        }

    }
}
