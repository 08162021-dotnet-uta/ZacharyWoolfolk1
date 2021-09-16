using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppUILayer
{
  class PageMarker
  {
    internal Dictionary<int, List<string>> pages = new Dictionary<int, List<string>>();

    public PageMarker()
    {
      pages.Add(0, new List<string> { "Come here often?", "\t[1] - You know me(Log in)", "\t[2] - First time(Register)" });
      pages.Add(1, new List<string> { "You do seem familiar.  Mind giving me your name?", "\t[1] - Sure thing.", "\t[2] - Actually, nevermind." });
      pages.Add(2, new List<string> { "Lets get your name in the books.", "\t[1] - Sign me up!", "\t[2] - I changed my mind." });
    }

    //public List<string> GoToPage(int pageId)
    //{
    //  return pages[pageId];
    //}
  }
}
