using ApiPedidin.Data;
using ApiPedidin.Models;
using ApiPedidin.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiPedidin.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly PedidinDBContext _dbContext;

        public CustomerRepository(PedidinDBContext pedidinDBContext)
        {
            _dbContext = pedidinDBContext;
        }

        public async Task<List<CustomerModel>> GetAllCustomers()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<CustomerModel> GetCustomerById(long id)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
            {
                throw new Exception($"O cliente para o ID: {id} não foi encontrado no banco de dados!");
            }
            return customer;
        }

        public async Task<CustomerModel> AddCustomer(CustomerModel customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();

            return customer;
        }

        public async Task<CustomerModel> UpdateCustomer(CustomerModel customer, long id)
        {
            CustomerModel customerById = await GetCustomerById(id);

            if (customerById == null)
            {
                throw new Exception($"O cliente para o ID: {id} não foi encontrado no banco de dados!");
            }

            customerById.Name = customer.Name;
            customerById.Email = customer.Email;
            customerById.ContactNumber = customer.ContactNumber;
            customerById.DateOfBirth = customer.DateOfBirth;

            _dbContext.Customers.Update(customerById);
            await _dbContext.SaveChangesAsync();

            return customerById;
        }

        public async Task<bool> DeleteCustomer(long id)
        {
            CustomerModel customerById = await GetCustomerById(id);

            if (customerById == null)
            {
                throw new Exception($"O cliente para o ID: {id} não foi encontrado no banco de dados!");
            }

            _dbContext.Customers.Remove(customerById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}