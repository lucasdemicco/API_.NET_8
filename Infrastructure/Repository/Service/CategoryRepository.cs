using Domain.Dto;
using Domain.Entity;
using Infrastructure.Repository.Interface;

namespace Infrastructure.Repository.Service
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void create(CategoryDto category)
        {
            Category entity = new()
            {
                Name = category.Name
            };

            _context.Categories.Add(entity);
            _context.SaveChanges();
        }
    }
}
