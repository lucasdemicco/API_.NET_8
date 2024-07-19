using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace API.Products.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ICategoryService categoryService, ILogger<CategoriesController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [HttpPost("CreateCategory")]
        public IActionResult CreateCategory(CategoryDto category)
        {
            try
            {
                _logger.LogInformation("Adicionando nova categoria...");
                _categoryService.createCategory(category);
                return StatusCode(StatusCodes.Status201Created, $"Categoria {category.Name} criada com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }
    }
}
