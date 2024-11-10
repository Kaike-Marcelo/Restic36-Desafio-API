using ApiPedidin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPedidin.Data.Map
{
    public class ProductMap : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Type).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Price).IsRequired().HasMaxLength(100);
        }
    }
}