using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreAppModelsLayer.EFModels;

namespace StoreAppModelsLayer.Interfaces
{
  public interface IManager<T> where T : class
  {
    private static T manager;
    private static T repository;

    public List<T> items { get; set; }

    public static T Instance;

    public void Add(T item);

    public T GetItem(string identifier);
  }
}

