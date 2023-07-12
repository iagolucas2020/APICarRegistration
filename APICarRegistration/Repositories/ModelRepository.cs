using APICarRegistration.Context;
using APICarRegistration.Models;
using APICarRegistration.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APICarRegistration.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private readonly AppDbContext _context;

        public ModelRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Model>> GetAsync()
        {
            var model = await _context.Models.AsNoTracking().Take(10).ToListAsync();
            return model;
        }

        public async Task<IEnumerable<Model>> GetModelWithCarsAsync()
        {
            var model = await _context.Models.Include(c => c.Cars).AsNoTracking().Take(10).ToListAsync();
            return model;
        }

        public async Task<Model> GetByIdAsync(int id)
        {
            var model = await _context.Models.FindAsync(id);
            return model;
        }

        public async Task<Model> PostAsync(Model model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Model> PutAsync(Model model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task Delete(Model model)
        {
            _context.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
