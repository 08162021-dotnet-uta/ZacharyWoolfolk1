using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreAppModelsLayer.EFModels;

namespace StoreAppModelsLayer.Interfaces
{
  public interface IProductRepository : IRepository<Product>
  {
    Task<List<Product>> GetStoreProducts(int storeId);
    Task<List<StoreInventory>> GetStoreInventory(int storeId);
  }
}
