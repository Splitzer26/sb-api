using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.Bank;
using SBAPI.Application.Repository;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Banks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.BankFeature.Commands.UpdateBankCommand
{
    public class UpdateBankCommand : IRequest<Response<BankDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
    public class UpdateBankCommandHandler : IRequestHandler<UpdateBankCommand, Response<BankDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Bank> _repositoryAsync;
        public UpdateBankCommandHandler(IMapper mapper, IRepositoryAsync<Bank> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<BankDto>> Handle(UpdateBankCommand request, CancellationToken cancellationToken)
        {
            var bank = await _repositoryAsync.GetByIdAsync(request.Id);
            if (bank != null)
            {
                bank.Name = request.Name;
                await _repositoryAsync.UpdateAsync(bank);
                await _repositoryAsync.SaveChangesAsync();
                var dto = _mapper.Map<BankDto>(bank);
                return new Response<BankDto>(dto, message: $"El banco ha sido actualizado exitosamente.");
            }
            else
            {
                throw new KeyNotFoundException($"No se encontro ningun registro con el id {request.Id}");
            }
        }
    }
}
