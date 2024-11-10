using ApiPedidin.Models;
using ApiPedidin.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiPedidin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemRequestController : ControllerBase
    {
        private readonly IItemRequestRepository _itemRequestRepository;
        public ItemRequestController(IItemRequestRepository itemRequestRepository)
        {
            _itemRequestRepository = itemRequestRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemRequestModel>>> GetAllItemRequests()
        {
            List<ItemRequestModel> itemRequests = await _itemRequestRepository.GetAll();
            return Ok(itemRequests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemRequestModel>> GetItemRequestById(long id)
        {
            ItemRequestModel itemRequest = await _itemRequestRepository.GetById(id);
            return Ok(itemRequest);
        }

        [HttpGet("requests/{idRequest}")]
        public async Task<ActionResult<List<ItemRequestModel>>> GetItemRequestByIdRequest(long idRequest)
        {
            List<ItemRequestModel> itemRequest = await _itemRequestRepository.GetByIdRequest(idRequest);
            return Ok(itemRequest);
        }

        [HttpGet("products/{idProduct}")]
        public async Task<ActionResult<List<ItemRequestModel>>> GetItemRequestByIdProduct(long idProduct)
        {
            List<ItemRequestModel> itemRequest = await _itemRequestRepository.GetByIdProduct(idProduct);
            return Ok(itemRequest);
        }


        [HttpPost]
        public async Task<ActionResult<ItemRequestModel>> CreateItemRequest([FromBody] ItemRequestModel itemRequest)
        {
            ItemRequestModel newItemRequest = await _itemRequestRepository.Create(itemRequest);
            return Ok(newItemRequest);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ItemRequestModel>> UpdateItemRequest(long id, [FromBody] ItemRequestModel itemRequest)
        {
            itemRequest.Id = id;
            ItemRequestModel updatedItemRequest = await _itemRequestRepository.Update(itemRequest, id);
            return Ok(updatedItemRequest);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemRequest(long id)
        {
            bool deleted = await _itemRequestRepository.Delete(id);
            return Ok(deleted);
        }
    }
}