using AutoMapper;
using SBAPI.Application.DTOs.Rol;
using SBAPI.Application.DTOs.User;
using SBAPI.Application.Features.RolFeature.Commands.CreateRolCommand;
using SBAPI.Application.Features.UserFeature.Commands.CreateUserCommand;
using SBAPI.Domain.Entities.Roles;
using SBAPI.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            #region DTOs
            CreateMap<User, UserDto>();
            CreateMap<Rol, RolDto>();
            #endregion
            #region Commands
            CreateMap<CreateUserCommand, User>();
            CreateMap<CreateRolCommand, Rol>();
            #endregion
        }
    }
}
