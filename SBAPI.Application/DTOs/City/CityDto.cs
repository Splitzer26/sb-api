using SBAPI.Application.DTOs.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.DTOs.City
{
    public class CityDto
    {
        public int Id { get; init; }
        public string Name { get; set; } = null!;
        public int DepartmentId { get; set; }
        public virtual DepartmentDto? Department { get; set; }
    }
}
