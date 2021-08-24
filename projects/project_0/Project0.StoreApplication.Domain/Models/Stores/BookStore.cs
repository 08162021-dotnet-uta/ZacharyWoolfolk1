using Project0.StoreApplication.Domain.Abstracts;

namespace Project0.StoreApplication.Domain.Models.Stores
{
  public class BookStore : Store
  {
    private BookStore(){}

    public BookStore(string name, string location)
    {
      Name = name;
      Location = location;
    }

  }
}