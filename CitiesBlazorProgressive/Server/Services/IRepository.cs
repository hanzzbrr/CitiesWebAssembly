using CitiesBlazorProgressive.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesBlazorProgressive.Server.Services
{
    public interface IRepositoryAsync
    {
        Task<IEnumerable<City>> GetAsync();
        Task<City> GetAsync(int id);
        Task<bool> InsertAsync(City city);
        Task<bool> UpdateAsync(City city);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(City city);
    }
}
