using ApiPedidin.Data;
using ApiPedidin.Models;
using ApiPedidin.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiPedidin.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly PedidinDBContext _dbContext;

        public ProductRepository(PedidinDBContext pedidinDBContext)
        {
            _dbContext = pedidinDBContext;
        }

        public async Task<List<ProductModel>> GetAll()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<ProductModel> GetById(long id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                throw new Exception($"O produto para o ID: {id} não foi encontrado no banco de dados!");
            }
            return product;
        }

        public async Task<ProductModel> Create(ProductModel product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<ProductModel> Update(ProductModel product, long id)
        {
            ProductModel productById = await GetById(id);

            if (productById == null)
            {
                throw new Exception($"O produto para o ID: {id} não foi encontrado no banco de dados!");
            }

            productById.Name = product.Name;
            productById.Type = product.Type;
            productById.Price = product.Price;

            _dbContext.Products.Update(productById);
            await _dbContext.SaveChangesAsync();

            return productById;
        }

        public async Task<bool> Delete(long id)
        {
            ProductModel productById = await GetById(id);

            if (productById == null)
            {
                throw new Exception($"O produto para o ID: {id} não foi encontrado no banco de dados!");
            }

            _dbContext.Products.Remove(productById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}