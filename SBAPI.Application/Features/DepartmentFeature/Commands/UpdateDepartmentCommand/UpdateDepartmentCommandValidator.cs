﻿using FluentValidation;
using SBAPI.Application.Features.BrandFeature.Commands.UpdateBrandCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.DepartmentFeature.Commands.UpdateDepartmentCommand
{
    public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
    {
        public UpdateDepartmentCommandValidator()
        {
            RuleFor(p => p.Id)
                   .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                   .NotEqual(0).WithMessage("{PropertyName} no puede ser igual a cero");

            RuleFor(p => p.Name)
                .NotNull().WithMessage("{PropertyName} no puede ser nulo");
        }
    }
}
