using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.Status;
using SBAPI.Application.Exceptions;
using SBAPI.Application.Repository;
using SBAPI.Application.Specifications.StatusSpecification;
using SBAPI.Application.Specifications.TypeStatusSpecification;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Statuses;
using SBAPI.Domain.Entities.TypeStatuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.StatusFeature.Commands.CreateStatusCommand
{
    public class CreateStatusCommand : IRequest<Response<StatusDto>>
    {
        public string Name { get; set; } = null!;
        public int TypeStatusId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class CreateStatusCommandHandler : IRequestHandler<CreateStatusCommand, Response<StatusDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Status> _repositoryAsync;
        public CreateStatusCommandHandler(IMapper mapper, IRepositoryAsync<Status> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<StatusDto>> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
        {
            var findByName = await _repositoryAsync.FirstOrDefaultAsync(new FilterStatusSpecification(request.Name, null));
            if(findByName != null)
            {
                throw new ApiException($"Ya existe un estado con el nombre {request.Name}");
            }
            else
            {
                var newRecord = _mapper.Map<Status>(request);
                newRecord.Name = request.Name;
                newRecord.TypeStatusId= request.TypeStatusId;
                if(request.IsActive != null)
                {
                    newRecord.IsActive = (bool)request.IsActive;
                }
                var data = await _repositoryAsync.AddAsync(newRecord);
                await _repositoryAsync.SaveChangesAsync();
                var dto = _mapper.Map<StatusDto>(data);
                return new Response<StatusDto>(dto, message: $"{data.Name} creado exitosamente");
            }
        }
    }
}
