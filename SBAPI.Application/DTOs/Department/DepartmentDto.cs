﻿using SBAPI.Application.DTOs.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.DTOs.Department
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<CityDto>? Cities { get; set; }
    }
}