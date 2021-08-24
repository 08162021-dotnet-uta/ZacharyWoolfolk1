using Project0.StoreApplication.Domain.Abstracts;

namespace Project0.StoreApplication.Domain.Models.Products
{
  public class Game : Product
  {
    private Game(){}

    public Game(string name, string price)
    {
      Name = name;
      Price = price;
    }

  }
}