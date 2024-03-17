using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TibiHouses.Extra
{
  internal class ExtensionMethods
  {
    //Do Nothing, only for init method
  }

  public static class StringExtensions
  {
    public static void SendMbox(this string message)
    {
      MessageBox.Show(message);
    }

    public static void SendMbox(this int message)
    {
      MessageBox.Show(message.ToString());
    }

    public static void SendMboxList<T>(this IEnumerable<T> list)
    {
      int i = 1;
      StringBuilder sb = new StringBuilder();
      foreach (T item in list)
      {
        sb.AppendLine($"Valor #{i}: {item}");
        i++;
      }
      MessageBox.Show(sb.ToString());
    }
  }

  public static class BoolExtensions
  {

  }
}
