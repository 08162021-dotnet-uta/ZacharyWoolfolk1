using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreAppModelsLayer.EFModels;

namespace StoreAppModelsLayer.Interfaces
{
  public interface IOrderManager : IManager<Order>
  {
    public Task<Order> PlaceOrder(Order order);
  }
}
