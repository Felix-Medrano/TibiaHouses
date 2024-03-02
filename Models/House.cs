using System.Collections.Generic;

namespace Models
{
  public class Auction
  {
    public int current_bid { get; set; }
    public string time_left { get; set; }
    public bool finished { get; set; }
  }

  public class GuildhallList
  {
    public string name { get; set; }
    public int house_id { get; set; }
    public int size { get; set; }
    public int rent { get; set; }
    public bool rented { get; set; }
    public bool auctioned { get; set; }
    public Auction auction { get; set; }
  }

  public class HouseList
  {
    public string name { get; set; }
    public int house_id { get; set; }
    public int size { get; set; }
    public int rent { get; set; }
    public bool rented { get; set; }
    public bool auctioned { get; set; }
    public Auction auction { get; set; }
  }

  public class Houses
  {
    public string world { get; set; }
    public string town { get; set; }
    public List<HouseList> house_list { get; set; }
    public List<GuildhallList> guildhall_list { get; set; }
  }

  public class House
  {
    public Houses houses { get; set; }
  }
}
