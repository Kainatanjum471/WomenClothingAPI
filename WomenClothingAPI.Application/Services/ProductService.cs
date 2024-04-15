using AutoMapper;
using Microsoft.Extensions.Logging;
using WomenClothingAPI.Application.DTOs;
using WomenClothingAPI.Core.Common;
using WomenClothingAPI.Models;

namespace WomenClothingAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, ILogger<ProductService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<ProductDto>>> GetProductsAsync(int page, int pageSize)
        {
            try
            {
                var products = await _unitOfWork.Products.GetAllPaginated(page, pageSize);
                var mappedProducts = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
                return new BaseResponse<IEnumerable<ProductDto>>(mappedProducts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new BaseResponse<IEnumerable<ProductDto>>(message: "Failed to retrieve products: " + ex.Message, success: false);
            }
        }

        public async Task<BaseResponse<ProductDto>> GetProductByIdAsync(int id)
        {
            try
            {
                var product = await _unitOfWork.Products.GetById(id);
               var mappedProduct= _mapper.Map<ProductDto>(product);
                return new BaseResponse<ProductDto>(mappedProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new BaseResponse<ProductDto>(message: "Failed to retrieve product: " + ex.Message, success: false);
            }
        }

        public async Task<BaseResponse<bool>> AddProductAsync(ProductDto product)
        {
            try
            {
                _unitOfWork.Products.Add(_mapper.Map<Product>(product));
                _unitOfWork.Complete();
                return new BaseResponse<bool>(message: "product added successfuly", success: true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new BaseResponse<bool>(message: "Failed to add product: " + ex.Message, success: false);
            }
        }

        public async Task<BaseResponse<bool>> UpdateProductAsync(int id, ProductDto updatedProduct)
        {
            try
            {
                var existingProduct = await _unitOfWork.Products.GetById(id);
                if (existingProduct == null)
                    return new BaseResponse<bool>(message: "product not found", success: false);

                existingProduct.Name = updatedProduct.Name;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.ImageUrl = updatedProduct.ImageUrl;
                _unitOfWork.Complete();
                return new BaseResponse<bool>(message: "product updated successfuly", success: true);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new BaseResponse<bool>(message: "Failed to update product: " + ex.Message, success: false);
            }
        }

        public async Task<BaseResponse<bool>> DeleteProductAsync(int id)
        {
            try
            {
                var product = await _unitOfWork.Products.GetById(id);
                if (product == null)
                    return new BaseResponse<bool>(message: "product not found", success: false);

                _unitOfWork.Products.Remove(product);
                _unitOfWork.Complete();
                return new BaseResponse<bool>(message: "product deleted successfuly", success: true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new BaseResponse<bool>(message: "Failed to delete product: " + ex.Message, success: false);
            }
        }
    }

}
