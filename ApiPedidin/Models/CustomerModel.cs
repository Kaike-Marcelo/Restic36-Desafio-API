namespace ApiPedidin.Models
{
    public class CustomerModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? ContactNumber { get; set; }
        public string? DateOfBirth { get; set; }
    }
}