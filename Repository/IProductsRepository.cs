using System.Collections.Generic;
using System.Threading.Tasks;
using RestChallenge.Dtos;
using RestChallenge.Models;

namespace RestChallenge.Repository
{
    public interface IProductRepository
    {
        public Task<IEnumerable<ProductModel>> GetProductsAsync();
        public Task<ProductModel> GetProductByIdAsync(int Id);
        public Task CreateProductAsync(ProductModel product);
        public Task UpdateProductAsync(ProductModel product);
    }    
}