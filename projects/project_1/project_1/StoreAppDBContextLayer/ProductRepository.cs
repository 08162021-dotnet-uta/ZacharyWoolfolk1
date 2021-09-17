using Microsoft.EntityFrameworkCore;
using StoreAppModelsLayer.EFModels;
using StoreAppModelsLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppDBContextLayer
{
  public class ProductRepository : IProductRepository
  {
    //Step 1 of DI - create private instance of dependency
    private readonly StoreApplicationDBContext _context;

    //Step 2 of DI - call for an instance from the DI system in constructor
    public ProductRepository(StoreApplicationDBContext context)
    {
      _context = context;
    }

    public bool Delete()
    {
      throw new NotImplementedException();
    }

    public async Task<List<StoreInventory>> GetStoreInventory(int storeId)
    {
      List<StoreInventory> stock = await _context.StoreInventories.FromSqlRaw<StoreInventory>("SELECT StoreInventory.* FROM Products INNER JOIN StoreInventory ON Products.ProductId = StoreInventory.ProductId INNER JOIN Locations ON StoreInventory.StoreId = Locations.StoreId WHERE Locations.StoreId = {0};", storeId).ToListAsync(); ;
      return stock;
    }

    public async Task<List<Product>> GetStoreProducts(int storeId)
    {
      List<Product> listing = await _context.Products.FromSqlRaw<Product>("SELECT Products.* FROM Products INNER JOIN StoreInventory ON Products.ProductId = StoreInventory.ProductId INNER JOIN Locations ON StoreInventory.StoreId = Locations.StoreId WHERE Locations.StoreId = {0};", storeId).ToListAsync(); ;
      return listing;
    }

    public Task<bool> Insert(Product entry)
    {
      throw new NotImplementedException();
    }

    public async Task<List<Product>> Select()
    {
      return await _context.Products.FromSqlRaw<Product>("SELECT * FROM Products;").ToListAsync();
    }

    public void Update(List<Product> newList)
    {
      throw new NotImplementedException();
    }
  }
}
