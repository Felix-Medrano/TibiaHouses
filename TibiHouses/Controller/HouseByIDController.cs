using Models;

using Services;

using System.Threading.Tasks;

namespace TibiHouses.Controller
{
  public class HouseByIDController
  {
    private HTTPService _service;
    public HouseByIDController() { _service = new HTTPService(); }

    /// <summary>
    /// Get Houses By Id
    /// </summary>
    /// <param name="world">World NAme</param>
    /// <param name="id">ID Number</param>
    /// <returns>Houses By Id</returns>
    public async Task<HouseByID> GetHouseByID(string world = "Secura", int id = 35019)
    {
      HouseByID house = await _service.Get<HouseByID>(Properties.Settings.Default.apiURLHouse + world + "/" + id.ToString());
      return house;
    }
  }
}
