using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.Bank;
using SBAPI.Application.DTOs.Rol;
using SBAPI.Application.Exceptions;
using SBAPI.Application.Repository;
using SBAPI.Application.Specifications.BankSpecification;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Banks;
using SBAPI.Domain.Entities.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.BankFeature.Commands.CreateBankCommand
{
    public class CreateBankCommand : IRequest<Response<BankDto>>
    {
        public string Name { get; set; } = null!;
    }

    public class CreateBankCommandHandler : IRequestHandler<CreateBankCommand, Response<BankDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Bank> _repositoryAsync;
        public CreateBankCommandHandler(IMapper mapper,IRepositoryAsync<Bank> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<BankDto>> Handle(CreateBankCommand request, CancellationToken cancellationToken)
        {
            var findByName = await _repositoryAsync.FirstOrDefaultAsync(new FilterBankSpecification(request.Name,null));
            if (findByName != null)
            {
                throw new ApiException($"Ya existe un banco con el nombre {request.Name}");
            }
            var newRecord = _mapper.Map<Bank>(request);
            newRecord.Name = request.Name;
            var data = await _repositoryAsync.AddAsync(newRecord);
            await _repositoryAsync.SaveChangesAsync();
            var dto = _mapper.Map<BankDto>(data);
            return new Response<BankDto>(dto, message: $"{data.Name} creado exitosamente");
        }
    }
}
