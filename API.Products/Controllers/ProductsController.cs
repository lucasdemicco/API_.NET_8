using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace API.Products.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("findAllProducts")]
        public IActionResult findAllProducts()
        {
            return Ok(_productService.findAll());
        }

        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct(ProductDto product)
        {
            try
            {
                 _productService.createProduct(product);
                return StatusCode(StatusCodes.Status201Created, "Produto criado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
