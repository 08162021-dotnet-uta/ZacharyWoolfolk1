using StoreAppModelsLayer.EFModels;
using StoreAppModelsLayer.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppDBContextLayer
{
  public class CustomerRepository : IRepository<Customer>
  {
    //Step 1 of DI - create private instance of dependency
    private readonly StoreApplicationDBContext _context;

    //Step 2 of DI - call for an instance from the DI system in constructor
    public CustomerRepository(StoreApplicationDBContext context)
    {
      _context = context;
    }

    public bool Delete()
    {
      throw new NotImplementedException();
    }

    public async Task<bool> Insert(Customer entry)
    {
      await _context.Database.ExecuteSqlRawAsync("INSERT INTO Customers(FirstName, LastName) VALUES ({0}, {1});", entry.FirstName, entry.LastName);

      return true;
    }

    public async Task<List<Customer>> Select()
    {
      return await _context.Customers.FromSqlRaw<Customer>("SELECT * FROM Customers;").ToListAsync();
    }

    public void Update(List<Customer> newList)
    {
      throw new NotImplementedException();
    }
  }
}
