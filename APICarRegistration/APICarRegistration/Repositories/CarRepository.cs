using APICarRegistration.Context;
using APICarRegistration.Models;
using APICarRegistration.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APICarRegistration.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _context;

        public CarRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAsync()
        {
            var car = await _context.Cars.AsNoTracking().Take(10).ToListAsync();
            return car;
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            return car;
        }

        public async Task<Car> PostAsync(Car car)
        {
            _context.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> PutAsync(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task Delete(Car car)
        {
            _context.Remove(car);
            await _context.SaveChangesAsync();
        }
    }
}
