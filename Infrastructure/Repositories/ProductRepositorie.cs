using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ProductRepositorie : IProductRepositorie
    {
        private readonly StoreContext _storeContext;

        public ProductRepositorie(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<Product> GetProduct(int Id)
        {
            Product product = new Product();
            product = await _storeContext.Products.FirstOrDefaultAsync(p => p.Id == Id);
            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            List<Product> products = await _storeContext.Products.ToListAsync();
            return products;
        }

    }
}