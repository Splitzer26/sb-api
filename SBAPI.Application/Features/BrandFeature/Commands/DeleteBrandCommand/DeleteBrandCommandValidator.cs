using FluentValidation;
using SBAPI.Application.Features.RolFeature.Commands.DeleteRolCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.BrandFeature.Commands.DeleteBrandCommand
{
    public class DeleteBrandCommandValidator : AbstractValidator<DeleteBrandCommand>
    {
        public DeleteBrandCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotNull().WithMessage("{PropertyName} no puede ser nulo")
               .NotEqual(0).WithMessage("{PropertyName} no puede ser igual a cero");
        }
    }
}
