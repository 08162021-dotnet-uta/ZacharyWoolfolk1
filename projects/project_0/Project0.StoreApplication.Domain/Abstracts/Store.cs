using System.Xml.Serialization;
using Project0.StoreApplication.Domain.Models.Stores;

namespace Project0.StoreApplication.Domain.Abstracts
{
  [XmlInclude(typeof(BookStore))]
  [XmlInclude(typeof(GameStore))]
  public abstract class Store
  {
    public string Name { get; set; }
    public string Location { get; set; }

    public override string ToString()
    {
      return Name + ", " + Location;
    }
  }
}