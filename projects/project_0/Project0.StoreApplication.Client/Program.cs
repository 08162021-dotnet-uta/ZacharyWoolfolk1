using System;
using System.Collections.Generic;
using Project0.StoreApplication.Client.Singletons;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage;
using Serilog;

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

    /// <summary>
    /// Defines the Main Method
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
      Log.Logger = new LoggerConfiguration().WriteTo.File(_logFilePath).CreateLogger();

            //HelloSQL();
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

      var store = _storeSingleton.Stores[Capture<Store>(_storeSingleton.Stores)];
      Console.WriteLine("You have chosen to shop at {0}.", store.Name);
      store.StoreId = (byte)(_storeSingleton.Stores.IndexOf(store) + 1);

      var product = _productSingleton.Products[Capture<Product>(_productSingleton.Products)];
      Console.WriteLine("You are purchasing 1 {0} for ${1}.", product.Name, product.Price);

      var order = new Order();
      order.Customer = customer;
      order.Store = store;
      order.OrderDate = DateTime.Now;
      //order.Products.Add(product);
      _orderSingleton.Add(order);

      Console.WriteLine("Thank you for your purchase!");




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

        //private static void HelloSQL()
        //{
        //    var def = new DemoEF();

        //    foreach (var item in def.GetProducts())
        //    {
        //        Console.WriteLine(item);
        //    }

        //}
    }
}
