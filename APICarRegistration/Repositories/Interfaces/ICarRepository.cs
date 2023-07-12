using APICarRegistration.Models;

namespace APICarRegistration.Repositories.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAsync();
        Task<Car> GetByIdAsync(int id);
        Task<Car> PostAsync(Car car);
        Task<Car> PutAsync(Car car);
        Task Delete(Car car);
    }
}
