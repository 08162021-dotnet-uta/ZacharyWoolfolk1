using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;

namespace Project0.StoreApplication.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
  public class Order
  {
    public Int16 OrderId { get; set; }
    public Customer Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public Store Store { get; set; }
    public List<Product> Products { get; set; }

    public Order()
    {
      Products = new List<Product>();
    }
  }
}