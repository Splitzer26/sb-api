using FluentValidation;
using SBAPI.Application.Features.BrandFeature.Commands.CreateBrandCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.DepartmentFeature.Commands.CreateDepartmentCommand
{
    public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidator()
        {
            RuleFor(p => p.Name)
           .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
           .MaximumLength(50).WithMessage("{PropertyName} no debe exceder {MaxLength} caracteres");
        }
    }
}
