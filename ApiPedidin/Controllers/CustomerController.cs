using ApiPedidin.Models;
using ApiPedidin.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiPedidin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerModel>>> GetAllCustomers()
        {
            List<CustomerModel> customers = await _customerRepository.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerModel>> GetCustomerById(long id)
        {
            CustomerModel customer = await _customerRepository.GetCustomerById(id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerModel>> CreateCustomer([FromBody] CustomerModel customer)
        {
            CustomerModel newCustomer = await _customerRepository.AddCustomer(customer);
            return Ok(newCustomer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerModel>> UpdateCustomer(long id, [FromBody] CustomerModel customer)
        {
            customer.Id = id;
            CustomerModel updatedCustomer = await _customerRepository.UpdateCustomer(customer, id);
            return Ok(updatedCustomer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(long id)
        {
            bool deleted = await _customerRepository.DeleteCustomer(id);
            return Ok(deleted);
        }
    }
}