using FluentValidation;
using SBAPI.Application.Features.RolFeature.Commands.CreateRolCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.TypeStatusFeature.Commands.CreateTypeStatusCommand
{
    public class CreateTypeStatusCommandValidator : AbstractValidator<CreateTypeStatusCommand>
    {
        public CreateTypeStatusCommandValidator()
        {
            RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
            .MaximumLength(50).WithMessage("{PropertyName} no debe exceder {MaxLength} caracteres");
        }
    }
}
