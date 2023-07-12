using APICarRegistration.Context;
using APICarRegistration.Models;
using APICarRegistration.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APICarRegistration.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        IEnumerable<Category> ICategoryRepository.Get()
        {
            var category = _context.Categories.AsNoTracking().Take(10).ToList();
            return category;
        }

        public Category GetById(int id)
        {
            var category = _context.Categories.AsNoTracking().FirstOrDefault(x => x.Id.Equals(id));
            return category;
        }

        public Category Post(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
            return category;
        }

        public Category Put(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
            return category;
        }

        public void Delete(Category category)
        {
            _context.Remove(category);
            _context.SaveChanges();
        }
    }
}
