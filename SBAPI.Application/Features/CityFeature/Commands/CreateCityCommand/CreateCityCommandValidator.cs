using FluentValidation;
using SBAPI.Application.Features.BrandFeature.Commands.CreateBrandCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.CityFeature.Commands.CreateCityCommand
{
    public class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
    {
        public CreateCityCommandValidator()
        {
            RuleFor(p => p.Name)
           .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
           .MaximumLength(50).WithMessage("{PropertyName} no debe exceder {MaxLength} caracteres");

            RuleFor(p => p.DepartmentId)
           .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
           .NotEqual(0).WithMessage("{PropertyName} no puede ser cero");

        }
    }
}
