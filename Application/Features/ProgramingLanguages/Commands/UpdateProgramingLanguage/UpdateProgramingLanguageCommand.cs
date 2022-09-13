using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Rules;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage
{
    public class UpdateProgramingLanguageCommand: IRequest<ProgramingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateProgramingLanguageCommandHandler: IRequestHandler<UpdateProgramingLanguageCommand, ProgramingLanguageDto>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;

            public UpdateProgramingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository,
                IMapper mapper,
                ProgramingLanguageBusinessRules programingLanguageBusinessRules)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
            }

            public async Task<ProgramingLanguageDto> Handle(UpdateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgramingLanguage mappedProgramingLanguage = _mapper.Map<ProgramingLanguage>(request);

                await _programingLanguageBusinessRules.FindExistsProgramingLanguageById(mappedProgramingLanguage);
                await _programingLanguageBusinessRules.CheckExistsProgramingLanguageBySameName(mappedProgramingLanguage);

                ProgramingLanguage updatedProgramingLanguage = await _programingLanguageRepository.UpdateAsync(mappedProgramingLanguage);
                ProgramingLanguageDto mappedProgramingLanguageDto = _mapper.Map<ProgramingLanguageDto>(updatedProgramingLanguage);
                return mappedProgramingLanguageDto;
            }
        }
    }
}
