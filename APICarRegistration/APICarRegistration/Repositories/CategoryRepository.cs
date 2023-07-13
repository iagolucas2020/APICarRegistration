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

        public async Task<IEnumerable<Category>> GetAsync()
        {
            var category = await _context.Categories.AsNoTracking().Take(10).ToListAsync();
            return category;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category;
        }

        public async Task<Category> PostAsync(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> PutAsync(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task Delete(Category category)
        {
            _context.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
