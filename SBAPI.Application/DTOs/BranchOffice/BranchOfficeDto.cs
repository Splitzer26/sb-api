using SBAPI.Application.DTOs.Company;


namespace SBAPI.Application.DTOs.BranchOffice
{
    public class BranchOfficeDto
    {
        public int Id { get; init; }
        public int CompanyId { get; set; }
        public virtual CompanyDto? Company { get; set; }
        public string Name { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string ManagerName { get; set; } = string.Empty!;
        public string ManagerEmail { get; set; } = string.Empty!;
        public decimal? Lat { get; set; }
        public decimal? Lng { get; set; }
        public string Address { get; set; } = string.Empty!;
        public bool IsActive { get; set; }
    }
}
