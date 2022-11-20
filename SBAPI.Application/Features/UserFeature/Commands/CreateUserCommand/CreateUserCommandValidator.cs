using FluentValidation;


namespace SBAPI.Application.Features.UserFeature.Commands.CreateUserCommand
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.FirstName)
            .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
            .MaximumLength(50).WithMessage("{PropertyName} no debe exceder {MaxLength} caracteres");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(50).WithMessage("{PropertyName} no debe exceder {MaxLength} caracteres");

            RuleFor(p => p.SecondName)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(30).WithMessage("{PropertyName} no debe exceder {MaxLength} caracteres");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$")
                .WithMessage("La {PropertyName} debe tener mínimo ocho caracteres, al menos una letra mayúscula, una letra minúscula y un número");

            RuleFor(p => p.RolId)
                .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                .NotEqual(0).WithMessage("{PropertyName} no puede ser igual a cero");
        }
    }
}
