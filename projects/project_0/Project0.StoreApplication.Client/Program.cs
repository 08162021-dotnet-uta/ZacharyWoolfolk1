using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project0.StoreApplication.Client.Singletons;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage;
using Project0.StoreApplication.Storage.Adapters;
using Serilog;

//Much of the code in this project is based on what was shown in lectures by Fred Belotte

namespace Project0.StoreApplication.Client
{
  /// <summary>
  /// 
  /// </summary>
  internal class Program
  {
    private static readonly ProductSingleton _productSingleton = ProductSingleton.Instance;
    private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance;
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    private static readonly OrderSingleton _orderSingleton = OrderSingleton.Instance;
    private const string _logFilePath = @"C:\Users\Zachary\Source\Repos\08162021-dotnet-uta\ZacharyWoolfolk1\data\logs.txt";
    private static readonly DataAdapter _dataAdapter = new DataAdapter();

    /// <summary>
    /// Defines the Main Method
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
      Log.Logger = new LoggerConfiguration().WriteTo.File(_logFilePath).CreateLogger();


            Run();
    }

    /// <summary>
    /// 
    /// </summary>
    private static void Run()
    {
      Log.Information("method: Run()");

      if (_customerSingleton.Customers.Count == 0)
      {
        _customerSingleton.Add(new Customer());
      }

      var customer = _customerSingleton.Customers[Capture<Customer>(_customerSingleton.Customers)];
      Console.WriteLine("Welcome, {0}!", customer.Name);
      customer.CustomerId = (byte)(_customerSingleton.Customers.IndexOf(customer) + 1);

      Console.WriteLine("What would you like to do?");
      List<string> actions = new List<string> { "View stores and make a purchase", "View past purchases" };
      int choice = Capture<string>(actions);

      if(choice == 0)
      {
        var store = _storeSingleton.Stores[Capture<Store>(_storeSingleton.Stores)];
        Console.WriteLine("You have chosen to shop at {0}.", store.Name);
        store.StoreId = (byte)(_storeSingleton.Stores.IndexOf(store) + 1);

        var product = _productSingleton.Products[Capture<Product>(_productSingleton.Products)];
        Console.WriteLine("You are purchasing 1 {0} for ${1}.", product.Name, product.Price);

        var order = new Order();
        order.Customer = customer;
        order.Store = store;
        order.OrderDate = DateTime.Now;
        order.Products.Add(product);
        _orderSingleton.Add(order);
        customer.Orders.Add(order);

        Console.WriteLine("Thank you for your purchase!");
      }
      else if(choice == 1)
      {
        List<Order> customerOrders = (_dataAdapter.Orders.FromSqlRaw("SELECT * FROM Store.[Order] WHERE CustomerId = {0};", customer.CustomerId).ToList());

        foreach(var o in customerOrders)
        {
          Console.WriteLine("Order {0} on {1}", o.OrderId, o.OrderDate);
        }
        
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private static void Output<T>(List<T> data) where T : class
    {
      Log.Information($"method: Output<{typeof(T)}>()");

      var index = 0;

      foreach (var item in data)
      {
        Console.WriteLine($"[{++index}] - {item}");
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static int Capture<T>(List<T> data) where T : class
    {
      Log.Information("method: Capture()");

      Output<T>(data);
      Console.Write("make selection: ");

      int selected = int.Parse(Console.ReadLine());

      return selected - 1;
    }

    }
}
