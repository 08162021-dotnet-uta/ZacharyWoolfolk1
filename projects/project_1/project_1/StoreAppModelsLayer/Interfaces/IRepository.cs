using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppModelsLayer.Interfaces
{
  /// <summary>
  /// 
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public interface IRepository<T> where T : class
  {
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    bool Delete();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<bool> Insert(T entry);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<List<T>> Select();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    void Update(List<T> newList);
  }
}