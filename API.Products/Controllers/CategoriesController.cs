using Domain.Dto;
using Domain.Entity;
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

        [HttpPost("[action]")]
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

        [HttpPut("[action]/{id}")]
        public IActionResult EditCategory(int id, CategoryDto category)
        {
            try
            {
                _logger.LogInformation("Atualizando categoria...");
                _categoryService.updateCategory(category, id);
                return StatusCode(StatusCodes.Status200OK, $"Categoria {category.Name} atualizada com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                _logger.LogInformation("Removendo categoria...");
                _categoryService.deleteCategory(id);
                return StatusCode(StatusCodes.Status204NoContent, $"Categoria {id} removida com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
