using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Features.BankFeature.Commands.DeleteBankCommand
{
    public class DeleteBankCommandValidator : AbstractValidator<DeleteBankCommand>
    {
        public DeleteBankCommandValidator() 
        {
            RuleFor(p => p.Id)
                   .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                   .NotEqual(0).WithMessage("{PropertyName} no puede ser igual a cero");
        }
    }
}
