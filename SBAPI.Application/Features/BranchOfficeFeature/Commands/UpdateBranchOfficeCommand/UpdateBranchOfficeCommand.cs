using System;
using AutoMapper;
using MediatR;
using SBAPI.Application.DTOs.BranchOffice;
using SBAPI.Application.DTOs.Company;
using SBAPI.Application.Repository;
using SBAPI.Application.Wrappers;
using SBAPI.Domain.Entities.BranchOffices;
using SBAPI.Domain.Entities.Company;

namespace SBAPI.Application.Features.BranchOfficeFeature.Commands.UpdateBranchOfficeCommand
{
	public class UpdateBranchOfficeCommand : IRequest<Response<BranchOfficeDto>>
	{
        public int Id { get; init; }
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
    public class UpdateBranchOfficeCommandHandler : IRequestHandler<UpdateBranchOfficeCommand, Response<BranchOfficeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<BranchOffice> _repositoryAsync;
        private readonly IRepositoryAsync<Business> _companyRepositoryAsync;
        public UpdateBranchOfficeCommandHandler(IMapper mapper, IRepositoryAsync<BranchOffice> repositoryAsync, IRepositoryAsync<Business> companyRepositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
            _companyRepositoryAsync = companyRepositoryAsync;
        }
        public async Task<Response<BranchOfficeDto>> Handle(UpdateBranchOfficeCommand request, CancellationToken cancellationToken)
        {
            var branchOffice = await _repositoryAsync.GetByIdAsync(request.Id);
            if(branchOffice == null)
            {
                throw new KeyNotFoundException($"No se encontro ninguna sucursal con el id {request.Id}");
            }
            var company = await _companyRepositoryAsync.GetByIdAsync(request.CompanyId);
            if(company == null)
            {
                throw new KeyNotFoundException($"No se encontro ninguna compañia con el id {request.CompanyId}");
            }
            branchOffice.CompanyId = request.CompanyId;
            branchOffice.Name = request.Name;
            branchOffice.ManagerName = request.ManagerName;
            branchOffice.ManagerEmail = request.ManagerEmail;
            branchOffice.Address = request.Address;
            branchOffice.IsActive = request.IsActive;
            if(request.PhoneNumber != null)
            {
                branchOffice.PhoneNumber = request.PhoneNumber;
            }
            if(request.Lat != null)
            {
                branchOffice.Lat = (decimal)request.Lat;
            }
            if (request.Lng != null)
            {
                branchOffice.Lng = (decimal)request.Lng;
            }
            await _repositoryAsync.UpdateAsync(branchOffice);
            await _repositoryAsync.SaveChangesAsync();
            var dto = _mapper.Map<BranchOfficeDto>(branchOffice);
            return new Response<BranchOfficeDto>(dto, message: $"La Sucursal ha sido actualizada exitosamente.");
        }
    }
}

