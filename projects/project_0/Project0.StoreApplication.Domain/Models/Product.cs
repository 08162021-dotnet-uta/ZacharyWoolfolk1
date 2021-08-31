namespace Project0.StoreApplication.Domain.Models
{
  public class Product
  {
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public override string ToString()
    {
      return $"{Name} - Available for ${Price}";
    }
  }
}