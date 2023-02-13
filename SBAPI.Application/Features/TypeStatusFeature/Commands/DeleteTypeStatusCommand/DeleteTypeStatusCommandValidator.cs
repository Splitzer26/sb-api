using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.TypeStatusFeature.Commands.DeleteTypeStatusCommand
{
    public class DeleteTypeStatusCommandValidator: AbstractValidator<DeleteTypeStatusCommand>
    {
        public DeleteTypeStatusCommandValidator()
    {
        RuleFor(p => p.Id)
           .NotNull().WithMessage("{PropertyName} no puede ser nulo")
           .NotEqual(0).WithMessage("{PropertyName} no puede ser igual a cero");
    }
}
}
