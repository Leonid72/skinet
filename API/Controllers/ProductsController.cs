using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using Core.Entities;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productRepository.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            Product product = await _productRepository.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpGet]
        [Route("brands")]
        public async Task<ActionResult<List<Product>>> GetProductBrands()
        {
            var brands = await _productRepository.GetProductBrandsAsync();
            return Ok(brands);
        }
        
        [HttpGet]
        [Route("types")]
        public async Task<ActionResult<List<Product>>> GetProductTypes()
        {
            return Ok(await _productRepository.GetProductTypesAsync());
        }
    }
}