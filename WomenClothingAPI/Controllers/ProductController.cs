using Microsoft.AspNetCore.Mvc;
using WomenClothingAPI.Models;
using WomenClothingAPI.Services;

namespace WomenClothingAPI.Controllers
{
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)             
        {
            _productService = productService;
        }

        // Get all products
        [HttpGet("getAll")]
        public async Task<IActionResult> GetProducts(int page, int pageSize)
        {
            var products = await _productService.GetProductsAsync(page, pageSize);
            return Ok(products);
        }

        // Get a product by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // Add a new product
        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedProduct = await _productService.AddProductAsync(product);

            return CreatedAtAction(nameof(GetProduct), new { id = addedProduct.Id }, addedProduct);
        }

        // Update an existing product
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            if (id != updatedProduct.Id)
            {
                return BadRequest();
            }

            var result = await _productService.UpdateProductAsync(id, updatedProduct);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // Delete a product by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
