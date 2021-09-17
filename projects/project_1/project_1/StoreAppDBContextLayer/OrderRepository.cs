using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreAppModelsLayer.EFModels;
using StoreAppModelsLayer.Interfaces;

namespace StoreAppDBContextLayer
{
  public class OrderRepository : IRepository<Order>
  {
    //Step 1 of DI - create private instance of dependency
    private readonly StoreApplicationDBContext _context;

    //Step 2 of DI - call for an instance from the DI system in constructor
    public OrderRepository(StoreApplicationDBContext context)
    {
      _context = context;
    }

    public bool Delete()
    {
      throw new NotImplementedException();
    }

    public async Task<bool> Insert(Order entry)
    {
      await _context.Database.ExecuteSqlRawAsync("INSERT INTO Orders(CustomerId, ProductId, StoreId, OrderDate, ProductQuantity, CompletionTime, totalAmount) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6});",
        entry.CustomerId, entry.ProductId, entry.StoreId, entry.OrderDate, entry.ProductQuantity, entry.CompletionTime, entry.TotalAmount);

      return true;
    }

    public async Task<List<Order>> Select()
    {
      return await _context.Orders.FromSqlRaw<Order>("SELECT * FROM Orders;").ToListAsync();
    }

    public void Update(List<Order> newList)
    {
      throw new NotImplementedException();
    }
  }
}
