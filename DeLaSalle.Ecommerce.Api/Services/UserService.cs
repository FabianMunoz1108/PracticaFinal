using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;
using DeLaSalle.Ecommerce.Api.Services.Interfaces;
using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Records;

namespace DeLaSalle.Ecommerce.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<UserDto?> ValidateUserCredentialsAsync(AuthenticateRequest authenticate)
        {
            return await _repository.ValidateUserCredentialsAsync(authenticate);
        }
    }
}