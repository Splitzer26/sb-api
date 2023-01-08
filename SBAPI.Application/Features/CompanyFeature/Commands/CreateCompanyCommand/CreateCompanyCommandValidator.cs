using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.CompanyFeature.Commands.CreateCompanyCommand
{
    internal class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(p => p.Name)
                   .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                   .NotEqual("").WithMessage("{PropertyName} no puede ser igual a vacio");
            RuleFor(p => p.TaxId)
                  .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                  .NotEqual("").WithMessage("{PropertyName} no puede ser igual a vacio").Length(14).WithMessage("El RTN debe contener 14 caracteres");
            RuleFor(p => p.PhoneNumber1)
                  .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                  .NotEqual("").WithMessage("{PropertyName} no puede ser igual a vacio");
            RuleFor(p => p.Address)
                  .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                  .NotEqual("").WithMessage("{PropertyName} no puede ser igual a vacio");
            RuleFor(p => p.Email)
                  .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                  .NotEqual("").WithMessage("{PropertyName} no puede ser igual a vacio");
            RuleFor(p => p.LogoType)
                  .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                  .NotEqual("").WithMessage("{PropertyName} no puede ser igual a vacio");
        }
    }
}
