using Application.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Rules
{
    public class ProgramingLanguageBusinessRules
    {
        IProgramingLanguageRepository _programingLanguageRepository;
        
        public ProgramingLanguageBusinessRules(IProgramingLanguageRepository programingLanguageRepository)
        {
            _programingLanguageRepository = programingLanguageRepository;
        }

        public async Task CheckExistsProgramingLanguageBySameName(ProgramingLanguage programingLanguage)
        {
            var result = _programingLanguageRepository.Get(p => p.Name == programingLanguage.Name);

            if(result != null)
            {
                throw new Exception("Programlama dili zaten bulunuyor.");
            }
        }

        public async Task FindExistsProgramingLanguageById(ProgramingLanguage programingLanguage)
        {
            var result = _programingLanguageRepository.Get(p => p.Id == programingLanguage.Id);

            if (result == null)
            {
                throw new Exception("Programlama dili bulunamadı.");
            }
        }

    }
}
