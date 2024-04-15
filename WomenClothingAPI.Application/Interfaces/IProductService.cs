using WomenClothingAPI.Application.DTOs;
using WomenClothingAPI.Core.Common;
using WomenClothingAPI.Models;

namespace WomenClothingAPI.Services
{
    public interface IProductService
    {
        Task<BaseResponse<IEnumerable<ProductDto>>> GetProductsAsync(int page, int pageSize);
        Task<BaseResponse<ProductDto>> GetProductByIdAsync(int id);
        Task<BaseResponse<bool>> AddProductAsync(ProductDto product);
        Task<BaseResponse<bool>> UpdateProductAsync(int id, ProductDto updatedProduct);
        Task<BaseResponse<bool>> DeleteProductAsync(int id);
    }

}
