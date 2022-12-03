using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Records;

namespace DeLaSalle.Ecommerce.Api.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> ValidateUserCredentialsAsync(AuthenticateRequest authenticate);
    }
}