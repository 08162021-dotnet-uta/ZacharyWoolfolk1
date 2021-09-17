using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreAppModelsLayer.EFModels;
using StoreAppModelsLayer.Interfaces;

namespace StoreAppBusinessLayer
{
  public class OrderManager : IOrderManager
  {
    private static OrderManager MOrder;
    private readonly IRepository<Order> ROrder;

    public OrderManager(IRepository<Order> or)
    {
      ROrder = or;
      items = Task.Run(() => ROrder.Select()).Result;
    }

    public List<Order> items { get; set; }

    public static OrderManager Instance
    {
      get
      {
        if (MOrder == null)
        {
          MOrder = new OrderManager();
        }
        return MOrder;
      }
    }

    public OrderManager()
    {
      //This line of code comes from StackOverflow user 'sayaladev'
      items = Task.Run(() => ROrder.Select()).Result;
    }

    public async void Add(Order item)
    {
      await ROrder.Insert(item);
      items = await ROrder.Select();
    }

    public async Task<Order> GetElement(string identifier)
    {
      Order order = null;
      foreach (Order o in items)
      {
        if (o.Product.ProductName == identifier)
        {
          order = o;
          break;
        }
      }
      return order;
    }

    public async Task<Order> PlaceOrder(Order order)
    {
      await Task.Run(() => Add(order));
      return order;
    }
  }
}
