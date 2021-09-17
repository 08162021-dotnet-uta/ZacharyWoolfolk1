using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreAppModelsLayer.Interfaces;
using StoreAppModelsLayer.EFModels;

namespace StoreAppBusinessLayer
{
  class LocationManager : IManager<Location>
  {
    private static LocationManager MLocation;
    private readonly IRepository<Location> RLocation;

    public LocationManager(IRepository<Location> lr)
    {
      RLocation = lr;
      items = Task.Run(() => RLocation.Select()).Result;
    }

    public List<Location> items { get ; set ; }

    public static LocationManager Instance
    {
      get
      {
        if (MLocation == null)
        {
          MLocation = new LocationManager();
        }
        return MLocation;
      }
    }

    public LocationManager()
    {
      //This line of code comes from StackOverflow user 'sayaladev'
      items = Task.Run(() => RLocation.Select()).Result;
    }

    public async void Add(Location item)
    {
      await RLocation.Insert(item);
      items = await RLocation.Select();
    }

    public async Task<Location> GetElement(string identifier)
    {
      Location location = null;
      foreach (Location l in items)
      {
        if (l.Location1 == identifier)
        {
          location = l;
        }
      }
      return location;
    }
  }
}
