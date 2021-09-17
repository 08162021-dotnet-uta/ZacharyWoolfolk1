using StoreAppModelsLayer.Interfaces;
using StoreAppModelsLayer.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StoreAppDBContextLayer
{
  public class LocationRepository : IRepository<Location>
  {
    //Step 1 of DI - create private instance of dependency
    private readonly StoreApplicationDBContext _context;

    //Step 2 of DI - call for an instance from the DI system in constructor
    public LocationRepository(StoreApplicationDBContext context)
    {
      _context = context;
    }

    public bool Delete()
    {
      throw new NotImplementedException();
    }

    public Task<bool> Insert(Location entry)
    {
      throw new NotImplementedException();
    }

    public async Task<List<Location>> Select()
    {
      return await _context.Locations.FromSqlRaw<Location>("SELECT * FROM Locations;").ToListAsync();
    }

    public void Update(List<Location> newList)
    {
      throw new NotImplementedException();
    }
  }
}
