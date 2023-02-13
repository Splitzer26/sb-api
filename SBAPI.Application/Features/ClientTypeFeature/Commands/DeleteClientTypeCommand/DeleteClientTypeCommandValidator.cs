using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.ClientTypeFeature.Commands.DeleteClientTypeCommand
{
    public class DeleteClientTypeCommandValidator : AbstractValidator<DeleteClientTypeCommand>
    {
        public DeleteClientTypeCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotNull().WithMessage("{PropertyName} no puede ser nulo")
               .NotEqual(0).WithMessage("{PropertyName} no puede ser igual a cero");
        }
    }
}
