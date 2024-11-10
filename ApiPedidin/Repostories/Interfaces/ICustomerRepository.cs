using ApiPedidin.Models;

namespace ApiPedidin.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<CustomerModel>> GetAllCustomers();
        Task<CustomerModel> GetCustomerById(long id);
        Task<CustomerModel> AddCustomer(CustomerModel customer);
        Task<CustomerModel> UpdateCustomer(CustomerModel customer, long id);
        Task<bool> DeleteCustomer(long id);
    }
}