namespace SBAPI.Application.Services.Auth.Authentication;
public interface IAuthenticationService{
    AuthenticationResult Register(string fistName, string lastName, string email, string password);
    AuthenticationResult Login(string email, string password);
}