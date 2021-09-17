using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreAppModelsLayer.EFModels;
using StoreAppModelsLayer.Interfaces;
using StoreAppModelsLayer;
using Microsoft.EntityFrameworkCore;

namespace StoreAppDBContextLayer
{
  public class InventoryRepository 
  {
    //Step 1 of DI - create private instance of dependency
    private readonly StoreApplicationDBContext _context;

    //Step 2 of DI - call for an instance from the DI system in constructor
    public InventoryRepository(StoreApplicationDBContext context)
    {
      _context = context;
    }

    public bool Delete()
    {
      throw new NotImplementedException();
    }

    

    public Task<bool> Insert(StoreInventory entry)
    {
      throw new NotImplementedException();
    }

    public async Task<List<StoreInventory>> Select()
    {
      return await _context.StoreInventories.FromSqlRaw<StoreInventory>("SELECT * FROM StoreInventory;").ToListAsync();
    }

    public void Update(List<StoreInventory> newList)
    {
      throw new NotImplementedException();
    }
  }
}
