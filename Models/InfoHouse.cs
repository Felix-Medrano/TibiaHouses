namespace Models
{
  public enum HouseStates
  {
    None = 0,
    Auctioned,
    Moving,
    Rented,
    Transfering
  }

  public class InfoHouse
  {

    private int iD = 0;
    private string name = string.Empty;
    private string time_Left = string.Empty;
    private string town = string.Empty;
    private string world = string.Empty;
    private HouseStates state = HouseStates.None;

    public int ID { get => iD; set => iD = value; }
    public string Name { get => name; set => name = value; }
    public string Time_Left { get => time_Left; set => time_Left = value; }
    public string Town { get => town; set => town = value; }
    public string World { get => world; set => world = value; }
    public HouseStates State { get => state; set => state = value; }
  }
}
