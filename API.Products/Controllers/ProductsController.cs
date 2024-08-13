using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Interface.External.Interface;

namespace API.Products.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IRabbitMqService _rabbitMqService;

        public ProductsController(IProductService productService, IRabbitMqService rabbitMqService)
        {
            _productService = productService;
            _rabbitMqService = rabbitMqService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SendMessageAsync(ProductDto product)
        {
            try
            {
                await _rabbitMqService.SendMessageAsync(product);
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
