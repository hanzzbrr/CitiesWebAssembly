using CitiesBlazorProgressive.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CitiesBlazorProgressive.Server.Hubs
{
    public interface ICitiesHub
    {
        Task SendCities(IEnumerable<City> city);
    }
}
