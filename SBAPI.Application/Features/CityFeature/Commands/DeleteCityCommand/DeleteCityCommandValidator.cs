using FluentValidation;
using SBAPI.Application.Features.BrandFeature.Commands.DeleteBrandCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.CityFeature.Commands.DeleteCityCommand
{
    public class DeleteCityCommandValidator : AbstractValidator<DeleteCityCommand>
    {
        public DeleteCityCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotNull().WithMessage("{PropertyName} no puede ser nulo")
               .NotEqual(0).WithMessage("{PropertyName} no puede ser igual a cero");
        }
    }
}
