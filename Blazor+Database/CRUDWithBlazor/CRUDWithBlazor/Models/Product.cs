namespace CRUDWithBlazor.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty; // Or assign a default value

        public double Price { get; set; }

        public int Qty { get; set; }
    }
}
