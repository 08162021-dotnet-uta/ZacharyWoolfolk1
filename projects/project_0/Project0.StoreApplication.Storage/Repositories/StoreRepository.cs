using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models.Stores;
using Project0.StoreApplication.Storage.Adapters;

namespace Project0.StoreApplication.Storage.Repositories
{
  public class StoreRepository
  {
    private string _path = @"/home/zachary/revature/training_code/ZacharyWoolfolk1/data/Stores.xml";
    public List<Store> Stores { get; set; }

    public StoreRepository()
    {
      var fileAdapter = new FileAdapter();

      // if (fileAdapter.ReadFromFile<List<Store>>(_path) == null)
      // {
      //   fileAdapter.WriteToFile(_path, new List<Store>()
      //   {
      //     new BookStore("name", "location"),
      //     new GameStore("name", "location")
      //   });
      // }

      Stores = fileAdapter.ReadFromFile<List<Store>>(_path);
    }
  }
}