using CitiesBlazorProgressive.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesBlazorProgressive.Server.Hubs
{
    public interface ICitiesHub
    {
        Task SendCities(IEnumerable<City> city);
        //Task CityHubMessage(string msg);
    }
}
