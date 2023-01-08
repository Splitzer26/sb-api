using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.City;
using SBAPI.Application.DTOs.Company;
using SBAPI.Application.Repository;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Cities;
using SBAPI.Domain.Entities.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.CompanyFeature.Commands.UpdateCompanyCommand
{
    public class UpdateCompanyCommand : IRequest<Response<CompanyDto>>
    {
        public int Id { get; init; }
        public string? Name { get; set; }
        public string? TaxId { get; set; }
        public string? PhoneNumber1 { get; set; }
        public string? PhoneNumber2 { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? WebSite { get; set; }
        public string? LogoType { get; set; }
    }
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Response<CompanyDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Business> _repositoryAsync;
        public UpdateCompanyCommandHandler(IMapper mapper, IRepositoryAsync<Business> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<CompanyDto>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _repositoryAsync.GetByIdAsync(request.Id);
            if (request.Name != null)
            {
                company!.Name = request?.Name;
            }
            if (request!.TaxId != null) { company!.TaxId = request!.TaxId; }
            if (request!.PhoneNumber1 != null) { company!.PhoneNumber1 = request?.PhoneNumber1; }
            if (request!.PhoneNumber2 != null) { company!.PhoneNumber2 = request?.PhoneNumber2; }
            if (request!.Address != null) { company!.Address = request!.Address; }
            if (request!.Email != null) { company!.Email = request!.Email; }
            if (request!.WebSite != null) { company!.WebSite = request!.WebSite; }
            if (request!.LogoType != null) { company!.LogoType = request!.LogoType; }
            await _repositoryAsync.UpdateAsync(company);
            await _repositoryAsync.SaveChangesAsync();
            var dto = _mapper.Map<CompanyDto>(company);
            return new Response<CompanyDto>(dto, message: $"{company.Name} actualizado correctamente");
        }
    }
}
