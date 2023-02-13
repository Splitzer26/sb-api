using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.TypeStatus;
using SBAPI.Application.Exceptions;
using SBAPI.Application.Repository;
using SBAPI.Application.Specifications.TypeStatusSpecification;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.TypeStatuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.TypeStatusFeature.Commands.CreateTypeStatusCommand
{
    public class CreateTypeStatusCommand : IRequest<Response<TypeStatusDto>>
    {
        public string Name { get; set; } = null!;
        public bool? IsActive { get; set; }
    }
    public class CreateTypeStatusCommandHandler : IRequestHandler<CreateTypeStatusCommand, Response<TypeStatusDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<TypeStatus> _repositoryAsync;
        public CreateTypeStatusCommandHandler(IMapper mapper, IRepositoryAsync<TypeStatus> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<TypeStatusDto>> Handle(CreateTypeStatusCommand request, CancellationToken cancellationToken)
        {
            var findByName = await _repositoryAsync.FirstOrDefaultAsync(new FilterTypeStatusSpecification(request.Name,null));
            if (findByName != null)
            {
                throw new ApiException($"Ya existe un tipo de estado con el nombre {request.Name}");
            }
            else
            {
                var newRecord = _mapper.Map<TypeStatus>(request);
                newRecord.Name = request.Name;
                if(request.IsActive != null)
                {
                    newRecord.IsActive = (bool)request.IsActive;
                }
                var data = await _repositoryAsync.AddAsync(newRecord);
                await _repositoryAsync.SaveChangesAsync();
                var dto = _mapper.Map<TypeStatusDto>(data);
                return new Response<TypeStatusDto>(dto, message: $"{data.Name} creado exitosamente");
            }
        }
    }
}
