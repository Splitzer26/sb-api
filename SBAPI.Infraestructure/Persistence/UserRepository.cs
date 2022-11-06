using SBAPI.Application.Common.Interfaces.Persistence;
using SBAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Infraestructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserbyEmail(string email)
    {
       return _users.SingleOrDefault(a=>a.Email ==email);
    }
}
