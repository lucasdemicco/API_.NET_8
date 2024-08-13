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

        [HttpPost("[action]")]
        public async Task<IActionResult> SendMessageAsync()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("findAllProducts")]
        public IActionResult FindAllProducts()
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
