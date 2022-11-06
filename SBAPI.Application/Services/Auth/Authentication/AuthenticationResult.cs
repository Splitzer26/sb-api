using SBAPI.Domain.Entities;

namespace SBAPI.Application.Services.Auth.Authentication;
public record AuthenticationResult(
    User User,
    string Token);
