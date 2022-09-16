using Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage;
using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguageTechnologies.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguageTechnologies.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgramingLanguageTechnology, ProgramingLanguageTechnologyIncludeDto>().ReverseMap();
        }
    }
}
