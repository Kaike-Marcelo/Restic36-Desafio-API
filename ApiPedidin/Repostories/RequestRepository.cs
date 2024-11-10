using ApiPedidin.Data;
using ApiPedidin.Models;
using ApiPedidin.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiPedidin.Repositories
{
    public class RequestRepository : IRequestRepository
    {

        private readonly PedidinDBContext _dbContext;

        public RequestRepository(PedidinDBContext pedidinDBContext)
        {
            _dbContext = pedidinDBContext;
        }

        public async Task<List<RequestModel>> GetAll()
        {
            return await _dbContext.Requests.ToListAsync();
        }

        public async Task<RequestModel> GetById(long id)
        {
            var request = await _dbContext.Requests.FirstOrDefaultAsync(x => x.Id == id);
            if (request == null)
            {
                throw new Exception($"O pedido para o ID: {id} não foi encontrado no banco de dados!");
            }
            return request;
        }

        public async Task<List<RequestModel>> GetByIdCustomer(long id)
        {
            var requests = await _dbContext.Requests
                                           .Where(x => x.customerId == id)
                                           .ToListAsync();

            if (requests == null || !requests.Any())
            {
                throw new Exception($"Nenhum pedido foi encontrado para o ID do cliente: {id}.");
            }

            return requests;
        }


        public async Task<RequestModel> Create(RequestModel request)
        {
            await _dbContext.Requests.AddAsync(request);
            await _dbContext.SaveChangesAsync();

            return request;
        }

        public async Task<RequestModel> Update(RequestModel request, long id)
        {
            RequestModel requestById = await GetById(id);

            if (requestById == null)
            {
                throw new Exception($"O produto para o ID: {id} não foi encontrado no banco de dados!");
            }

            requestById.status = request.status;
            requestById.dateOfRequest = request.dateOfRequest;

            _dbContext.Requests.Update(requestById);
            await _dbContext.SaveChangesAsync();

            return requestById;
        }

        public async Task<bool> Delete(long id)
        {
            RequestModel requestById = await GetById(id);

            if (requestById == null)
            {
                throw new Exception($"O pedido para o ID: {id} não foi encontrado no banco de dados!");
            }

            _dbContext.Requests.Remove(requestById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}