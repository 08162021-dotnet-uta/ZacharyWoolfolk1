using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreAppModelsLayer.Interfaces;
using StoreAppModelsLayer.EFModels;

namespace StoreAppBusinessLayer
{
  class InventoryManager : IManager<StoreInventory>
  {
    public List<StoreInventory> items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void Add(StoreInventory item)
    {
      throw new NotImplementedException();
    }

    public Task<StoreInventory> GetElement(string identifier)
    {
      throw new NotImplementedException();
    }
  }
}
