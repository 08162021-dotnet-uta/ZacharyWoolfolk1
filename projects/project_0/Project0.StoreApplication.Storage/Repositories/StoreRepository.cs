using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Storage.Adapters;

namespace Project0.StoreApplication.Storage.Repositories
{
  /// <summary>
  /// 
  /// </summary>
  public class StoreRepository : IRepository<Store>
  {
    private const string _path = @"C:\Users\Zachary\Source\Repos\08162021-dotnet-uta\ZacharyWoolfolk1\data\stores.xml";
    private static readonly FileAdapter _fileAdapter = new FileAdapter();

    public StoreRepository()
    {
      if (_fileAdapter.ReadFromFile<Store>(_path) == null)
      {
        _fileAdapter.WriteToFile<Store>(_path, new List<Store>());
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool Insert(Store entry)
    {
      _fileAdapter.WriteToFile<Store>(_path, new List<Store> { entry });

      return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<Store> Select()
    {
      return _fileAdapter.ReadFromFile<Store>(_path);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public void Update(List<Store> newList)
    {
      throw new System.NotImplementedException();
    }
  }
}