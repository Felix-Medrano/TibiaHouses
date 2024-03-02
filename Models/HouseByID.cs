namespace Models
{
  public class AuctionHouse
  {
    public int current_bid { get; set; }
    public string current_bidder { get; set; }
    public bool auction_ongoing { get; set; }
    public string auction_end { get; set; }
  }

  public class HouseID
  {
    public int houseid { get; set; }
    public string world { get; set; }
    public string town { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public int beds { get; set; }
    public int size { get; set; }
    public int rent { get; set; }
    public string img { get; set; }
    public Status status { get; set; }
  }

  public class Rental
  {
    public string owner { get; set; }
    public string owner_sex { get; set; }
    public string paid_until { get; set; }
    public string moving_date { get; set; }
    public string transfer_receiver { get; set; }
    public int transfer_price { get; set; }
    public bool transfer_accept { get; set; }
  }

  public class HouseByID
  {
    public HouseID house { get; set; }
  }

  public class Status
  {
    public bool is_auctioned { get; set; }
    public bool is_rented { get; set; }
    public bool is_moving { get; set; }
    public bool is_transfering { get; set; }
    public AuctionHouse auction { get; set; }
    public Rental rental { get; set; }
    public string original { get; set; }
    public int http_code { get; set; }
  }


}
