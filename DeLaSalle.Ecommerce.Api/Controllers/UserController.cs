using DeLaSalle.Ecommerce.Api.Services.Interfaces;
using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Entities;
using DeLaSalle.Ecommerce.Core.Http;
using DeLaSalle.Ecommerce.Core.Records;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DeLaSalle.Ecommerce.Api.Controllers
{
    /// <summary>
    /// Proporciona los métodos para la autenticación de usuario y obtención de token
    /// </summary>
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        #region Globales
        private readonly IUserService _service;
        private readonly JwtSettings _jwtSettings;
        #endregion

        #region Constructores
        public UserController(IUserService service, IOptions<JwtSettings> jwtSettings)
        {
            _service = service;
            _jwtSettings = jwtSettings.Value;

        }
        #endregion

        #region Métodos
        /// <summary>
        /// Genera token de sesión si las credenciales del usuario son correctas
        /// </summary>
        /// <param name="authenticate">Credenciales de usuario</param>
        /// <returns>Token y nombre de usuario</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Response<UserDto>>> PostUser(AuthenticateRequest authenticate)
        {
            var res = new Response<UserDto>();

            UserDto? user = await _service.ValidateUserCredentialsAsync(authenticate);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Sid, user.Login)
                };
                /*Validez en minutos del token*/
                _ = int.TryParse(_jwtSettings.Expires, out int expires);

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
                var tokenDescriptor = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Audience,
                    claims: claims,
                    /*expires: DateTime.Now.AddMinutes(expires),*/
                    signingCredentials: credentials);

                user.Token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
                res.Data = user;
                return Ok(res);
            }
            return NotFound(res);
        }
        #endregion
    }
}