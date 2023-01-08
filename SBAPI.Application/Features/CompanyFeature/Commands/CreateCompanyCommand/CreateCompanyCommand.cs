using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.Company;
using SBAPI.Application.Exceptions;
using SBAPI.Application.Repository;
using SBAPI.Application.Specifications.CompanySpecification;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.Company;


namespace SBAPI.Application.Features.CompanyFeature.Commands.CreateCompanyCommand
{
    public class CreateCompanyCommand : IRequest<Response<CompanyDto>>
    {
        public string Name { get; set; }
        public string TaxId { get; set; }
        public string PhoneNumber1 { get; set; }
        public string? PhoneNumber2 { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string? WebSite { get; set; }
        public string LogoType { get; set; }
    }

    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Response<CompanyDto>>
    {
        public readonly IRepositoryAsync<Business> _repositoryAsync;
        public readonly IMapper _mapper;
        public CreateCompanyCommandHandler(IRepositoryAsync<Business> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<CompanyDto>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var findByName = await _repositoryAsync.FirstOrDefaultAsync(new FilterCompanySpecification(name: request.Name, null));
            if(findByName != null)
            {
                throw new ApiException($"Ya existe una compañia con el nombre {request.Name}");
            }
            var findByTaxId = await _repositoryAsync.FirstOrDefaultAsync(new FilterCompanySpecification( null,taxId: request.TaxId));
            if (findByTaxId != null)
            {
                throw new ApiException($"Ya existe una compañia con el RTN {request.TaxId}");
            }
            var newRecord = _mapper.Map<Business>(request);
            newRecord.Name = request.Name;
            newRecord.TaxId = request.TaxId;
            newRecord.Address = request.Address;
            newRecord.Email= request.Email;
            newRecord.LogoType= request.LogoType;
            if(request.PhoneNumber2 != null) { newRecord.PhoneNumber2 = request.PhoneNumber2; }
            if (request.WebSite != null) { newRecord.WebSite = request.WebSite; }
            var data = await _repositoryAsync.AddAsync(newRecord);
            await _repositoryAsync.SaveChangesAsync();
            var dto = _mapper.Map<CompanyDto>(data);
            return new Response<CompanyDto>(dto, message: $"{data.Name} creada exitosamente");
        }
    }
}
