using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;

namespace Project0.StoreApplication.Storage.Repositories
{
  /// <summary>
  /// 
  /// </summary>
  public class OrderRepository : IRepository<Order>
  {
    private static readonly DataAdapter _dataAdapter = new DataAdapter();

    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(Order entry)
    {
      _dataAdapter.Database.ExecuteSqlRaw("INSERT INTO Store.[Order](CustomerId, StoreId, OrderDate) VALUES ({0},{1},{2});", entry.Customer.CustomerId, entry.Store.StoreId, entry.OrderDate);

      return true;
    }

    public List<Order> Select()
    {
      return _dataAdapter.Orders.FromSqlRaw("SELECT * FROM Store.[Order];").ToList();
    }

    public Order Update()
    {
      throw new System.NotImplementedException();
    }
  }
}