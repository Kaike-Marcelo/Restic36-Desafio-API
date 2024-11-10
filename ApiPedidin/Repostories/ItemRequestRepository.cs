using ApiPedidin.Data;
using ApiPedidin.Models;
using ApiPedidin.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiPedidin.Repositories
{
    public class ItemRequestRepository : IItemRequestRepository
    {

        private readonly PedidinDBContext _dbContext;

        public ItemRequestRepository(PedidinDBContext pedidinDBContext)
        {
            _dbContext = pedidinDBContext;
        }

        public async Task<List<ItemRequestModel>> GetAll()
        {
            return await _dbContext.Item_Request.ToListAsync();
        }

        public async Task<ItemRequestModel> GetById(long id)
        {
            var itemRequest = await _dbContext.Item_Request.FirstOrDefaultAsync(x => x.Id == id);
            if (itemRequest == null)
            {
                throw new Exception($"O item do pedido para o ID: {id} não foi encontrado no banco de dados!");
            }
            return itemRequest;
        }

        public async Task<List<ItemRequestModel>> GetByIdRequest(long id)
        {
            var itemRequests = await _dbContext.Item_Request
                                           .Where(x => x.requestId == id)
                                           .ToListAsync();

            if (itemRequests == null || !itemRequests.Any())
            {
                throw new Exception($"Nenhum item do pedido foi encontrado para o ID do cliente: {id}.");
            }

            return itemRequests;
        }

        public async Task<List<ItemRequestModel>> GetByIdProduct(long id)
        {
            var itemRequests = await _dbContext.Item_Request
                                           .Where(x => x.productId == id)
                                           .ToListAsync();

            if (itemRequests == null || !itemRequests.Any())
            {
                throw new Exception($"Nenhum item do pedido foi encontrado para o ID do cliente: {id}.");
            }

            return itemRequests;
        }


        public async Task<ItemRequestModel> Create(ItemRequestModel itemRequest)
        {
            await _dbContext.Item_Request.AddAsync(itemRequest);
            await _dbContext.SaveChangesAsync();

            return itemRequest;
        }

        public async Task<ItemRequestModel> Update(ItemRequestModel itemRequest, long id)
        {
            ItemRequestModel itemRequestById = await GetById(id);

            if (itemRequestById == null)
            {
                throw new Exception($"O item do pedido para o ID: {id} não foi encontrado no banco de dados!");
            }

            itemRequestById.quantityProducts = itemRequest.quantityProducts;

            _dbContext.Item_Request.Update(itemRequestById);
            await _dbContext.SaveChangesAsync();

            return itemRequestById;
        }

        public async Task<bool> Delete(long id)
        {
            ItemRequestModel itemRequestById = await GetById(id);

            if (itemRequestById == null)
            {
                throw new Exception($"O item do pedido para o ID: {id} não foi encontrado no banco de dados!");
            }

            _dbContext.Item_Request.Remove(itemRequestById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}