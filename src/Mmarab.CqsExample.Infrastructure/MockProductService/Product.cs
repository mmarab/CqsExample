namespace Mmarab.CqsExample.Infrastructure.MockProductService
{
    public class Product
    {
        public Product(string getDescription, decimal price, int id)
        {
            GetDescription = getDescription;
            Price = price;
            Id = id;
        }

        public int Id { get; }
        public decimal Price { get; }
        public string GetDescription { get; }
    }
}