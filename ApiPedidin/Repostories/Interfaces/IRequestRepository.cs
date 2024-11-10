using ApiPedidin.Models;

namespace ApiPedidin.Repositories.Interfaces
{
    public interface IRequestRepository
    {
        Task<List<RequestModel>> GetAll();
        Task<RequestModel> GetById(long id);
        Task<List<RequestModel>> GetByIdCustomer(long id);
        Task<RequestModel> Create(RequestModel request);
        Task<RequestModel> Update(RequestModel request, long id);
        Task<bool> Delete(long id);
    }
}