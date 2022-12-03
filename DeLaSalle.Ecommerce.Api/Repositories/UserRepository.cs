using Dapper.Contrib.Extensions;
using DeLaSalle.Ecommerce.Api.DataAccess.Interfaces;
using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;
using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Entities;
using DeLaSalle.Ecommerce.Core.Records;

namespace DeLaSalle.Ecommerce.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Globales
        private IDbContext _context;
        #endregion

        #region Constructores
        public UserRepository(IDbContext context)
        {
            _context = context;
        }
        #endregion

        #region métodos
        /// <summary>
        /// Validación de credenciales de usuario
        /// </summary>
        /// <param name="authenticate">Credenciales de usuario</param>
        /// <returns>Nombre de usuario autenticado</returns>
        public async Task<UserDto?> ValidateUserCredentialsAsync(AuthenticateRequest authenticate)
        {
            User? usr = await _context.Connection.GetAsync<User?>(authenticate.UserName);
            if (usr != null && usr.Password == authenticate.Password && !usr.IsDeleted)
            {
                UserDto dto = new()
                {
                    Login = usr.Login,
                    Name = usr.Name
                };
                return dto;
            }
            return null;
        }
        #endregion
    }
}