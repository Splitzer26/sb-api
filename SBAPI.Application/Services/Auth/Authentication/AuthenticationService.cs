using SBAPI.Application.Common.Interfaces.Authentication;
using SBAPI.Application.Common.Interfaces.Persistence;
using SBAPI.Domain.Entities;

namespace SBAPI.Application.Services.Auth.Authentication;
public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _iJwtTokenGenerator;
    private readonly IUserRepository _iUserRepository;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository iUserRepository)
    {
        _iJwtTokenGenerator = jwtTokenGenerator;
        _iUserRepository = iUserRepository;
    }
    public AuthenticationResult Register(string fistName, string lastName, string email, string password)
    {
        //1. Validate the user doesnt exist
        if(_iUserRepository.GetUserbyEmail(email) != null)
        {
            throw new Exception("Ya existe un usuario con este correo electronico");
        }
        //2. Create user in database
        var user = new User { FirstName = fistName, LastName = lastName, Email = email, Password = password };
        _iUserRepository.Add(user);

        //Create JWT token
        var token = _iJwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
        user,
        token
        );
    }

    public AuthenticationResult Login(string email, string password)
    {
        //1.Validate the user exist
        if(_iUserRepository.GetUserbyEmail(email) is not User user)
        {
            throw new Exception("No existe un usuario con ese correo electronico");
        }
        //2. Validate the password is correct
        if(user.Password != password)
        {
            throw new Exception("Contraseña incorrecta");
        }
        //3. Create JWToken
        var token = _iJwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
        user,
        token
       );
    }
}