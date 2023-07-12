using APICarRegistration.Models;

namespace APICarRegistration.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> Get();
        Brand GetById(int id);
        Brand Post(Brand brand);
        Brand Put(Brand brand);
        void Delete(Brand brand);
    }
}
