using Project0.StoreApplication.Domain.Abstracts;

namespace Project0.StoreApplication.Domain.Models.Stores
{
  public class GameStore : Store
  {
    private GameStore() {}

    public GameStore(string name, string location)
    {
      Name = name;
      Location = location;
    }

  }
}