using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.User;
using SBAPI.Application.Exceptions;
using SBAPI.Application.Repository;
using SBAPI.Application.Specifications.UserSpecification;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.UserFeature.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<Response<UserDto>>
    {
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? PorfilePhoto { get; set; }
        public int RolId { get; set; }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<User> _repositoryAsync;

        public CreateUserCommandHandler(IMapper mapper, IRepositoryAsync<User> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var findByName = await _repositoryAsync.FirstOrDefaultAsync(new FilterUserSpecification(request.FirstName + " " + request.LastName, null));
            if (findByName != null)
            {
                throw new ApiException($"Ya existe un usuario con el nombre {request.FirstName + " " + request.LastName}");
            }

            var newRecord = _mapper.Map<User>(request);

            newRecord.FirstName = request.FirstName;
            newRecord.LastName = request.LastName;
            newRecord.Password = request.Password;
            newRecord.RolId= request.RolId;
            newRecord.UserName = request.UserName;
            var data = await _repositoryAsync.AddAsync(newRecord);
            await _repositoryAsync.SaveChangesAsync();
            var dto = _mapper.Map<UserDto>(data);
            return new Response<UserDto>(dto, message:$"{data.UserName} creado exitosamente." );
        }
    }
}
