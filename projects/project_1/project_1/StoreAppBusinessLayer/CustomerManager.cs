using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreAppDBContextLayer;
using StoreAppModelsLayer.EFModels;
using StoreAppModelsLayer.Interfaces;

namespace StoreAppBusinessLayer
{
  public class CustomerManager : ICustomerManager
  {
    private static CustomerManager MCustomer;
    private readonly IRepository<Customer> RCustomer;

    public CustomerManager(IRepository<Customer> cr)
    {
      RCustomer = cr;
    }

    public List<Customer> items { get; set; }

    public static CustomerManager Instance
    {
      get
      {
        if(MCustomer == null)
        {
          MCustomer = new CustomerManager();
        }
        return MCustomer;
      }
    }

    public CustomerManager()
    {
      //This line of code comes from StackOverflow user 'sayaladev'
      items = Task.Run(() => RCustomer.Select()).Result;
    }

    public async void Add(Customer customer)
    {
      await RCustomer.Insert(customer);
      items = await RCustomer.Select();
    }

    public Customer GetItem(string fname)
    {
      Customer customer = null;
      foreach(Customer c in items)
      {
        if(c.FirstName == fname)
        {
          customer = c;
        }
      }
      return customer;
    }

    public Customer LoginCustomer(Customer customer)
    {
      if (items.Contains(customer))
      {
        return customer;
      }
      else
      {
        return null;
      }
    }

    public Customer RegisterCustomer(Customer customer)
    {
      Add(customer);
      return customer;
    }
  }
}
