using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.UserFeature.Commands.LoginUserCommand
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(x => x.UserName)
                .MaximumLength(30).WithMessage("{PropertyName} no debe exceder {MaxLength} caracteres");

            RuleFor(x => x.Email)
                .MaximumLength(30).WithMessage("{PropertyName} no debe exceder {MaxLength} caracteres")
                .EmailAddress().WithMessage("Verfique el formato de {PropertyName}");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(50).WithMessage("{PropertyName} no debe exceder {MaxLength} caracteres");
        }
    }
}
