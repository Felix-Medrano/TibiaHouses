using Models;

using Services;

using System.Threading.Tasks;

namespace TibiHouses.Controller
{
  internal class HouseController
  {
    private HTTPService _service;
    public HouseController() { _service = new HTTPService(); }

    /// <summary>
    /// Get two List, Houses and Guild Halls
    /// </summary>
    /// <param name="world">World Name</param>
    /// <param name="city">City Name</param>
    /// <returns>Two List, Houses and Guild Halls</returns>
    public async Task<House> GetHouses(string world = "Secura", string city = "Venore")
    {
      House house = await _service.Get<House>(Properties.Settings.Default.apiURLHouses + world + "/" + city);
      return house;
    }
  }
}
