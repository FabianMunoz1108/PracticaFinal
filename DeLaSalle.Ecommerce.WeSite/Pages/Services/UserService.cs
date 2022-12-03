using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Http;
using DeLaSalle.Ecommerce.Core.Records;
using DeLaSalle.Ecommerce.WebApplication.Pages.Services.Interfaces;

namespace DeLaSalle.Ecommerce.WebSite.Pages.Services
{
    public class UserService : IUserService
    {
        public string UrlAPI { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task<Response<UserDto>> SaveAsync(AuthenticateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}