using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Commands.DeleteProgramingLanguage
{
    public class DeleteProgramingLanguageValidatior: AbstractValidator<DeleteProgramingLanguageCommand>
    {
        public DeleteProgramingLanguageValidatior()
        {
            RuleFor(p => p.Id).NotNull();
            RuleFor(p => p.Id).GreaterThan(0);
        }
    }
}
