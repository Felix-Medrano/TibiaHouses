using Models;

using Services;

using System.Threading.Tasks;

namespace TibiHouses.Controller
{
  internal class WorldController
  {

    private HTTPService _service;
    public WorldController() { _service = new HTTPService(); }

    /// <summary>
    /// Get a list of all Worlds (Servers)
    /// </summary>
    /// <returns>A list of all Worlds (Servers)</returns>
    public async Task<World> GetWorld()
    {
      World world = await _service.Get<World>(Properties.Settings.Default.apiURLWorld + "worlds");
      return world;
    }
  }

}
