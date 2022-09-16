using Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage;
using Application.Features.ProgramingLanguages.Commands.DeleteProgramingLanguage;
using Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage;
using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateProgramingLanguageCommand, ProgramingLanguageDto>().ReverseMap();
            CreateMap<ProgramingLanguage, ProgramingLanguageDto>()
                .ForMember(p=> p.Technologies, opt=>opt.MapFrom(pl => pl.ProgramingLanguageTechnologies))
                .ReverseMap();
            CreateMap<CreateProgramingLanguageCommand, ProgramingLanguage>().ReverseMap();
            CreateMap<DeleteProgramingLanguageCommand, ProgramingLanguage>().ReverseMap();
            CreateMap<UpdateProgramingLanguageCommand, ProgramingLanguage>().ReverseMap();
            CreateMap<UpdateProgramingLanguageCommand, ProgramingLanguage>().ReverseMap();
            CreateMap<IPaginate<ProgramingLanguage>, ProgramingLanguageListModel>().ReverseMap();
        }
    }
}
