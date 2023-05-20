using Microsoft.AspNetCore.Mvc;
using Infrastructure.Repositories;
using Core.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepositorie _productRepository;

        public ProductsController(IProductRepositorie productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            List<Product> products = await _productRepository.GetProducts();
            //return Ok(products);
            return products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            Product product = await _productRepository.GetProduct(id);
            //return Ok(product);
            return product;
        }
    }
}