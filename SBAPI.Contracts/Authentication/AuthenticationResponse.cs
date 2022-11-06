namespace SBAPI.Contracts.Authentication
{
    public record AuthenticationResponse(
        Guid Id,
        string FistName,
        string LastName,
        string Email,
        string Token);
}