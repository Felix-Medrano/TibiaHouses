using Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Navigation;

using TibiHouses.Controller;
using TibiHouses.Core;
using TibiHouses.Extra;
using TibiHouses.Lib;

using TreeNode = System.Windows.Forms.TreeNode;
using TreeView = System.Windows.Forms.TreeView;

namespace TibiHouses
{
  public partial class Main : Form
  {

    private House house = new House();

    private HouseByIDController houseByIDController = new HouseByIDController();
    private HouseController houseController = new HouseController();
    private WorldController worldController = new WorldController();

    private Helper helper = new Helper();

    private List<string> cities = new List<string>{
    THStrings.Towns.AB_DENDRIEL,
    THStrings.Towns.ANKRAHMUN,
    THStrings.Towns.CARLIN,
    THStrings.Towns.DARASHIA,
    THStrings.Towns.EDRON,
    THStrings.Towns.FARMINE,
    THStrings.Towns.GRAY_BEACH,
    THStrings.Towns.ISSAVI,
    THStrings.Towns.KAZORDOON,
    THStrings.Towns.LIBERTY_BAY,
    THStrings.Towns.MOONFALL,
    THStrings.Towns.PORT_HOPE,
    THStrings.Towns.RATHLETON,
    THStrings.Towns.SILVERTIDES,
    THStrings.Towns.SVARGROND,
    THStrings.Towns.THAIS,
    THStrings.Towns.VENORE,
    THStrings.Towns.YALAHAR
    };
    private Dictionary<string, Dictionary<int, GuildhallList>> cityGHDicc = new Dictionary<string, Dictionary<int, GuildhallList>>();
    private Dictionary<string, Dictionary<int, HouseList>> cityHouseDicc = new Dictionary<string, Dictionary<int, HouseList>>();
    private Dictionary<string, string> worldStateDicc = new Dictionary<string, string>();
    private Dictionary<string, bool> worldFavDicc = new Dictionary<string, bool>();

    private THEnums.FavState favState = THEnums.FavState.None;

    private bool refres = false;

    private string town = string.Empty;
    private string lastWorld = string.Empty;

    //===================================================
    //Constants
    private int HOUSE_IMG_HEIGHT = 150;
    private int HOUSE_IMG_WIDTH = 150;

    public Main()
    {
      InitializeComponent();
    }

    private async void Main_Load(object sender, EventArgs e)
    {
      tsProgressStatus.Visible = false;
      tsLblLoadStatus.Visible = true;
      tsLblLoadStatus.Text = "Conectando al servidor";
      await GetWorlds();
      worldList.DrawItem += worldList_DrawItem;
      for (int i = 0; i < worldList.Items.Count - 1; i++)
      {
        if (worldFavDicc[worldList.Items[i].ToString()])
        {
          worldList.SelectedIndex = i;
          chServerFav.Checked = true;
          break;
        }
      }
      await PreLoadHouses();

    }

    private async Task<bool> GetWorlds()
    {
      tsLblLoadStatus.Text = "Cargando Mundos";
      var worlds = await worldController.GetWorld();
      var index = 0;
      tsLblLoadStatus.Text = "Se Cargaron los mundos";
      foreach (var world in worlds.worlds.regular_worlds)
      {
        worldList.Items.Add(world.name);
        worldStateDicc.Add(world.name, world.status);
        worldFavDicc.Add(world.name, world.name == Properties.Settings.Default.favWorld ? true : false);
        index++;
      }
      worldList.Enabled = true;
      btnBuscar.Enabled = true;
      worldList.Text = worldList.Items[0].ToString();

      return true;
    }

    private async Task<bool> PreLoadHouses()
    {
      if (lastWorld != worldList.Text || refres)
      {
        cityHouseDicc.Clear();
        cityGHDicc.Clear();
        ActiveComponents(false);
        CleanHouseInfo();
        tsLblLoadStatus.Text = "Cargando las Ciudades";
        await Task.Delay(500);
        tsProgressStatus.Visible = true;
        tsLblLoadStatus.Visible = true;
        tsProgressStatus.Maximum = cities.Count;
        tsProgressStatus.Value = 0;
        foreach (var city in cities)
        {
          tsLblLoadStatus.Text = "Cargando la ciudad de " + city;
          var cityText = string.Empty;
          house = await houseController.GetHouses(worldList.Text, city);
          if (house == null)
            cityText = city + THStrings.ExtraInfo.ERROR_DE_CARGA;
          else
            cityText = city;
          Dictionary<int, HouseList> housesDicc = new Dictionary<int, HouseList>();
          Dictionary<int, GuildhallList> guildHallsDicc = new Dictionary<int, GuildhallList>();
          if (house != null && house.houses != null && house.houses.house_list != null)
          {
            int index = 0;
            foreach (var house in house.houses.house_list)
            {
              housesDicc.Add(index, house);
              index++;
            }
          }
          cityHouseDicc.Add(city, housesDicc);

          if (house != null && house.houses != null && house.houses.guildhall_list != null)
          {
            int index = 0;
            foreach (var house in house.houses.guildhall_list)
            {
              guildHallsDicc.Add(index, house);
              index++;
            }
          }
          cityGHDicc.Add(city, guildHallsDicc);
          await Task.Delay(100);
          refres = false;
          tsProgressStatus.Value++;
        }
        tsLblLoadStatus.Text = "Carga Completa";
        timerToolStripReset.Enabled = true;
      }

      lastWorld = worldList.Text;

      if (radHouses.Checked)
      {
        foreach (var cityCache in cityHouseDicc)
        {
          TreeNode treeNode = new TreeNode(cityCache.Key);
          int index = 0;
          foreach (var houseCache in cityCache.Value)
          {
            index = GetHouseCache(index, houseCache.Value, treeNode, cityCache.Key);
          }
          housesList.Nodes.Add(treeNode);
        }
      }

      if (radGuildHalls.Checked)
      {
        foreach (var cityCache in cityGHDicc)
        {
          TreeNode treeNode = new TreeNode(cityCache.Key);
          int index = 0;
          foreach (var houseCache in cityCache.Value)
          {
            index = GetHouseCache(index, houseCache.Value, treeNode, cityCache.Key);
          }
          housesList.Nodes.Add(treeNode);
        }
      }

      lastWorld = worldList.Text;
      ActiveComponents(true);
      return true;
    }

    private async void btnBuscar_Click(object sender, EventArgs e)
    {
      housesList.Nodes.Clear();
      ActiveComponents(false);
      await PreLoadHouses();
      ActiveComponents(true);
    }

    private void ActiveComponents(bool state)
    {
      foreach (Control item in this.Controls)
      {
        var stringType = item.GetType().ToString().Split('.');
        if (stringType.Last() != THStrings.Types.STATUS_STRIP)
        {
          item.Enabled = state;
        }
      }
    }

    private async void housesList_AfterSelect(object sender, TreeViewEventArgs e)
    {
      var url = string.Empty;
      var statusText = string.Empty;
      var infoHouse = e.Node.Tag as InfoHouse;
      ActiveComponents(false);
      CleanHouseInfo();
      if (infoHouse != null)
      {
        HouseByID houseByID = await houseByIDController.GetHouseByID(infoHouse.World, infoHouse.ID);
        if (houseByID != null)
        {
          url = houseByID.house.img;
          lblBeds.Text = THStrings.HouseInfoPrefix.BEDS + houseByID.house.beds.ToString();
          lblSize.Text = THStrings.HouseInfoPrefix.SIZE + houseByID.house.size.ToString();
          lblRent.Text = THStrings.HouseInfoPrefix.RENT + houseByID.house.rent.ToString();
          lblHouseStatus.Text = THStrings.HouseStatus.STATUS;


          if (houseByID.house.status.is_auctioned)
          {
            lblHouseStatus.Text += THStrings.HouseStatus.AUCTIONED;
            if (houseByID.house.status.auction.auction_ongoing == true)
              statusText =
                THStrings.HouseInfoPrefix.CURRENT_BID + houseByID.house.status.auction.current_bid.ToString("N2") + "\n" +
                THStrings.HouseInfoPrefix.CURRENT_BIDER + houseByID.house.status.auction.current_bidder + "\n" +
                THStrings.HouseInfoPrefix.TIME_LEFT + infoHouse.Time_Left + "\n";
            else
              statusText = THStrings.HouseStatus.NO_OFFERS;
          }

          if (houseByID.house.status.is_rented)
          {
            lblHouseStatus.Text += THStrings.HouseStatus.RENTED;
            var paidFullDate = houseByID.house.status.rental.paid_until.Split('T');
            var paidDate = paidFullDate[0].Split('-');
            statusText =
                THStrings.HouseInfoPrefix.OWNER + houseByID.house.status.rental.owner + "\n" +
                THStrings.HouseInfoPrefix.PAID_UNTIL + paidDate[2] + "/" + paidDate[1] + "/" + paidDate[0] + "\n";
            if (houseByID.house.status.is_transfering == true)
            {
              paidFullDate = houseByID.house.status.rental.moving_date.Split('T');
              paidDate = paidFullDate[0].Split('-');
              lblHouseStatus.Text += THStrings.HouseStatus.TRANSFERING;
              statusText +=
                THStrings.HouseInfoPrefix.TRANSFER_RECEIVER + houseByID.house.status.rental.transfer_receiver + "\n" +
                THStrings.HouseInfoPrefix.TRANSFER_PRICE + houseByID.house.status.rental.transfer_price.ToString("N2") + "\n" +
                THStrings.HouseInfoPrefix.MOVING_DATE + paidDate[2] + "/" + paidDate[1] + "/" + paidDate[0] + "\n" +
                (houseByID.house.status.rental.transfer_accept == true ?
                THStrings.HouseStatus.ACCEPTED : THStrings.HouseStatus.PENDING);
            }
          }

          lblStatusInfo.Text = statusText;
        }
        else
          url = Properties.Settings.Default.errorURL;
        houseImg.DocumentText =
        "<body style= \"margin: 0px; background-color: rgb(240, 240, 240);\">\n" +
        $"\t<img style= \"border: 2px;\" src= {url} width= {HOUSE_IMG_WIDTH} height= {HOUSE_IMG_HEIGHT}>\n";
        houseImg.Height = HOUSE_IMG_HEIGHT;
        houseImg.Width = HOUSE_IMG_WIDTH;
      }
      ActiveComponents(true);
      housesList.Select();
    }

    private int GetHouseCache(int index, HouseList house, TreeNode treeNode, string city)
    {
      InfoHouse infoHouse = new InfoHouse();
      if (house != null)
      {
        if (chAuctioned.Checked)
        {
          if (house.auctioned)
            treeNode.Nodes.Add(house.name);
          else
            return index;
        }
        else
          treeNode.Nodes.Add(house.name);

        infoHouse.ID = house.house_id;
        infoHouse.Town = city;
        infoHouse.Name = house.name;
        infoHouse.World = lastWorld;
        infoHouse.Time_Left = house.auction.time_left;

        treeNode.Nodes[index].Tag = infoHouse;

        return ++index;
      }
      return index;
    }

    private int GetHouseCache(int index, GuildhallList house, TreeNode treeNode, string city)
    {
      InfoHouse infoHouse = new InfoHouse();
      if (house != null)
      {
        if (chAuctioned.Checked)
        {
          if (house.auctioned)
            treeNode.Nodes.Add(house.name);
          else
            return index;
        }
        else
          treeNode.Nodes.Add(house.name);

        infoHouse.ID = house.house_id;
        infoHouse.Town = city;
        infoHouse.Name = house.name;
        infoHouse.World = lastWorld;
        infoHouse.Time_Left = house.auction.time_left;

        treeNode.Nodes[index].Tag = infoHouse;

        return ++index;
      }
      return index;
    }

    private async void btnRefreshAll_Click(object sender, EventArgs e)
    {
      refres = true;
      CleanHouseInfo();
      housesList.Nodes.Clear();
      await PreLoadHouses();
    }

    private void CleanHouseInfo()
    {
      houseImg.DocumentText = string.Empty;
      lblBeds.Text = THStrings.HouseInfoPrefix.BEDS;
      lblSize.Text = THStrings.HouseInfoPrefix.SIZE;
      lblRent.Text = THStrings.HouseInfoPrefix.RENT;
      lblHouseStatus.Text = THStrings.HouseInfoPrefix.STATUS;
      lblStatusInfo.Text = string.Empty;
    }

    private void worldList_DrawItem(object sender, DrawItemEventArgs e)
    {
      helper.ComboBoxDraw(worldStateDicc, sender, e);
    }

    private void chServerFav_CheckedChanged(object sender, EventArgs e)
    {
      if (worldList.Text != Properties.Settings.Default.favWorld && chServerFav.Checked == true)
      {
        var response = MessageBox.Show("Quieres cambiar de server favorito?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (response == DialogResult.Yes)
        {
          worldFavDicc[Properties.Settings.Default.favWorld] = false;
          Properties.Settings.Default.favWorld = worldList.Text;
          Properties.Settings.Default.Save();
          worldFavDicc[Properties.Settings.Default.favWorld] = true;
          worldList.Refresh();

        }
      }
    }

    private void worldList_SelectedIndexChanged(object sender, EventArgs e)
    {
      bool state = false;
      if (worldList.Text != Properties.Settings.Default.favWorld) state = false;
      else state = true;

      chServerFav.Checked = state;
    }

    private void timerToolStripReset_Tick(object sender, EventArgs e)
    {
      tsProgressStatus.Visible = false;
      tsLblLoadStatus.Visible = false;
      timerToolStripReset.Enabled = false;
    }

    private void tsBtnFav_Click(object sender, EventArgs e)
    {
      TreeNode cityNode = null;
      TreeNode houseNode = null;
      TreeNode worldNode = null;

      bool canAddNode = true;

      int worldIndex = 0;
      int cityIndex = 0;

      InfoHouse infoHouse = housesList.SelectedNode.Tag as InfoHouse;

      houseNode = new TreeNode(infoHouse.Name);
      houseNode.Tag = infoHouse;

      if (favoriteList.Nodes.Count > 0)
      {
        foreach (TreeNode world in favoriteList.Nodes)//Recorrer la lista para verificar si el server ya existe
        {
          if (world.Text == infoHouse.World) // Si el Server a agregar ya existe en la lista, se iguala worldNode a world
          {
            worldNode = world;
            break;
          }
          worldIndex++;
        }
        if (worldNode == null)
        {
          favoriteList.Nodes.Add(infoHouse.World);
          worldNode = favoriteList.Nodes[worldIndex];
        }

        foreach (TreeNode city in worldNode.Nodes)//Recorrer Ciudades
        {
          if (city.Text == infoHouse.Town) //Si la ciudad existe, se iguala el nodo general al nodo comparado
          {
            cityNode = city;
            break;
          }
          cityIndex++;
        }

        if (cityNode == null)
        {
          favoriteList.Nodes[worldIndex].Nodes.Add(infoHouse.Town);
          cityNode = favoriteList.Nodes[worldIndex].Nodes[cityIndex];
        }

          


      }

      switch (favState)
      {
        case THEnums.FavState.None:
          break;
        case THEnums.FavState.AddFavorite:
          if (favoriteList.Nodes.Count != 0)
          {
            favoriteList.Nodes[worldIndex].Nodes[cityIndex].Nodes.Add(houseNode);
          }
          else
          {
            cityNode = new TreeNode(infoHouse.Town);
            worldNode = new TreeNode(infoHouse.World);

            cityNode.Nodes.Add(houseNode);
            worldNode.Nodes.Add(cityNode);

            favoriteList.Nodes.Add(worldNode);

            //ADD: favoriteList.Sort(); ======= Arreglar logica de Add, no se agrega correctamente si se aplica Sort
          }
          break;
        case THEnums.FavState.RemoveFavorite:
          foreach (TreeNode _houseNode in favoriteList.Nodes[worldIndex].Nodes[cityIndex].Nodes)
          {
            if (_houseNode.Text == houseNode.Text)
            {
              houseNode = _houseNode;
            }
          }
          favoriteList.Nodes[worldIndex].Nodes[cityIndex].Nodes.Remove(houseNode);
          if (favoriteList.Nodes[worldIndex].Nodes[cityIndex].Nodes.Count == 0)
          {
            favoriteList.Nodes[worldIndex].Nodes.Remove(favoriteList.Nodes[worldIndex].Nodes[cityIndex]);
          }
          if (favoriteList.Nodes[worldIndex].Nodes.Count == 0)
          {
            favoriteList.Nodes.Remove(favoriteList.Nodes[worldIndex]);
          }
          break;
        default:
          break;
      }
    }

    private void housesList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
      var obj = sender as TreeView;
      obj.SelectedNode = e.Node;
      switch (e.Button)
      {
        case MouseButtons.Left:
          break;
        case MouseButtons.None:
          break;
        case MouseButtons.Right:
          //revisar si ya esta en lista de favoritos
          if (favoriteList.Nodes.Count != 0)
          {
            foreach (TreeNode worldNode in favoriteList.Nodes)
            {
              if (worldNode.Text == lastWorld) //Si ya existe el server, rrecorre las ciudades
              {
                foreach (TreeNode cityNode in worldNode.Nodes)
                {
                  if (cityNode.Text == obj.SelectedNode.Parent.Text) //Si la ciudad ya existe, se rrecorre las casas
                  {
                    foreach (TreeNode houseNode in cityNode.Nodes)
                    {
                      if (houseNode.Text == e.Node.Text) //Si existe, el menu cambia a "Eliminar Favorito"
                      {
                        tsBtnFav.Text = THStrings.FavoriteStr.REMOVE_FAVORITE;
                        favState = THEnums.FavState.RemoveFavorite;
                        break; //si existe se, se rompe el ciclo
                      }
                      else
                      {
                        tsBtnFav.Text = THStrings.FavoriteStr.ADD_FAVORITE;
                        favState = THEnums.FavState.AddFavorite;
                      }
                    }
                    break;
                  }
                  else
                  {
                    tsBtnFav.Text = THStrings.FavoriteStr.ADD_FAVORITE;
                    favState = THEnums.FavState.AddFavorite;
                  }
                }
                break;
              }
              else
              {
                tsBtnFav.Text = THStrings.FavoriteStr.ADD_FAVORITE;
                favState = THEnums.FavState.AddFavorite;
              }
            }
          }
          else // cambiar menu a "agregar"
          {
            tsBtnFav.Text = THStrings.FavoriteStr.ADD_FAVORITE;
            favState = THEnums.FavState.AddFavorite;
          }
          e.Node.ContextMenuStrip = nodeMenuStrip;
          break;
        case MouseButtons.Middle:
          break;
        case MouseButtons.XButton1:
          break;
        case MouseButtons.XButton2:
          break;
        default:
          break;
      }
    }
  }
}
