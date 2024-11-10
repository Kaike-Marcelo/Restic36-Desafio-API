using ApiPedidin.Data.Map;
using ApiPedidin.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPedidin.Data
{
    public class PedidinDBContext : DbContext
    {
        public PedidinDBContext(DbContextOptions<PedidinDBContext> options) : base(options)
        {
        }

        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<RequestModel> Requests { get; set; }
        public DbSet<ItemRequestModel> Item_Request { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new RequestMap());
            modelBuilder.ApplyConfiguration(new ItemRequestMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}