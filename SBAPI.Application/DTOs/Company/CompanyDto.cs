using SBAPI.Application.DTOs.BranchOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.DTOs.Company
{
    public class CompanyDto
    {
        public int Id { get; init; }
        public string Name { get; set; } = null!;
        public string TaxId { get; set; } = null!;
        public string? PhoneNumber1 { get; set; } 
        public string? PhoneNumber2 { get; set; } 
        public string Address { get; set; } = null!; 
        public string Email { get; set; } = null!; 
        public string? WebSite { get; set; } 
        public string LogoType { get; set; } = null!;
        public List<BranchOfficeDto>? BranchOffices { get; set; }
    }
}
