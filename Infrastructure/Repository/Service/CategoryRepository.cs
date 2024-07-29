using Domain.Dto;
using Domain.Entity;
using Infrastructure.Repository.Interface;
using Infrastructure.UOW.Interface;

namespace Infrastructure.Repository.Service
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _uow;

        public CategoryRepository(ApplicationDbContext context, IUnitOfWork uow)
        {
            _context = context;
            _uow = uow;
        }

        public void create(CategoryDto category)
        {
            Category entity = new()
            {
                Name = category.Name
            };

            _context.Categories.Add(entity);
            _uow.Commit();
        }

        public void updateCategory(CategoryDto category, int id)
        {
            Category entity = _context.Categories.FirstOrDefault(c => c.Id == id)!;
            entity.Name = category.Name;
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
