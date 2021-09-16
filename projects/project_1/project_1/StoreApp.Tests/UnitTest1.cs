using System;
using Xunit;
using System.Collections.Generic;
using StoreAppBusinessLayer;
using StoreAppModelsLayer.EFModels;
using Microsoft.EntityFrameworkCore;
using StoreAppDBContextLayer;

namespace StoreApp.Tests
{
  public class UnitTest1
  {
    //Create in-memory database for testing
    public DbContextOptions<StoreApplicationDBContext> options { get; set; } = new
      DbContextOptionsBuilder<StoreApplicationDBContext>()
      .UseInMemoryDatabase(databaseName: "TestDb")
      .Options;

    [Fact]
    public void CustomerListTest()
    {
      CustomerManager sut = new CustomerManager();

     // List<Customer> actual = sut.customers;

      //Assert.NotNull(actual);
      //Assert.NotEmpty(actual);
    }

    [Fact]
    public void Test1()
    {
      using(StoreApplicationDBContext _context = new StoreApplicationDBContext(options))
      {
        //Arrange - create foundation for test

        //ensure clean database for testing
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

        Customer c = new Customer();
        c.FirstName = "Ben";
        c.LastName = "Kenobi";
        _context.Customers.Add(c);

        //Act - act on foundation; input or use the Method Under Test (M.U.T.)

        //Assert

      }
    }
  }
}
