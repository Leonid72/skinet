using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Repositories
{
    public interface IProductRepositorie
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(int Id);
    }
}