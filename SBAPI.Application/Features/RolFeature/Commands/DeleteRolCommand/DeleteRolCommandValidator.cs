using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.RolFeature.Commands.DeleteRolCommand
{
    public class DeleteRolCommandValidator: AbstractValidator<DeleteRolCommand>
    {
        public DeleteRolCommandValidator() 
        {
            RuleFor(p => p.Id)
               .NotNull().WithMessage("{PropertyName} no puede ser nulo")
               .NotEqual(0).WithMessage("{PropertyName} no puede ser igual a cero");
        }
    }
}
