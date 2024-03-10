using Models;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TibiHouses.Controller;
using TibiHouses.Core;

namespace TibiHouses.Lib
{
  public class Helper
  {
    public void ComboBoxDraw(Dictionary<string, string> worldStateDicc, object sender, DrawItemEventArgs e)
    {
      var obj = (ComboBox)sender;
      Image imgFavIcon = null;
      Image imgWorldState = null;
      var worldState = worldStateDicc[obj.Items[e.Index].ToString()];
      int textOffset = 0;
      var imgSize = new Size(12,12);

      e.DrawBackground();
      e.DrawFocusRectangle();

      if (obj.Items[e.Index].ToString() == Properties.Settings.Default.favWorld)
      {
        imgFavIcon = new Bitmap(Properties.Resources.favIcon, imgSize);
        e.Graphics.DrawImage(imgFavIcon, new PointF(e.Bounds.Left + 2, e.Bounds.Top));
        textOffset = 16;
      }

      e.Graphics.DrawString(string.Format("{0}", obj.Items[e.Index]), e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + textOffset, e.Bounds.Top);

      switch (worldState)
      {
        case THStrings.WorldExtraInfo.ONLINE:
          imgWorldState = new Bitmap(Properties.Resources.Online, imgSize);
          break;

        case THStrings.WorldExtraInfo.OFFNLINE:
          imgWorldState = new Bitmap(Properties.Resources.Offline, imgSize);
          break;

        default:
          //Do Nothing
          break;
      }

      e.Graphics.DrawImage(imgWorldState, new PointF(e.Bounds.Right - (imgWorldState.Width + 2), e.Bounds.Top));
    }
  }
}
