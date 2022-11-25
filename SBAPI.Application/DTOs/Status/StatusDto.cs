using SBAPI.Application.DTOs.TypeStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.DTOs.Status
{
    public class StatusDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int TypeStatusId { get; set; }
        public TypeStatusDto TypeStatus { get; set; } = null!;

    }
}
