using MediatR;
using SBAPI.Application.DTOs.TypeStatus;
using SBAPI.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.TypeStatusFeature.Commands.UpdateTypeStatusCommand
{
    public class UpdateTypeStatusCommand : IRequest<Response<TypeStatusDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
