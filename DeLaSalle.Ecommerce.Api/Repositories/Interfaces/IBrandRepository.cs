using DeLaSalle.Ecommerce.Core.Entities;

namespace DeLaSalle.Ecommerce.Api.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        Task<Brand> SaveAsync(Brand brand);
        Task<Brand> UpdateAsync(Brand brand);
        Task<List<Brand>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<Brand> GetByIdAsync(int id);
        Task<Brand?> GetByNameAsync(string name, int id);
    }
}