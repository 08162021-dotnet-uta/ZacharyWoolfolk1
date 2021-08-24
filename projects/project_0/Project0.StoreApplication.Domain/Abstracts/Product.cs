using System.Xml.Serialization;
using Project0.StoreApplication.Domain.Models.Products;

namespace Project0.StoreApplication.Domain.Abstracts
{
  [XmlInclude(typeof(Book))]
  [XmlInclude(typeof(Game))]
  public abstract class Product
  {
    public string Name { get; set; }
    public string Price { get; set; }

    public override string ToString()
    {
      return Name + " - $" + Price;
    }
  }
}