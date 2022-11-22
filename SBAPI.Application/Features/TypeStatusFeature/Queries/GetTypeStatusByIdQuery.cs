using MediatR;
using SBAPI.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.TypeStatusFeature.Queries
{
    public class GetTypeStatusByIdQuery 
    {
        public int Id { get; set; }
    }
}
