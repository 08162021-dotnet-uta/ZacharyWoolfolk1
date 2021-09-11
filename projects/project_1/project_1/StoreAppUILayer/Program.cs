using System;
using System.Collections.Generic;

namespace StoreAppUILayer
{
  class Program
  {
    static void Main(string[] args)
    {
      PageMarker pageMarker = new PageMarker();
      Console.WriteLine("Welcome to the Chronicle Shop, reader.");
      //Console.WriteLine("Come here often?\n\t[1] - You know me (Log in)\n\t[2] - First time (Register)");
      if (Capture<string>(pageMarker.pages[0]) == 1)
      {
        Capture<string>(pageMarker.pages[1]);
      }
      else
      {
        if(Capture<string>(pageMarker.pages[2]) == 1)
        {
          Console.WriteLine("If you would kindly relinquish your name to us...");
          Console.WriteLine("First name: ");
          string fname = Console.ReadLine();
          Console.WriteLine("Last name: ");
          string lname = Console.ReadLine();
          Console.WriteLine("Welcome to the fold, {0} {1}", fname, lname);
          //Add(fname, lname) to customer database
        }
      }

      //GetInput();
      //Go to business layer -> 
      //    Choice 1: Next page
      //    Choice 2: Go to context layer ->
      //        Add customer to database, go back to choice 1

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
