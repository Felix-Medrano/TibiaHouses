﻿using System;
using System.Collections.Generic;

namespace Models
{
  public class RegularWorld
  {
    public string name { get; set; }
    public string status { get; set; }
    public int players_online { get; set; }
    public string location { get; set; }
    public string pvp_type { get; set; }
    public bool premium_only { get; set; }
    public string transfer_type { get; set; }
    public bool battleye_protected { get; set; }
    public string battleye_date { get; set; }
    public string game_world_type { get; set; }
    public string tournament_world_type { get; set; }
  }

  public class World
  {
    public Worlds worlds { get; set; }
  }

  public class Worlds
  {
    public int players_online { get; set; }
    public int record_players { get; set; }
    public DateTime record_date { get; set; }
    public List<RegularWorld> regular_worlds { get; set; }
    public object tournament_worlds { get; set; }
  }


}
