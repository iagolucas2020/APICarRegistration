using APICarRegistration.Models;

namespace APICarRegistration.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAsync();
        Task<Brand> GetByIdAsync(int id);
        Task<Brand> PostAsync(Brand brand);
        Task<Brand> PutAsync(Brand brand);
        Task Delete(Brand brand);
    }
}
