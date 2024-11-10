namespace ApiPedidin.Models
{
    public class ItemRequestModel
    {
        public long Id { get; set; }
        public long requestId { get; set; }
        public long productId { get; set; }
        public int quantityProducts { get; set; }
    }
}