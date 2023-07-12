using APICarRegistration.Models;

namespace APICarRegistration.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> PostAsync(Category category);
        Task<Category> PutAsync(Category category);
        Task Delete(Category category);
    }
}
