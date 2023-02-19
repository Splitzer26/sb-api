﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace SBAPI.Application.Features.BranchOfficeFeature.Commands.CreateBranchOfficeCommand
{
    public class CreateBranchOfficeCommandValidator : AbstractValidator<CreateBranchOfficeCommand>
    {
        public CreateBranchOfficeCommandValidator()
        {
            RuleFor(p => p.CompanyId)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio");
            RuleFor(p => p.Name)
                  .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                  .MaximumLength(50).WithMessage("{PropertyName} no debe exceder {MaxLength} caracteres");
            RuleFor(p => p.ManagerName)
                  .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                  .MaximumLength(50).WithMessage("{PropertyName} no debe exceder {MaxLength} caracteres");
            RuleFor(p => p.ManagerEmail)
                  .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                  .MaximumLength(50).WithMessage("{PropertyName} no debe exceder {MaxLength} caracteres");
            RuleFor(p => p.Address)
                  .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                  .MaximumLength(150).WithMessage("{PropertyName} no debe exceder {MaxLength} caracteres");
            RuleFor(p => p.IsActive)
                  .NotEmpty().WithMessage("{PropertyName} no puede ser vacio");
                  
        }
    }
}
