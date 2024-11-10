using ApiPedidin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPedidin.Data.Map
{
    public class ItemRequestMap : IEntityTypeConfiguration<ItemRequestModel>
    {
        public void Configure(EntityTypeBuilder<ItemRequestModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.requestId).IsRequired();
            builder.Property(x => x.productId).IsRequired();
            builder.Property(x => x.quantityProducts).IsRequired();
        }
    }
}