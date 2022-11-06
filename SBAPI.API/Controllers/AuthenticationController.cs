using Microsoft.AspNetCore.Mvc;
using SBAPI.Contracts.Authentication;
using SBAPI.Application.Services.Auth.Authentication;

namespace SBAPI.API.Controllers;
[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var registerResult = _authenticationService.Register(
            request.FistName, 
            request.LastName, 
            request.Email, 
            request.Password);

        var response = new AuthenticationResponse(
            registerResult.User.Id,
            registerResult.User.FirstName,
            registerResult.User.LastName,
            registerResult.User.Email,
            registerResult.Token
            );
        return Ok(response);
    }
    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
         var loginResult = _authenticationService.Login(
            request.Email, 
            request.Password);

        var response = new AuthenticationResponse(
            loginResult.User.Id,
            loginResult.User.FirstName,
            loginResult.User.LastName,
            loginResult.User.Email,
            loginResult.Token
            );
        return Ok(response);
    }
}