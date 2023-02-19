using System;
using FluentValidation;

namespace SBAPI.Application.Features.BranchOfficeFeature.Commands.UpdateBranchOfficeCommand
{
	public class UpdateBranchOfficeCommandValidator : AbstractValidator<UpdateBranchOfficeCommand>
	{
		public UpdateBranchOfficeCommandValidator()
		{
            RuleFor(p => p.CompanyId)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio");
            RuleFor(p => p.Name)
                  .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                  .MaximumLength(50).WithMessage("{PropertyName} no debe exceder {MaxLength} caracteres");
            RuleFor(p => p.ManagerName)
                  .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                  .MaximumLength(50).WithMessage("{PropertyName} no debe exceder {MaxLength} caracteres");
            RuleFor(p => p.ManagerEmail)
                  .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                  .MaximumLength(50).WithMessage("{PropertyName} no debe exceder {MaxLength} caracteres");
            RuleFor(p => p.Address)
                  .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                  .MaximumLength(150).WithMessage("{PropertyName} no debe exceder {MaxLength} caracteres");
            RuleFor(p => p.IsActive)
                  .NotEmpty().WithMessage("{PropertyName} no puede ser vacio");
        }
	}
}

