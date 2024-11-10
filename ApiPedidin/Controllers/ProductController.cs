using ApiPedidin.Models;
using ApiPedidin.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiPedidin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductModel>>> GetAllProducts()
        {
            List<ProductModel> products = await _productRepository.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProductById(long id)
        {
            ProductModel product = await _productRepository.GetById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductModel>> CreateProduct([FromBody] ProductModel product)
        {
            ProductModel newProduct = await _productRepository.Create(product);
            return Ok(newProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductModel>> UpdateProduct(long id, [FromBody] ProductModel product)
        {
            product.Id = id;
            ProductModel updatedProduct = await _productRepository.Update(product, id);
            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(long id)
        {
            bool deleted = await _productRepository.Delete(id);
            return Ok(deleted);
        }
    }
}