using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SBAPI.Application.DTOs.Auth;
using SBAPI.Application.Exceptions;
using SBAPI.Application.Repository;
using SBAPI.Application.Specifications.UserSpecification;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Users;
using SBAPI.Domain.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace SBAPI.Application.Features.UserFeature.Commands.LoginUserCommand
{
    public class LoginUserCommand : IRequest<Response<SessionUserDto>>
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; } = null!;
    }
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Response<SessionUserDto>>
    {
        private readonly IRepositoryAsync<User> _repositoryAsync;
        private readonly JWTSettings _jwtSettings;
        public LoginUserCommandHandler(IRepositoryAsync<User> repositoryAsync, IOptions<JWTSettings> jwtSettings)
        {
            _repositoryAsync = repositoryAsync;
            _jwtSettings = jwtSettings.Value;
        }
        public async Task<Response<SessionUserDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            if(request.UserName != null)
            {
                var userByName = await _repositoryAsync.FirstOrDefaultAsync(new FilterUserSpecification(request.UserName,null));
                if(userByName != null)
                {
                    var result = Authenticated(userByName, request);
                    return new Response<SessionUserDto>(result, message: $"Bienvenido {userByName.FirstName}");
                }
                else
                {
                    throw new ApiException($"No se encontro ningun usuario con el userName {request.UserName}");
                }
            }
            else if(request.Email != null )
            {
                var userByEmail = await _repositoryAsync.FirstOrDefaultAsync(
                new FilterUserSpecification(request.Email, null));
                if (userByEmail != null)
                {
                    var result = Authenticated(userByEmail, request);
                  
                    return new Response<SessionUserDto>(result, message: $"Bienvenido {userByEmail.FirstName}");
                }
                else
                {
                    throw new ApiException($"No se encontro ningun usuario con el correo {request.Email}");
                }
            }
            else
            {
                throw new ApiException($"Debe ingresar su correo o nombre de usuario");
            }
        }
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (storedHash.Length != 64)
                throw new ApiException("Invalid length of password hash (64 bytes expected).", "passwordHash");

            if (storedSalt.Length != 128)
                throw new ApiException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            var hmac = new HMACSHA512(storedSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != storedHash[i]) return false;
            }

            return true;
        }

        private SessionUserDto Authenticated(User user, LoginUserCommand request)
        {
            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                if (!VerifyPasswordHash(request.Password, user.MasterPasswordHash, user.MasterPasswordSalt))
                    throw new ApiException($"Verifique su contraseña");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, user.Rol != null ? user.Rol.Name : string.Empty),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("uid", user.Id.ToString()),
                }),
                //Expires = DateTime.UtcNow.AddMinutes(Int32.Parse(_jwtSettings.DurationInMinutes)),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            var sesion = new SessionUserDto
            {
                Id = user.Id,
                FullName = user.FirstName + " "+user.SecondName+" "+ user.LastName ,
                Email = user.Email,
                Photo = user.PorfilePhoto,
                UserName = user.UserName,
                Role = user.Rol != null ? user.Rol.Name : string.Empty,
                ExpirationDate = tokenDescriptor.Expires.Value,
                Token = tokenString
            };

            return sesion;
        }
    }
}
