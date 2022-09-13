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

namespace Application.Features.ProgramingLanguages.Commands.DeleteProgramingLanguage
{
    public class DeleteProgramingLanguageCommand: IRequest<ProgramingLanguageDto>
    {
        public int Id { get; set; }

        public class DeleteProgramingLanguageCommandHandler : IRequestHandler<DeleteProgramingLanguageCommand, ProgramingLanguageDto>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;

            public DeleteProgramingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository,
                IMapper mapper,
                ProgramingLanguageBusinessRules programingLanguageBusinessRules)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
            }

            public async Task<ProgramingLanguageDto> Handle(DeleteProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgramingLanguage mappedProgramingLanguage = _mapper.Map<ProgramingLanguage>(request);

                await _programingLanguageBusinessRules.FindExistsProgramingLanguageById(mappedProgramingLanguage);

                ProgramingLanguage deletedProgramingLanguage = await _programingLanguageRepository.DeleteAsync(mappedProgramingLanguage);
                ProgramingLanguageDto mappedProgramingLanguageDto = _mapper.Map<ProgramingLanguageDto>(deletedProgramingLanguage);
                return mappedProgramingLanguageDto; 
            }
        }
    }
}
