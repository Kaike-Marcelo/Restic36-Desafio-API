namespace ApiPedidin.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public decimal Price { get; set; }
    }
}