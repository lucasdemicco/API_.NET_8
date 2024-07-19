using Domain.Dto;
using Infrastructure.Repository.Interface;
using Services.Interface;

namespace Services.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void createCategory(CategoryDto category)
            => _categoryRepository.create(category);
    }
}
