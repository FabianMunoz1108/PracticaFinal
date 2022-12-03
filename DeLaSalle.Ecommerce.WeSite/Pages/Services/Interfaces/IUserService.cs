using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Http;
using DeLaSalle.Ecommerce.Core.Records;

namespace DeLaSalle.Ecommerce.WebApplication.Pages.Services.Interfaces
{
    public interface IUserService
    {
        string UrlAPI { get; set; }
        Task<Response<UserDto>> SaveAsync(AuthenticateRequest request);
    }
}