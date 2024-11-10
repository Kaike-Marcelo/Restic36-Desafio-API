using ApiPedidin.Models;

namespace ApiPedidin.Repositories.Interfaces
{
    public interface IItemRequestRepository
    {
        Task<List<ItemRequestModel>> GetAll();
        Task<ItemRequestModel> GetById(long id);
        Task<List<ItemRequestModel>> GetByIdRequest(long id);
        Task<List<ItemRequestModel>> GetByIdProduct(long id);
        Task<ItemRequestModel> Create(ItemRequestModel itemRequest);
        Task<ItemRequestModel> Update(ItemRequestModel itemRequest, long id);
        Task<bool> Delete(long id);
    }
}