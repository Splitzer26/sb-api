using AutoMapper;
using SBAPI.Application.DTOs.Bank;
using SBAPI.Application.DTOs.Rol;
using SBAPI.Application.DTOs.Status;
using SBAPI.Application.DTOs.TypeStatus;
using SBAPI.Application.DTOs.User;
using SBAPI.Application.Features.BankFeature.Commands.CreateBankCommand;
using SBAPI.Application.Features.RolFeature.Commands.CreateRolCommand;
using SBAPI.Application.Features.StatusFeature.Commands.CreateStatusCommand;
using SBAPI.Application.Features.TypeStatusFeature.Commands.CreateTypeStatusCommand;
using SBAPI.Application.Features.UserFeature.Commands.CreateUserCommand;
using SBAPI.Domain.Entities.Banks;
using SBAPI.Domain.Entities.Roles;
using SBAPI.Domain.Entities.Statuses;
using SBAPI.Domain.Entities.TypeStatuses;
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
            CreateMap<TypeStatus, TypeStatusDto>();
            CreateMap<Status, StatusDto>();
            CreateMap<Bank, BankDto>();
            #endregion
            #region Commands
            CreateMap<CreateUserCommand, User>();
            CreateMap<CreateRolCommand, Rol>();
            CreateMap<CreateTypeStatusCommand, TypeStatus>();
            CreateMap<CreateStatusCommand, Status>();
            CreateMap<CreateBankCommand, Bank>();
            #endregion
        }
    }
}
