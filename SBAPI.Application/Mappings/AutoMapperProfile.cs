using AutoMapper;
using SBAPI.Application.DTOs.Bank;
using SBAPI.Application.DTOs.BranchOffice;
using SBAPI.Application.DTOs.Brand;
using SBAPI.Application.DTOs.City;
using SBAPI.Application.DTOs.ClientType;
using SBAPI.Application.DTOs.Company;
using SBAPI.Application.DTOs.Department;
using SBAPI.Application.DTOs.Rol;
using SBAPI.Application.DTOs.Status;
using SBAPI.Application.DTOs.TypeStatus;
using SBAPI.Application.DTOs.User;
using SBAPI.Application.Features.BankFeature.Commands.CreateBankCommand;
using SBAPI.Application.Features.BranchOfficeFeature.Commands.CreateBranchOfficeCommand;
using SBAPI.Application.Features.BrandFeature.Commands.CreateBrandCommand;
using SBAPI.Application.Features.CityFeature.Commands.CreateCityCommand;
using SBAPI.Application.Features.ClientTypeFeature.Commands.CreateClientTypeCommand;
using SBAPI.Application.Features.CompanyFeature.Commands.CreateCompanyCommand;
using SBAPI.Application.Features.DepartmentFeature.Commands.CreateDepartmentCommand;
using SBAPI.Application.Features.RolFeature.Commands.CreateRolCommand;
using SBAPI.Application.Features.StatusFeature.Commands.CreateStatusCommand;
using SBAPI.Application.Features.TypeStatusFeature.Commands.CreateTypeStatusCommand;
using SBAPI.Application.Features.UserFeature.Commands.CreateUserCommand;
using SBAPI.Domain.Entities.Banks;
using SBAPI.Domain.Entities.BranchOffices;
using SBAPI.Domain.Entities.Brand;
using SBAPI.Domain.Entities.Cities;
using SBAPI.Domain.Entities.ClientTypes;
using SBAPI.Domain.Entities.Company;
using SBAPI.Domain.Entities.Departments;
using SBAPI.Domain.Entities.Roles;
using SBAPI.Domain.Entities.Statuses;
using SBAPI.Domain.Entities.TypeStatuses;
using SBAPI.Domain.Entities.Users;


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
            CreateMap<Brand, BrandDto>();
            CreateMap<ClientType, ClientTypeDto>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<City, CityDto>();
            CreateMap<Business, CompanyDto>();
            CreateMap<BranchOffice, BranchOfficeDto>();
            #endregion
            #region Commands
            CreateMap<CreateUserCommand, User>();
            CreateMap<CreateRolCommand, Rol>();
            CreateMap<CreateTypeStatusCommand, TypeStatus>();
            CreateMap<CreateStatusCommand, Status>();
            CreateMap<CreateBankCommand, Bank>();
            CreateMap<CreateBrandCommand, Brand>();
            CreateMap<CreateClientTypeCommand, ClientType>();
            CreateMap<CreateDepartmentCommand, Department>();
            CreateMap<CreateCityCommand,City>();
            CreateMap<CreateCompanyCommand,Business>();
            CreateMap<CreateBranchOfficeCommand, BranchOffice>();
            #endregion
        }
    }
}
