﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Services
{
    public interface IJwtService
    {
        public string GetSubjectToken();
    }
}
