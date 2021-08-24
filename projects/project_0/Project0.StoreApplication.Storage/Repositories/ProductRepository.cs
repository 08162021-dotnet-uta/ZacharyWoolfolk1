using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;

namespace Project0.StoreApplication.Storage.Repositories
{
  public class ProductRepository
  {
    public List<Product> Products { get; set; }

    public ProductRepository()
    {
      var fileAdapter = new FileAdapter();

      // if (fileAdapter.ReadFromFile() == null)
      // {
      //   fileAdapter.WriteToFile(new List<Store>()
      //   {
      //     new BookStore(),
      //     new BookStore(),
      //     new BookStore()
      //   });
      // }

      Products = fileAdapter.ReadFromFile<List<Product>>(@"/home/zachary/revature/training_code/ZacharyWoolfolk1/data/Products.xml");
    }
  }
}