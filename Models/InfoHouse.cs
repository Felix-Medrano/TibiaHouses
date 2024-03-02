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
    private string time_Left = string.Empty;
    private HouseStates state = HouseStates.None;

    public int ID { get => iD; set => iD = value; }
    public string Time_Left { get => time_Left; set => time_Left = value; }
    public HouseStates State { get => state; set => state = value; }
  }
}
