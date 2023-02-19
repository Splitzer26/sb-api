
using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.BranchOffice;
using SBAPI.Application.Exceptions;
using SBAPI.Application.Repository;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.BranchOffices;
using SBAPI.Domain.Entities.Company;

namespace SBAPI.Application.Features.BranchOfficeFeature.Commands.CreateBranchOfficeCommand
{
    public class CreateBranchOfficeCommand : IRequest<Response<BranchOfficeDto>>
    {
        public int CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string ManagerName { get; set; } = string.Empty!;
        public string ManagerEmail { get; set; } = string.Empty!;
        public decimal? Lat { get; set; }
        public decimal? Lng { get; set; }
        public string Address { get; set; } = string.Empty!;
        public bool IsActive { get; set; }
    }
    public class CreateBranchOfficeCommandHandler:IRequestHandler<CreateBranchOfficeCommand, Response<BranchOfficeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<BranchOffice> _repositoryAsync;
        private readonly IRepositoryAsync<Business> _companyRepositoryAsync;
        public CreateBranchOfficeCommandHandler(IMapper mapper, IRepositoryAsync<Business> companyRepositoryAsync, IRepositoryAsync<BranchOffice> repositoryAsync)
        {
            _companyRepositoryAsync = companyRepositoryAsync;
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<BranchOfficeDto>> Handle(CreateBranchOfficeCommand request, CancellationToken cancellation)
        {
            var company = await _companyRepositoryAsync.GetByIdAsync(request.CompanyId);
            if(company == null)
            {
                throw new ApiException($"No existe una compañia con el id: {request.CompanyId}");
            }
            var newRecord = _mapper.Map<BranchOffice>(request);
            newRecord.CompanyId = request.CompanyId;
            newRecord.Name = request.Name;
            newRecord.ManagerName = request.ManagerName;
            newRecord.ManagerEmail = request.ManagerEmail;
            newRecord.Address = request.Address;
            newRecord.IsActive = request.IsActive;
            if(request.PhoneNumber !=null)
            {
                newRecord.PhoneNumber = request.PhoneNumber;
            }
            if(request.Lat != null)
            {
                newRecord.Lat = (decimal)request.Lat;
            }
            if(request.Lng != null)
            {
                newRecord.Lng = (decimal)request.Lng;
            }
            var data = await _repositoryAsync.AddAsync(newRecord);
            await _repositoryAsync.SaveChangesAsync();
            var dto = _mapper.Map<BranchOfficeDto>(data);
            return new Response<BranchOfficeDto>(dto, message: $"{data.Name} creada exitosamente");
        }
    }
}
