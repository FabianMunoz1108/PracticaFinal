using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Http;

namespace DeLaSalle.Ecommerce.WebApplication.Pages.Services.Interfaces
{
    public interface IProductCategoryService
    {
        Task<Response<List<ProductCategoryDto>>> GetAllAsync();
        Task<Response<ProductCategoryDto>> GetById(int id);
        Task<Response<ProductCategoryDto>> SaveAsync(ProductCategoryDto dto);
        Task<Response<ProductCategoryDto>> UpdateAsync(ProductCategoryDto dto);
        Task<Response<bool>> DeleteAsync(int id);
    }
}