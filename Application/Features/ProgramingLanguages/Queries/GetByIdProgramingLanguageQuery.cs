using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Rules;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Queries
{
    public class GetByIdProgramingLanguageQuery: IRequest<ProgramingLanguageDto>
    {
        public int Id { get; set; }

        public class GetByIdProgramingLanguageQueryHandler : IRequestHandler<GetByIdProgramingLanguageQuery, ProgramingLanguageDto>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;

            public GetByIdProgramingLanguageQueryHandler(IProgramingLanguageRepository programingLanguageRepository,
                IMapper mapper,
                ProgramingLanguageBusinessRules programingLanguageBusinessRules)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
            }

            public async Task<ProgramingLanguageDto> Handle(GetByIdProgramingLanguageQuery request, CancellationToken cancellationToken)
            {
                ProgramingLanguage? programingLanguage = await _programingLanguageRepository.GetAsync(
                    include: p => p.Include(p => p.ProgramingLanguageTechnologies),
                    predicate: p => p.Id == request.Id);

                _programingLanguageBusinessRules.ProgramingLanguageShouldExistWhenRequested(programingLanguage);

                ProgramingLanguageDto programingLanguageDto = _mapper.Map<ProgramingLanguageDto>(programingLanguage);
                return programingLanguageDto;
            }
        }
    }
}
