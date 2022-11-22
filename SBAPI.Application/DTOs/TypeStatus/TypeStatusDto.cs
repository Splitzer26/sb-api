using SBAPI.Application.DTOs.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.DTOs.TypeStatus
{
    public class TypeStatusDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
        public List<StatusDto>? Status { get; set; }
    }
}
