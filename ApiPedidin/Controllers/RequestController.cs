using ApiPedidin.Models;
using ApiPedidin.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiPedidin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestRepository _requestRepository;
        public RequestController(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<RequestModel>>> GetAllRequests()
        {
            List<RequestModel> requests = await _requestRepository.GetAll();
            return Ok(requests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RequestModel>> GetRequestById(long id)
        {
            RequestModel request = await _requestRepository.GetById(id);
            return Ok(request);
        }

        [HttpGet("customers/{idCustomers}")]
        public async Task<ActionResult<List<RequestModel>>> GetRequestByIdCustomer(long idCustomers)
        {
            List<RequestModel> requests = await _requestRepository.GetByIdCustomer(idCustomers);
            return Ok(requests);
        }

        [HttpPost]
        public async Task<ActionResult<RequestModel>> CreateRequest([FromBody] RequestModel request)
        {
            RequestModel newRequest = await _requestRepository.Create(request);
            return Ok(newRequest);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RequestModel>> UpdateRequest(long id, [FromBody] RequestModel request)
        {
            request.Id = id;
            RequestModel updatedRequest = await _requestRepository.Update(request, id);
            return Ok(updatedRequest);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRequest(long id)
        {
            bool deleted = await _requestRepository.Delete(id);
            return Ok(deleted);
        }
    }
}