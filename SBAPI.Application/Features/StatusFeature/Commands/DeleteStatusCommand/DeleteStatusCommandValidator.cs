using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.StatusFeature.Commands.DeleteStatusCommand
{
    public class DeleteStatusCommandValidator : AbstractValidator<DeleteStatusCommand>
    {
        public DeleteStatusCommandValidator() {
            RuleFor(p => p.Id)
                   .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                   .NotEqual(0).WithMessage("{PropertyName} no puede ser igual a cero");
        }
    }
}
