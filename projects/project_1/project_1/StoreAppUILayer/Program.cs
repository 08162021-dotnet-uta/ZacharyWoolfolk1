using System;
using System.Collections.Generic;
using StoreAppModelsLayer.EFModels;
using StoreAppBusinessLayer;

namespace StoreAppUILayer
{
  class Program
  {
    private static readonly CustomerManager customerManager = new CustomerManager();

    static void Main(string[] args)
    {
      Run();

    }

    public static void Run()
    {
      Customer currentCustomer;

      PageMarker pageMarker = new PageMarker();
      Console.WriteLine("Welcome to the Chronicle Shop, reader.");
      //Console.WriteLine("Come here often?\n\t[1] - You know me (Log in)\n\t[2] - First time (Register)");
      if (Capture<string>(pageMarker.pages[0]) == 1)
      {
        if (Capture<string>(pageMarker.pages[1]) == 1)
        {
          Console.WriteLine("First name: ");
          string fname = Console.ReadLine();
          Console.WriteLine("Last name: ");
          string lname = Console.ReadLine();
          currentCustomer = customerManager.GetCustomer(fname, lname);
          Console.WriteLine("Ah, {0} {1}.  I thought I'd heard that name before.  Welcome back.", currentCustomer.FirstName, currentCustomer.LastName);
        }
      }
      else
      {
        if (Capture<string>(pageMarker.pages[2]) == 1)
        {
          Customer customer = new Customer();
          Console.WriteLine("If you would kindly relinquish your name to us...");
          Console.WriteLine("First name: ");
          string fname = Console.ReadLine();
          Console.WriteLine("Last name: ");
          string lname = Console.ReadLine();
          customer.FirstName = fname;
          customer.LastName = lname;
          customerManager.Add(customer);
          currentCustomer = customer;
          Console.WriteLine("Welcome to the fold, {0} {1}", fname, lname);
        }
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private static void Output<T>(List<T> data) where T : class
    {
      var index = 0;

      foreach (var item in data)
      {
        Console.WriteLine(item);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static int Capture<T>(List<T> data) where T : class
    {
      Output<T>(data);
      int selected = int.Parse(Console.ReadLine());
      while((selected < 1) || (selected > (data.Count - 1)))
      {
        Console.WriteLine("Sorry, that wasn't one of the choices.");
        Output<T>(data);
        selected = int.Parse(Console.ReadLine());
      }

      return selected;
    }
  }
}
