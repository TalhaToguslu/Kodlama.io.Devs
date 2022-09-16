using Application.Features.ProgramingLanguages.Models;
using Application.Features.ProgramingLanguages.Rules;
using Application.Services;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
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
    public class GetListProgramingLanguageQuery: IRequest<ProgramingLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProgramingLanguageQueryHandler : IRequestHandler<GetListProgramingLanguageQuery, ProgramingLanguageListModel>
        {
            private readonly IProgramingLanguageRepository _programingLangaugeRepository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;

            public GetListProgramingLanguageQueryHandler(IProgramingLanguageRepository programingLangaugeRepository,
                IMapper mapper,
                ProgramingLanguageBusinessRules programingLanguageBusinessRules)
            {
                _programingLangaugeRepository = programingLangaugeRepository;
                _mapper = mapper;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
            }

            public async Task<ProgramingLanguageListModel> Handle(GetListProgramingLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgramingLanguage> programingLanguages = await _programingLangaugeRepository.GetListAsync(
                    // Tabloları bağlasanda şu include yapmadan çalışmazzzz !!!!!!!!!!!!!
                    include: p => p.Include(pl => pl.ProgramingLanguageTechnologies),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                ProgramingLanguageListModel programingLanguageListModel = _mapper.Map<ProgramingLanguageListModel>(programingLanguages);

                return programingLanguageListModel;
            }
        }
    }
}
