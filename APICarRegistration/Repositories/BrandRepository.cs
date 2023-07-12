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

        IEnumerable<Brand> IBrandRepository.Get()
        {
            var brands = _context.Brands.AsNoTracking().Take(10).ToList();
            return brands;
        }

        public Brand GetById(int id)
        {
            var brand = _context.Brands.AsNoTracking().FirstOrDefault(x => x.Id.Equals(id));
            return brand;
        }

        public Brand Post(Brand brand)
        {
            _context.Add(brand);
            _context.SaveChanges();
            return brand;
        }

        public Brand Put(Brand brand)
        {
            _context.Entry(brand).State = EntityState.Modified;
            _context.SaveChanges();
            return brand;
        }

        public void Delete(Brand brand)
        {
            _context.Remove(brand);
            _context.SaveChanges();
        }
    }
}
