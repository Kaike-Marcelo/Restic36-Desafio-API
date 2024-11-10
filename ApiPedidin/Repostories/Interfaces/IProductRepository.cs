using ApiPedidin.Models;

namespace ApiPedidin.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAll();
        Task<ProductModel> GetById(long id);
        Task<ProductModel> Create(ProductModel product);
        Task<ProductModel> Update(ProductModel product, long id);
        Task<bool> Delete(long id);
    }
}