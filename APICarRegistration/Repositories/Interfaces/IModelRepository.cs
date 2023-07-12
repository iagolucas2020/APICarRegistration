using APICarRegistration.Models;

namespace APICarRegistration.Repositories.Interfaces
{
    public interface IModelRepository
    {
        Task<IEnumerable<Model>> GetAsync();
        Task<IEnumerable<Model>> GetModelWithCarsAsync();
        Task<Model> GetByIdAsync(int id);
        Task<Model> PostAsync(Model model);
        Task<Model> PutAsync(Model model);
        Task Delete(Model model);
    }
}
