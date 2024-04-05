using Microsoft.EntityFrameworkCore;
using WomenClothingAPI.Data;
using WomenClothingAPI.Models;

namespace WomenClothingAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(int page, int pageSize)
        {
            return await _context.Products.Skip((page - 1) * pageSize)
            .Take(pageSize).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> UpdateProductAsync(int id, Product updatedProduct)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
                return false;

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.ImageUrl = updatedProduct.ImageUrl;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
