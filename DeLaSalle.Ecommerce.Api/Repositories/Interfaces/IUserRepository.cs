using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Records;

namespace DeLaSalle.Ecommerce.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto?> ValidateUserCredentialsAsync(AuthenticateRequest authenticate);
    }
}