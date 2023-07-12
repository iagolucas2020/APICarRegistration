using APICarRegistration.Context;
using APICarRegistration.Models;
using APICarRegistration.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APICarRegistration.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly AppDbContext _context;

        public BrandRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Brand>> GetAsync()
        {
            var brands = await _context.Brands.AsNoTracking().Take(10).ToListAsync();
            return brands;
        }

        public async Task<Brand> GetByIdAsync(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            return brand;
        }

        public async Task<Brand> PostAsync(Brand brand)
        {
            _context.Add(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task<Brand> PutAsync(Brand brand)
        {
            _context.Entry(brand).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task Delete(Brand brand)
        {
            _context.Remove(brand);
            await _context.SaveChangesAsync();
        }
    }
}
