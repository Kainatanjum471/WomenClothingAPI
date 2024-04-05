using WomenClothingAPI.Models;

namespace WomenClothingAPI.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync(int page, int pageSize);
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> AddProductAsync(Product product);
        Task<bool> UpdateProductAsync(int id, Product updatedProduct);
        Task<bool> DeleteProductAsync(int id);
    }

}
