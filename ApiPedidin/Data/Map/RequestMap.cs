using ApiPedidin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPedidin.Data.Map
{
    public class RequestMap : IEntityTypeConfiguration<RequestModel>
    {
        public void Configure(EntityTypeBuilder<RequestModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.customerId).IsRequired();
            builder.Property(x => x.dateOfRequest).IsRequired().HasMaxLength(11);
            builder.Property(x => x.status).IsRequired().HasMaxLength(11);
        }
    }
}