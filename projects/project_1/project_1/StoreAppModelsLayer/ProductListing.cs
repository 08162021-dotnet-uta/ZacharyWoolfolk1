using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreAppModelsLayer.EFModels;

namespace StoreAppModelsLayer
{
  public class ProductListing : Product
  {
    public int inventory { get; set; }
  }
}
