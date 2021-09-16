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
    Customer LoginCustomer(Customer customer);
    Customer RegisterCustomer(Customer customer);
  }
}
