using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBAPI.Application.Common.Interfaces.Service;

namespace SBAPI.Infraestructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime utcNow => DateTime.UtcNow;
}
