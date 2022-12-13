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
        public async Task<Response<CompanyDto>> Handler(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _repositoryAsync.GetByIdAsync(request.Id);
            if (request.name != null)
            {
                company.Name = request?.Name;
            }
            if (request.TaxIdId != null) { company.TaxId = request?.TaxId; }

            await _repositoryAsync.UpdateAsync(city);
            await _repositoryAsync.SaveChangesAsync();
            var dto = _mapper.Map<CityDto>(city);
            return new Response<CityDto>(dto, message: $"{city.Name} actualizado correctamente");
        }
    }
}
