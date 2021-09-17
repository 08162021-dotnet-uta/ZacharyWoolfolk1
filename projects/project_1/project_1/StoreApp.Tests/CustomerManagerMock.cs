using StoreAppModelsLayer.EFModels;
using StoreAppModelsLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Tests
{
  class CustomerManagerMock : ICustomerManager
  {
    public List<Customer> items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void Add(Customer item)
    {
      throw new NotImplementedException();
    }

    public Customer GetItem(string identifier)
    {
      throw new NotImplementedException();
    }

    public Customer LoginCustomer(Customer customer)
    {
      throw new NotImplementedException();
    }

    public Customer RegisterCustomer(Customer customer)
    {
      throw new NotImplementedException();
    }
  }
}
