using ApiPedidin.Models.Enums;

namespace ApiPedidin.Models
{
    public class RequestModel
    {
        public long Id { get; set; }
        public long customerId { get; set; }
        public string? dateOfRequest { get; set; }
        public StatusRequest status { get; set; }
    }
}