
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Interfaces;
using WebApplication1.Models.Models;


namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpPost("api/products/create")]
        public IActionResult CreateProduct([FromBody] ProductModel product)
        {
            _productManager.CreateProduct(product);
            return Ok("Product created");
        }

        [HttpGet("api/products/")]
        public IActionResult GetAllProducts()
        {
            return Ok(_productManager.GetAllProducts());
        }

        [HttpPost("api/products/update/{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductModel product)
        {
            string result = _productManager.UpdateProduct(id, product);
            if (result == "Product not found")
            {
                return NotFound("Product not found");
            }
            
            return Ok("Product updated");
        }
    }
}