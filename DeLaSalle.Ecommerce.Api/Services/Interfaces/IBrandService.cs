using DeLaSalle.Ecommerce.Core.Dto;

namespace DeLaSalle.Ecommerce.Api.Services.Interfaces
{
    public interface IBrandService
    {
        Task<bool> BrandExistAsync(int id);
        Task<BrandDto> SaveAsync(BrandDto dto);
        Task<BrandDto> UpdateAsync(BrandDto dto);
        Task<List<BrandDto>?> GetAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<BrandDto?> GetByIdAsync(int id);
        Task<bool> ExistByNameAsync(string name, int id = 0);
    }
}