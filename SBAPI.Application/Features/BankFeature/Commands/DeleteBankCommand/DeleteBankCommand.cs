using AutoMapper;
using MediatR;
using SBAPI.Application.Repository;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Banks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.BankFeature.Commands.DeleteBankCommand
{
    public class DeleteBankCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
    public class DeleteBankCommandHandler : IRequestHandler<DeleteBankCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Bank> _repositoryAsync;
        public DeleteBankCommandHandler(IMapper mapper, IRepositoryAsync<Bank> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<string>> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
        {
            var bank = await _repositoryAsync.GetByIdAsync(request.Id);
            if (bank != null)
            {
                await _repositoryAsync.DeleteAsync(bank);
                await _repositoryAsync.SaveChangesAsync();
                return new Response<string>($"Banco eliminado correctamente", "Eliminado correctamente");
            }
            else
            {
                throw new KeyNotFoundException($"No se encontro ningun registro con el id {request.Id}");
            }
        }

    }
}
