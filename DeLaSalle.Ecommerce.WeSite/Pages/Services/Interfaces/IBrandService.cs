using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Http;

namespace DeLaSalle.Ecommerce.WebApplication.Pages.Services.Interfaces
{
    public interface IBrandService
    {
        string UrlAPI { get; set; }
        string Token { get; set; }

        Task<Response<List<BrandDto>>> GetAllAsync();
        Task<Response<BrandDto>> GetByIdAsync(int id);
        Task<Response<BrandDto>> SaveAsync(BrandDto dto);
        Task<Response<BrandDto>> UpdateAsync(BrandDto dto);
        Task<Response<bool>> DeleteAsync(int id);
    }
}