using CitiesBlazorProgressive.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesBlazorProgressive.Server.Services
{
    public interface ICitiesHub
    {
        Task SendCityInfo(IEnumerable<City> city);
        Task CityHubMessage(string msg);
    }
}
