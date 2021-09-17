using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreAppModelsLayer.EFModels;

namespace StoreAppModelsLayer.Interfaces
{
  public interface ICustomerManager : IManager<Customer>
  {
    Task<Customer> GetCustomer(string fname, string lname);
    Task<Customer> LoginCustomer(Customer customer);
    Task<Customer> RegisterCustomer(Customer customer);
  }
}
