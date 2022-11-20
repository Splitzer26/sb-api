using FluentValidation;
using SBAPI.Application.Features.UserFeature.Commands.CreateUserCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.RolFeature.Commands.CreateRolCommand
{
    public class CreateRolCommandValidator : AbstractValidator<CreateRolCommand>
    {
        public CreateRolCommandValidator()
        {
            RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
            .MaximumLength(50).WithMessage("{PropertyName} no debe exceder {MaxLength} caracteres");
        }
    }
}
