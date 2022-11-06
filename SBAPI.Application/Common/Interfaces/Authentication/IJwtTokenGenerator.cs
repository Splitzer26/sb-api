using SBAPI.Domain.Entities;

namespace SBAPI.Application.Common.Interfaces.Authentication;

    public interface IJwtTokenGenerator
    {
         string GenerateToken(User user);
    }
