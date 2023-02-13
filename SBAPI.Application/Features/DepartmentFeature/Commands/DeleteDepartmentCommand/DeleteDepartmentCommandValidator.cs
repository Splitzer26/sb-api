using FluentValidation;
using SBAPI.Application.Features.BrandFeature.Commands.DeleteBrandCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.DepartmentFeature.Commands.DeleteDepartmentCommand
{
    public class DeleteDepartmentCommandValidator : AbstractValidator<DeleteDepartmentCommand>
    {
        public DeleteDepartmentCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotNull().WithMessage("{PropertyName} no puede ser nulo")
               .NotEqual(0).WithMessage("{PropertyName} no puede ser igual a cero");
        }
    }
}
