using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Storage.Repositories;
using Serilog;

namespace Project0.StoreApplication.Client
{
  class Program
  {
    private const string logFilePath = @"/home/training_code/ZacharyWoolfolk1/data/logs.txt";
    static void Main(string[] args)
    {
      Log.Logger = new LoggerConfiguration().WriteTo.File(logFilePath).CreateLogger();

      Run();
    }

    static void Run() 
    {
      Log.Information("Begin running application");
      
      Console.WriteLine("What you like to do?");

      PrintAllStoreLocations();
      Console.WriteLine("You have selected: " + SelectStore());
    }

    static void PrintAllStoreLocations()
    {
      Log.Information("method PrintAllStoreLocations()");

      var storeRepository = new StoreRepository();
      int i = 1;

      foreach (var store in storeRepository.Stores)
      {
        System.Console.WriteLine(i + " - " + store);
        i += 1;
      }
    }

    static Store SelectStore()
    {
      Log.Information("method SelectStore()");

      var stores = new StoreRepository().Stores;

      Console.WriteLine("Select a Store: ");

      return (stores[int.Parse(Console.ReadLine()) - 1]);
    }
  }
}
