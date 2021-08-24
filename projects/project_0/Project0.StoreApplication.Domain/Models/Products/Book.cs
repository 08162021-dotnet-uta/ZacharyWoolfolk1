using Project0.StoreApplication.Domain.Abstracts;

namespace Project0.StoreApplication.Domain.Models.Products
{
  public class Book : Product
  {
    private Book(){}

    public Book(string name, string price)
    {
      Name = name;
      Price = price;
    }

  }
}