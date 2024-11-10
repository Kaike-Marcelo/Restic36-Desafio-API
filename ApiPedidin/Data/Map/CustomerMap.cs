using ApiPedidin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPedidin.Data.Map
{
    public class CustomerMap : IEntityTypeConfiguration<CustomerModel>
    {
        public void Configure(EntityTypeBuilder<CustomerModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.ContactNumber).IsRequired().HasMaxLength(11);
            builder.Property(x => x.DateOfBirth).IsRequired().HasMaxLength(13);
        }
    }
}