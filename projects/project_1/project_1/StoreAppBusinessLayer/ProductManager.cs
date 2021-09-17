using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreAppModelsLayer.EFModels;
using StoreAppModelsLayer.Interfaces;

namespace StoreAppBusinessLayer
{
  public class ProductManager : IManager<Product>
  {
    private static ProductManager MProduct;
    private readonly IRepository<Product> RProduct;

    public ProductManager(IRepository<Product> pr)
    {
      RProduct = pr;
      items = Task.Run(() => RProduct.Select()).Result;
    }

    public List<Product> items { get; set; }

    public static ProductManager Instance
    {
      get
      {
        if (MProduct == null)
        {
          MProduct = new ProductManager();
        }
        return MProduct;
      }
    }

    public ProductManager()
    {
      //This line of code comes from StackOverflow user 'sayaladev'
      items = Task.Run(() => RProduct.Select()).Result;
    }

    public async void Add(Product item)
    {
      await RProduct.Insert(item);
      items = await RProduct.Select();
    }

    public async Task<Product> GetElement(string identifier)
    {
      Product product = null;
      foreach (Product p in items)
      {
        if (p.ProductName == identifier)
        {
          product = p;
        }
      }
      return product;
    }
  }
}
