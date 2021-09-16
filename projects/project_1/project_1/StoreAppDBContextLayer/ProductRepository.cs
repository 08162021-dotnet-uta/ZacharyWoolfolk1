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
  public class ProductRepository : IRepository<Product>
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

    public bool Insert(Product entry)
    {
      throw new NotImplementedException();
    }

    public List<Product> Select()
    {
      return _context.Products.FromSqlRaw<Product>("SELECT * FROM Products;").ToList();
    }

    public void Update(List<Product> newList)
    {
      throw new NotImplementedException();
    }

    Task<bool> IRepository<Product>.Insert(Product entry)
    {
      throw new NotImplementedException();
    }

    Task<List<Product>> IRepository<Product>.Select()
    {
      throw new NotImplementedException();
    }
  }
}
