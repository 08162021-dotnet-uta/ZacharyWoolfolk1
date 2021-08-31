using Xunit;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;
using Project0.StoreApplication.Storage.Repositories;
using Project0.StoreApplication.Client.Singletons;
using System.Collections.Generic;

namespace Project0.StoreApplication.Testing
{
  public class OrderRepositoryTests
  {
    [Fact]
    public void Test_OrderCollection()
    {
      var sut = OrderSingleton.Instance;

      var actual = sut.Orders;

      Assert.NotNull(actual);
      Assert.NotEmpty(actual);
    }
  }
}