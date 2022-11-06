using SBAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserbyEmail(string email);
    void Add(User user);
}
