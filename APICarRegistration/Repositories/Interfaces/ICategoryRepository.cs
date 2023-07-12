using APICarRegistration.Models;

namespace APICarRegistration.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Get();
        Category GetById(int id);
        Category Post(Category category);
        Category Put(Category category);
        void Delete(Category category);
    }
}
