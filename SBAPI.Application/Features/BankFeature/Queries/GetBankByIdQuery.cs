﻿using AutoMapper;
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

namespace SBAPI.Application.Features.BankFeature.Queries
{
    public class GetBankByIdQuery : IRequest<Response<BankDto>>
    {
        public int Id { get; set; }
    }
    public class GetBankByIdQueryHandler : IRequestHandler<GetBankByIdQuery, Response<BankDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Bank> _repositoryAsync;
        public GetBankByIdQueryHandler(IMapper mapper, IRepositoryAsync<Bank> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<BankDto>> Handle(GetBankByIdQuery request, CancellationToken cancellationToken)
        {
            var bank = await _repositoryAsync.GetByIdAsync(request.Id);
            if(bank != null) 
            {
                var dto = _mapper.Map<BankDto>(bank);
                return new Response<BankDto> ( dto );
            }
            else
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
        }
    }
}
